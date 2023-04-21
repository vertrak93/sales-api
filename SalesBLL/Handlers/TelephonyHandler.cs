using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Handlers
{
    public class TelephonyHandler
    {
        #region Constructor
        MyDbContext _context;
        public TelephonyHandler(MyDbContext context)
        {
            _context = context;
        }
        #endregion

        public List<Telephony> Get()
        {
            return _context.Telephony.ToList();
        }

        public Telephony? Get(int id)
        {
            return _context.Telephony.Where(obj => obj.TelephonyId == id).FirstOrDefault();
        }

        public void Post(Telephony telephony)
        {
            _context.SetCreator<Telephony>(telephony);
            _context.Telephony.Add(telephony);
            _context.SaveChanges();
        }

        public void Put(Telephony telephony)
        {
            _context.SetModifier<Telephony>(telephony);
            _context.Telephony.Update(telephony);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objTelephony = _context.Telephony.Where(obj => obj.TelephonyId == id).FirstOrDefault();
            objTelephony.Active = false;
            _context.Telephony.Update(objTelephony);
            _context.SaveChanges();
        }
    }
}
