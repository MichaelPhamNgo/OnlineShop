using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ContactDao
    {
        OnlineShopDbContext db = null;
        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(Contact entity)
        {
            try
            {
                var cont = db.Contacts.Find(entity.Id);
                if (cont != null)
                {
                    cont.Detail = entity.Detail;                    
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(long? id)
        {
            try
            {
                var cont = db.Contacts.Find(id);
                db.Contacts.Remove(cont);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Contact GetByDetail(string contactDetail)
        {
            return db.Contacts.Where(t => t.Detail == contactDetail).FirstOrDefault();
        }

        public Contact GetById(long? Id)
        {
            return db.Contacts.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Contact> ListAllPaging(string searchString, int Page, int PageSize)
        {
            //return db.Contacts.OrderByDescending(x=>x.Id).ToPagedList(Page, PageSize);
            return null;
        }

        public List<Contact> ListAll()
        {
            return db.Contacts.Where(x => x.Status == true).ToList();
        }

        public bool ChangeStatus(long id)
        {
            var cont = db.Contacts.Find(id);
            cont.Status = !cont.Status;
            db.SaveChanges();
            return cont.Status;
        }
    }
}
