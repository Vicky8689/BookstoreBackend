using BusineesLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.Model;

namespace BookStore.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }


        [HttpPost]
        [Route("register/user")]
        public IActionResult RegisterUserController(UserModel user)
        {
            return Ok( Signup(user, "user"));
        }
        [HttpPost]
        [Route("register/admin")]
        public IActionResult RegisterAdminController(UserModel user)
        {
            return Ok( Signup(user, "admin"));
        }
        [HttpPost]
        [Route("register")]
        public ResponseModel<string> Signup(UserModel user ,string role)
        {

            var result = _userBL.UserSignup(user,role);
            ResponseModel<string> response = new ResponseModel<string>();

            if (result != null)
            {
                response.Message = "success";
                response.Data = result.Email;
            }
            else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
            }
            return response;
        }

        //login
      
        [HttpPost]
        [Route("login")]
        public IActionResult LoginController(LoginRequestModel loginModel)
        {
           var result=  _userBL.Login(loginModel);
           
            ResponseModel<string> response = new ResponseModel<string>();

            if (result != null)
            {
                
                response.Message = result;

             
            }
            else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
               
            }
            return Ok(response);
           
        }
       


    }
}
