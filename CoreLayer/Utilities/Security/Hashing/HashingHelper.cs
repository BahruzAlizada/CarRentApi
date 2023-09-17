using System;
using System.Security.Cryptography;
using System.Text;

namespace CoreLayer.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt) // bir şifrənin Hash-ini yaradır
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Passworu byte istəyir deyə byte çeviririk
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //Eyni Passwordu eyni alqoritmlə hashləsə idin eyni nəticəni alardın mı
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++) //Hashləşmiş hər bir dəyər bərabər deyilsə false bərabərdisə true
            {
                if (computedHash[i]!= passwordHash[i])
                    return false;
            }
            return true;
        }

    }
}
