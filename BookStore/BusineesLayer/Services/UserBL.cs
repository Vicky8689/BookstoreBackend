using BusineesLayer.Interface;
using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Helper;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Services
{
    public class UserBL:IUserBL
    {
        private readonly IUserRl _userRl;
        public UserBL(IUserRl userRl)
        {
            _userRl = userRl;
        }
        public UserEntity UserSignup(UserModel user, string role)
        {

            //Hash the user password
            user.password = HashPasswordBL.HashPsaaword(user.password);

          
            
            return _userRl.UserSignup(user,role);

        }
        public string Login(LoginRequestModel model)
        {
            var result =  _userRl.Login(model);
            
            if (result != null)
            {
                bool verifyUser = HashPasswordBL.VerifyHash(model.Password, result.Password);
                if (verifyUser)
                {

                    return TokenGenerateRL.GenerateTokenRL(result);
                }
                //  return verifyUser;
            }
            return null;

           
        }



    
    }
}
