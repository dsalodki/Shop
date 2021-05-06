using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utility
{
    public static class PasswordGenerator
    {
        // do not use Random for security reasons
        public static string GeneratePwd()
        {
            // a-z
            var random = new Random();
            char[] randomPassword = new char[4];
            for (int i = 0; i < 4; i++)
            {
                randomPassword[i] = Convert.ToChar(random.Next(97, 123));
            }

            return randomPassword.ToString();
        }
    }
}
