using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public static  class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)   //sistemi kullanmak için elimizde olanları veriyoruz
        {
          //  return new SigningCredentials(securityKey,SecurityAlgorithms.EcdsaSha512Signature); //hangi dogrulama kullanılcak ? 
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
