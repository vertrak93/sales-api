using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class CategoryHandler
    {
        #region Constructor
        MyDbContext _context;
        public CategoryHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Category> Get()
        {
            return _context.Category.ToList();
        }

        public Category? Get(int id)
        {
            return _context.Category.Where(obj => obj.CategoryId == id).FirstOrDefault();
        }

        public void Post(Category category)
        {
            _context.SetCreator<Category>(category);
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void Put(Category category)
        {
            _context.SetModifier<Category>(category);
            _context.Category.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objCategory = _context.Category.Where(obj => obj.CategoryId == id).FirstOrDefault();
            objCategory.Active = false;
            _context.Category.Update(objCategory);
            _context.SaveChanges();
        }
    }
}
