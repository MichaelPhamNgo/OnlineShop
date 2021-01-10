using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Models.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(Category entity)
        {
            try
            {
                var cat = db.Categories.Find(entity.Id);
                if (cat != null)
                {
                    cat.Name = entity.Name;
                    cat.SeoTitle = entity.SeoTitle;
                    cat.MetaKeywords = entity.MetaKeywords;
                    cat.MetaTitle = entity.MetaTitle;
                    cat.MetaDescription = entity.MetaDescription;
                    if(entity.ParentId != null)
                    {
                        cat.ParentId = entity.ParentId;
                    }
                    if(entity.DisplayOrder != null)
                    {
                        cat.DisplayOrder = entity.DisplayOrder;
                    }
                    cat.ModifiedDate = DateTime.Now;
                    cat.ModifiedBy = entity.ModifiedBy;
                    cat.ShowOnHome = entity.ShowOnHome;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(long? id)
        {
            try
            {
                var cat = db.Categories.Find(id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Category GetByName(string categoryName)
        {
            return db.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
        }        

        public CategoryModel GetJoinById(long? Id)
        {
            return (from cat in db.Categories
                    join creator in db.Users
                    on cat.CreatedBy equals creator.Id
                    join modifier in db.Users
                    on cat.ModifiedBy equals modifier.Id
                    select new CategoryModel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        SeoTitle = cat.SeoTitle,
                        MetaTitle = cat.MetaTitle,
                        MetaKeywords = cat.MetaKeywords,
                        MetaDescription = cat.MetaDescription,
                        CreatedDate = cat.CreatedDate,
                        Creator = creator.UserName,
                        ModifiedDate = cat.ModifiedDate,
                        Modifier = modifier.UserName,
                        Status = cat.Status,
                        ShowOnHome = cat.ShowOnHome,
                        DisplayOrder = cat.DisplayOrder                        
                    }).Where(c => c.Id == Id).FirstOrDefault();
            //return db.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Category GetById(long? Id)
        {            
            return db.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }
        

        public IEnumerable<CategoryModel> ListAllPaging(string searchName, string searchMetaTitle,
                                                            string searchDateFrom, string searchDateTo,
                                                                string searchCreator, string searchStatus, 
                                                                    int Page, int PageSize)
        {
            return null;
            //var sql = from cat in db.Categories
            //                join user in db.Users
            //                on cat.CreatedBy equals user.Id
            //              select new CategoryModel
            //              {
            //                  Id = cat.Id,
            //                  Name = cat.Name,
            //                  MetaTitle = cat.MetaTitle,
            //                  MetaKeywords = cat.MetaKeywords,
            //                  SeoTitle = cat.SeoTitle,
            //                  CreatedDate = cat.CreatedDate,
            //                  Creator = user.UserName,
            //                  Status = cat.Status
            //              };
            //if (!string.IsNullOrEmpty(searchName))
            //    sql = sql.Where(c => c.Name.Contains(searchName));          

            //if (!string.IsNullOrEmpty(searchMetaTitle))
            //    sql = sql.Where(c => c.MetaTitle.Contains(searchMetaTitle));
            
            //if (!string.IsNullOrEmpty(searchDateFrom))
            //{
            //    var dateFrom = DateTime.Parse(searchDateFrom);
            //    sql = sql.Where(c => DateTime.Compare(dateFrom, c.CreatedDate.Value) <= 0);
            //}                

            //if (!string.IsNullOrEmpty(searchDateTo))
            //{
            //    var dateTo = DateTime.Parse(searchDateTo);
            //    sql = sql.Where(c => DateTime.Compare(dateTo, c.CreatedDate.Value) >= 0);
            //}                

            //if (!string.IsNullOrEmpty(searchStatus))
            //{
            //    var status = false;
            //    if(int.Parse(searchStatus) == 1)
            //    {
            //        status = true;
            //    } else
            //    {
            //        status = false;
            //    }
            //    sql = sql.Where(p => p.Status == status);
            //}
                

            //return sql.OrderByDescending(x => x.CreatedDate).ToPagedList(Page, PageSize);            
        }

        
        public List<Category> ListAll()
        {            
            return db.Categories.Where(c => c.Status == true).ToList();
        }

        public bool ChangeStatus(long id)
        {
            var cat = db.Categories.Find(id);
            cat.Status = !cat.Status;
            db.SaveChanges();
            return cat.Status;
        }
    }
}
