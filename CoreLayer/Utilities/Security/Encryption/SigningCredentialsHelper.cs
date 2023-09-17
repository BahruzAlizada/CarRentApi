using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;


namespace CoreLayer.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) //JWT 
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }    
    }
}
