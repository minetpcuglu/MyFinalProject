using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper //ilgili kullanıcı bilgilerini içerecek Token üretir 
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
