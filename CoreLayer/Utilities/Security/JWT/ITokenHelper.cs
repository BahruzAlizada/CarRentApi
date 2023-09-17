using CoreLayer.Entities.Concrete;
using System;


namespace CoreLayer.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
