using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class PhoneHandler
    {
        #region Constructor
        MyDbContext _context;
        public PhoneHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Phone> Get() 
        { 
            return _context.Phone.ToList();
        }

        public Phone? Get(int id) 
        {
            return _context.Phone.Where( obj => obj.PhoneId == id).FirstOrDefault();
        }

        public void Post(Phone phone)
        {
            var objPhone = phone;
            _context.SetCreator<Phone>(objPhone);  
            _context.Phone.Add(objPhone);
            _context.SaveChanges();
        }

        public void Put(Phone phone)
        {
            _context.SetModifier<Phone>(phone);
            _context.Phone.Update(phone);
            _context.SaveChanges();
        }

        public void Delete(int id) 
        { 
            var objPhone = _context.Phone.Where(obj => obj.PhoneId==id).FirstOrDefault();
            objPhone.Active = false;
            _context.SetModifier<Phone>(objPhone);
            _context.SaveChanges();
        }

    }
}
