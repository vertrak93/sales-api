using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class BankHandler
    {
        #region Constructor
        MyDbContext _context;
        public BankHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Bank> Get()
        {
            return _context.Bank.ToList();
        }

        public Bank? Get(int id) 
        {
            return _context.Bank.Where(obj => obj.BankId == id).FirstOrDefault();
        }

        public void Post(Bank bank) 
        {
            _context.SetCreator<Bank>(bank);
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        public void Put(Bank bank)
        {
            _context.SetModifier<Bank>(bank);
            _context.Bank.Update(bank);
            _context.SaveChanges();
        }

        public void Delete(int id) 
        {
            var objBank = _context.Bank.Where(obj => obj.BankId == id).FirstOrDefault();
            objBank.Active = false;
            _context.Bank.Update(objBank);
            _context.SaveChanges();
        }
    }
}
