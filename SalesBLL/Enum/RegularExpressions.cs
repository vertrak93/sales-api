using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBLL.Enum
{
    public class RegularExpressions
    {
        #region User
        public static readonly string Username = "^[a-zA-Z0-9](_(?!(\\.|_))|\\.(?!(_|\\.))|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$";
        public static readonly string Password = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$";
        public static readonly string Email = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        #endregion
    }
}
