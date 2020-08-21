using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpLiftCurse.AccessData.Data.Repository.IRepository;
using UpLiftCurse.DataAccess.Data;
using UpLiftCurse.Models;

namespace UpLiftCurse.AccessData.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var obj = _db.Category.FirstOrDefault(j => j.Id == category.Id);

            obj.Name = category.Name;
            obj.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
