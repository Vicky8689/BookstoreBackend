using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{

    public class UserRL:IUserRl
    {
        private readonly BookStoreContext _context;
        public UserRL(BookStoreContext context)
        {
            _context = context;
        }

    
        public UserEntity UserSignup(UserModel user, string role)
        {
            var IsPresent =  _context.Users.FirstOrDefault(x => x.Email== user.email);

            if (IsPresent == null)
            {
                UserEntity userEntity = new UserEntity();
                userEntity.Email = user.email;
                userEntity.Role = role;
                userEntity.Name=user.name;
                userEntity.MobileNo = user.mobile;
                userEntity.Password = user.password;

                var dbresult =  _context.Add(userEntity); //maping userEntity to Context
                _context.SaveChangesAsync();

                return userEntity;
            }
            else
            {
                return null;
            }
            
        }

        public UserEntity Login(LoginRequestModel model)
        {  
             return _context.Users.FirstOrDefault(x => x.Email == model.Email);
           
        }

        public UserEntity GetProfile(int userId)
        {

            return _context.Users.FirstOrDefault(x => x.UserId == userId);

        }



    }
}
