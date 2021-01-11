using Models.Dao;
using Models.Entities;
using Models.Enums;
using Newtonsoft.Json.Linq;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //References https://retifrav.github.io/blog/2017/08/23/dotnet-core-mvc-recaptcha/
        public static bool ReCaptchaPassed(string gRecaptchaResponse, string secret)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={gRecaptchaResponse}").Result;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                //logger.LogError("Error while sending request to ReCaptcha");
                return false;
            }

            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);
            if (JSONdata.success != "true")
            {
                return false;
            }

            return true;
        }

        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginAccount model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["g-recaptcha-response"] != null)
                {
                    if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"], ConfigurationManager.AppSettings["ReCaptcha.PrivateKey"].ToString()))
                    {
                        TempData["ReCaptchaKey"] = ConfigurationManager.AppSettings["ReCaptcha.PublicKey"].ToString();
                        ViewData["LoginFailedErrorMessage"] = "You failed the CAPTCHA.";
                        return View(model);
                    }
                }

                var dao = new UserDao();
                var getUser = dao.getUserByEmail(model.Email);

                //If the email does not exist, show error messages
                if (getUser == null)
                {
                    ModelState.AddModelError("Email", "Your email does not exist in database.");
                }
                else
                {
                    string securityStamp = getUser.SecurityStamp.ToString();
                    string password = getUser.Password;
                    string comparePassword = Helper.EncodePassword(model.Password, securityStamp);
                    if (getUser.LockoutEnd == null || getUser.AccessFailedCount == null || getUser.LockoutEnabled == null)
                    {
                        //If password is not matched, reset and count the attempted login
                        if (password.Equals(comparePassword))
                        {
                            var userSession = new Account();
                            userSession.UserId = getUser.Id;
                            userSession.UserName = getUser.UserName;
                            userSession.Email = getUser.Email;
                            Session.Add(CommonConstants.USER_SESSION, userSession);
                            dao.resetCountAttemptedLogin(getUser.Id, 1, Helper.nextDay(DateTimeOffset.UtcNow), false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Password does not exist in database.");
                            dao.resetCountAttemptedLogin(getUser.Id, 1, Helper.nextDay(DateTimeOffset.UtcNow), false);
                        }

                    }
                    else
                    {
                        DateTime logoutEnd = ((DateTimeOffset)getUser.LockoutEnd).ToUniversalTime().Date;
                        int acessFailedCount = (int)getUser.AccessFailedCount;
                        bool lockoutEnabled = (bool)getUser.LockoutEnabled;
                        if (lockoutEnabled) //If account is blocked
                        {
                            //Check block is expired or not
                            DateTime currentDateTime = DateTimeOffset.UtcNow.ToUniversalTime().Date;
                            if (!Helper.SameDate(currentDateTime, logoutEnd)) //If block is expired, then check password
                            {
                                //If password is not matched, reset and count the attempted login
                                if (!password.Equals(comparePassword))
                                {
                                    ModelState.AddModelError("Password", "Password does not match.");
                                    dao.resetCountAttemptedLogin(getUser.Id, 1, Helper.nextDay(DateTimeOffset.UtcNow), false);
                                }
                                else
                                {
                                    var userSession = new Account();
                                    userSession.UserId = getUser.Id;
                                    userSession.UserName = getUser.UserName;
                                    userSession.Email = getUser.Email;
                                    Session.Add(CommonConstants.USER_SESSION, userSession);
                                    TempData.Remove("ReCaptchaKey");
                                    dao.resetCountAttemptedLogin(getUser.Id, 1, Helper.nextDay(DateTimeOffset.UtcNow), false);
                                    return RedirectToAction("Index", "Home");
                                }
                            }
                            else
                            {
                                ViewData["LoginFailedErrorMessage"] = "Your account is blocked";
                            }
                        }
                        else
                        {
                            //If password is not matched, reset and count the attempted login
                            if (!password.Equals(comparePassword))
                            {
                                int attemptLoginCaptcha = int.Parse(ConfigurationManager.AppSettings["AttemptLoginCaptcha"].ToString());
                                int attemptLoginLock = int.Parse(ConfigurationManager.AppSettings["AttemptLoginLock"].ToString());
                                if (acessFailedCount > attemptLoginCaptcha && acessFailedCount <= attemptLoginLock) //If number of login attempt exceeds 3, show captcha
                                {
                                    TempData["ReCaptchaKey"] = ConfigurationManager.AppSettings["ReCaptcha.PublicKey"].ToString();
                                    dao.countUserAttempt(getUser.Id, acessFailedCount + 1);
                                }
                                else if (acessFailedCount > attemptLoginLock) //If number of login attempt exceeds 8, disable account a day
                                {
                                    TempData["ReCaptchaKey"] = ConfigurationManager.AppSettings["ReCaptcha.PublicKey"].ToString();
                                    ViewData["LoginFailedErrorMessage"] = "Your account is blocked";
                                    dao.disableAccount(getUser.Id, acessFailedCount + 1, true);
                                }
                                else
                                {
                                    ModelState.AddModelError("Password", "Password does not match.");
                                    dao.countUserAttempt(getUser.Id, acessFailedCount + 1);
                                }
                            }
                            else
                            {
                                var userSession = new Account();
                                userSession.UserId = getUser.Id;
                                userSession.UserName = getUser.UserName;
                                userSession.Email = getUser.Email;
                                TempData.Remove("ReCaptchaKey");
                                Session.Add(CommonConstants.USER_SESSION, userSession);
                                dao.resetCountAttemptedLogin(getUser.Id, 1, Helper.nextDay(DateTimeOffset.UtcNow), false);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var getUserByEmail = dao.getUserByEmail(model.Email);
                if (getUserByEmail != null)
                {
                    ModelState.AddModelError("Email", "Email account exists in database.");
                    return View(model);
                }

                var getUserByUsername = dao.getUserByEmail(model.UserName);
                if (getUserByUsername != null)
                {
                    ModelState.AddModelError("Username", "Username exists in database.");
                    return View(model);
                }

                var entity = new User();
                entity.Id = Guid.NewGuid();
                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.SecurityStamp = Guid.NewGuid().ToString();
                entity.Password = Helper.EncodePassword(model.Password, entity.SecurityStamp.ToString());
                entity.RegisteredDate = DateTime.UtcNow;
                entity.Status = Status.Active;
                Guid id = dao.createUser(entity);
                if (id != null)
                {
                    ViewData["CreateUserSuccessMessage"] = "Please confirm your email before login to website.";
                }
                else
                {
                    ViewData["CreateUserErrorMessage"] = "Create a new account failed.";
                }
            }
            return View(model);
        }

        public ActionResult Forgetpassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}