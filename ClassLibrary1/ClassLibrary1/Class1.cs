using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
namespace ClassLibrary1
{
    public class Class1
    {
        [SqlFunctionAttribute()]
        public static SqlInt32 checkadress (SqlString adress)
        {
            string s = adress.ToString();
            int flag = -1;
            string pattern = @"/.+дом [1-10]";
            Regex r = new Regex(pattern);
            Match m = r.Match(s);
            if (m.Success) flag = 1;
            else flag = 0;
            return (SqlInt32)flag;
        }
    }
}
