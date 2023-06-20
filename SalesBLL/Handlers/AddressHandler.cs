using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class AddressHandler
    {
        #region Constructor
        MyDbContext _context;
        public AddressHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Address> Get()
        {
            return _context.Address.ToList();
        }

        public Address? Get(int id)
        {
            return _context.Address.Where(obj => obj.AddressId == id).FirstOrDefault();
        }

        public void Post(Address address)
        {
            _context.SetCreator<Address>(address);
            _context.Address.Add(address);
            _context.SaveChanges();
        }

        public void Put(Address address)
        {
            _context.SetModifier<Address>(address);
            _context.Address.Update(address);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objAddress = _context.Address.Where(obj => obj.AddressId == id).FirstOrDefault();
            objAddress.Active = false;
            _context.Address.Update(objAddress);
            _context.SaveChanges();
        }
    }
}
