using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class BrandHandler
    {
        #region Constructor
        MyDbContext _context;
        public BrandHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Brand> Get()
        {
            return _context.Brand.ToList();
        }

        public Brand? Get(int id)
        {
            return _context.Brand.Where(obj => obj.BrandId == id).FirstOrDefault();
        }

        public void Post(Brand brand)
        {
            _context.SetCreator<Brand>(brand);
            _context.Brand.Add(brand);
            _context.SaveChanges();
        }

        public void Put(Brand brand)
        {
            _context.SetModifier<Brand>(brand);
            _context.Brand.Update(brand);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objBrand = _context.Brand.Where(obj => obj.BrandId == id).FirstOrDefault();
            objBrand.Active = false;
            _context.Brand.Update(objBrand);
            _context.SaveChanges();
        }
    }
}
