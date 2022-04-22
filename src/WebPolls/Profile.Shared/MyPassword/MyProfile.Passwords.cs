using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Shared.MyPassword.Password
{
  public class Password
  {

    public string CurPassword { get; set; }
    public string OldPassword { get; set; } 
    public string NewPassword { get; set; }
    public int PasswordStrength { get; set; }
    public bool IsPasswordValid { get; set; }
    public string PasswordHash { get; set; }
    public byte[]  PasswordSalt { get; set; }

    public Password()
    {

      CurPassword = "123";
      OldPassword = "";
      NewPassword = "";
      PasswordStrength = 1;
      IsPasswordValid = true;
      PasswordSalt = new byte[128 / 8];
      using (var rngCsp = new RNGCryptoServiceProvider())
      {
        rngCsp.GetNonZeroBytes(PasswordSalt);
      }
      PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                  password: CurPassword,
                                                                  salt: PasswordSalt,
                                                                  prf: KeyDerivationPrf.HMACSHA256,
                                                                  iterationCount: 100000,
                                                                  numBytesRequested: 256 / 8)

                                                                 );


    }


  }

}
