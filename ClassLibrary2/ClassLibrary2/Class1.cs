using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;

namespace ClassLibrary2
{
    public class Class1
    {
        [SqlFunctionAttribute()]
        public static SqlInt32 phonecheck(SqlInt32 phone)
        {
            string s = phone.ToString();
            int flag = -1;
            string pattern = @"\d{11}";
            Regex r = new Regex(pattern);
            Match m = r.Match(s);
            if (m.Success) flag = 1;
            else flag = 0;
            return (SqlInt32)flag;
        }
    }
}
