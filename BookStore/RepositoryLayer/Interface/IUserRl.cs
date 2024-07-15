using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRl
    {
        public UserEntity UserSignup(UserModel user, string role);
        public UserEntity Login(LoginRequestModel model);
        public UserEntity GetProfile(int userId);
    }
}
