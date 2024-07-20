using BusineesLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                var tokenHandelar = new JwtSecurityTokenHandler();
                var jwtTokenObj = tokenHandelar.ReadJwtToken(result);
                var claim = jwtTokenObj.Claims;
                response.Data = claim.FirstOrDefault(x => x.Type == "Role")?.Value;

             
            }
            else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
               
            }
            return Ok(response);
           
        }

        //get all profile
        [HttpGet]
        [Route("allprofile")]
        public IActionResult GetProfileController()
        {
            ResponseModel<UserEntity> response = new ResponseModel<UserEntity>();
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            var result = _userBL.GetProfile(userId);
            if(result != null)
            {
                response.Message = "success";
                response.Data = result;

            }
            else
            {
                response.Message = "Unsuccess";
                response.Success=false;
            }
            return Ok(response );
        } 



    }
}
