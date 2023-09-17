using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CoreLayer.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) //Bir SecurityKey yaratmaq üçün
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //Bu securityKey-i byte çeviririk çünki byte qəbul edir.
        }

    }
}
