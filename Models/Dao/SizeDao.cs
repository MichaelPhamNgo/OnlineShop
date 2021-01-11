using Models.Common;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Dao
{
    public class SizeDao
    {
        MyDbContext db;

        public SizeDao()
        {
            db = new MyDbContext();
        }

        public SizeViewModel GetById(long Id)
        {
            var query =  from s in db.Sizes
                   where s.Id == Id
                   select new SizeViewModel
                   {
                       Id = s.Id,
                       Name = s.Name
                   };
            return query.FirstOrDefault();
        }

        public List<SizeViewModel> GetAll()
        {
            var query = from s in db.Sizes
                        select new SizeViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        };            
            return query.ToList();
        }

        public PagedResult<SizeViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = from s in db.Sizes
                        select new SizeViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        };     
            
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.Name)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            var paginationSet = new PagedResult<SizeViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public long Add(Size s)
        {
            db.Sizes.Add(s);
            db.SaveChanges();
            return s.Id;
        }       

        public bool Update(Size s)
        {
            try
            {
                var size = db.Sizes.Find(s.Id);
                if (size != null)
                {
                    size.Name = s.Name;
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
                var size = db.Sizes.Find(id);
                db.Sizes.Remove(size);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}