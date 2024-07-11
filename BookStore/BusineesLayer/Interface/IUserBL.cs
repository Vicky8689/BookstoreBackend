using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Interface
{
    public interface IUserBL
    {
        public UserEntity UserSignup(UserModel user, string role);
        public string Login(LoginRequestModel model);
    }
}
