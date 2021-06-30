using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //verilen sifrenin hash olusturmaya yarar 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;    //her kullanıcı ıcın anlık baska bir key olusur  //verilen  degerin saltını hash olusturmaya calısır
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //olsuturulan psswordhash dogrulandıgına bakar 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var  computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  //hasladıgımız degeri karsılastırır
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i]) //iki deger birbiriyle eslesiyormu 
                    {
                        return false;
                    }

                }
            }
            return true;

        }
        
    }
}
