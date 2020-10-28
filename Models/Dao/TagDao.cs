using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TagDao
    {
        OnlineShopDbContext db = null;
        public TagDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(Tag entity)
        {
            try
            {
                var tag = db.Tags.Find(entity.Id);
                if (tag != null)
                {
                    tag.Name = entity.Name;                    
                    if (entity.DisplayOrder != null)
                    {
                        tag.DisplayOrder = entity.DisplayOrder;
                    }
                    tag.ModifiedDate = DateTime.Now;
                    tag.ModifiedBy = entity.ModifiedBy;                    
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
                var tag = db.Tags.Find(id);
                db.Tags.Remove(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Tag GetByName(string tagName)
        {
            return db.Tags.Where(t => t.Name == tagName).FirstOrDefault();
        }

        public TagModel GetJoinById(long? Id)
        {
            return (from tag in db.Tags
                    join creator in db.Users
                    on tag.CreatedBy equals creator.Id
                    join modifier in db.Users
                    on tag.ModifiedBy equals modifier.Id
                    select new TagModel
                    {
                        Id = tag.Id,
                        Name = tag.Name,                        
                        CreatedDate = tag.CreatedDate,
                        Creator = creator.UserName,
                        ModifiedDate = tag.ModifiedDate,
                        Modifier = modifier.UserName,
                        Status = tag.Status,                        
                        DisplayOrder = tag.DisplayOrder
                    }).Where(t => t.Id == Id).FirstOrDefault();
            //return db.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Tag GetById(long? Id)
        {
            return db.Tags.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<TagModel> ListAllPaging(string searchString, int Page, int PageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return (from tag in db.Tags
                        join user in db.Users
                        on tag.CreatedBy equals user.Id
                        where tag.Name.Contains(searchString)
                        select new TagModel
                        {
                            Id = tag.Id,
                            Name = tag.Name,                            
                            CreatedDate = tag.CreatedDate,
                            Creator = user.UserName,
                            Status = tag.Status
                        }).OrderByDescending(x => x.CreatedDate).ToPagedList(Page, PageSize);
            }
            else
            {
                return (from tag in db.Tags
                        join user in db.Users
                        on tag.CreatedBy equals user.Id
                        select new TagModel
                        {
                            Id = tag.Id,
                            Name = tag.Name,                            
                            CreatedDate = tag.CreatedDate,
                            Creator = user.UserName,
                            Status = tag.Status
                        }).OrderByDescending(x => x.CreatedDate).ToPagedList(Page, PageSize);
            }
            //return db.Categories.OrderByDescending(x=>x.CreatedDate).ToPagedList(Page, PageSize);
        }

        public List<Tag> ListAll()
        {
            return db.Tags.Where(x => x.Status == true).ToList();
        }

        public bool ChangeStatus(long id)
        {
            var tag = db.Tags.Find(id);
            tag.Status = !tag.Status;
            db.SaveChanges();
            return tag.Status;
        }
    }
}
