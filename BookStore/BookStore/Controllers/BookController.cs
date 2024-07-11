using BusineesLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Helpers;
using ModelLayer;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : Controller 
    {
        private readonly IBookBL _bookBL;
        public BookController(IBookBL bookBL)
        {
            _bookBL = bookBL;
        }
        [HttpPost]
        [Route("Addbook")]
        //[Authorize(Roles ="admin")]
        [Authorize]
      
        public IActionResult AddBookController(AddBookRequestModel model)
        {
            var role = User.FindFirstValue("Role");
            ResponseModel<string> response = new ResponseModel<string>();

            if (role == "admin")
            {

                var result=_bookBL.AddBook(model);
                if (result != null)
                {
                    response.Message = "success";
                   
                }
                else
                {
                    response.Message = "Unsuccesfull";
                    response.Success = false;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("you are Not authorize ");
            }

        }


        [HttpGet]
        [Route("GetAllBook")]
        public IActionResult GetAllBookController()
        {
            var result= _bookBL.GetAllBooks();
            ResponseModel<List<BookEntity>> response = new ResponseModel<List<BookEntity>>();
            if (result != null)
            {
                response.Message = "success";
                response.Data = result;
            }
            else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
            }
            return Ok(response);
        }

        //Get book by Id
        [HttpGet]
        [Route("GetBookbyId")]
        public IActionResult GetBookController([FromQuery] int bookId)
        {
            var result = _bookBL.GetBooksById(bookId);
            ResponseModel<BookEntity> response = new ResponseModel<BookEntity>();
            if (result != null)
            {
                response.Message = "success";
                response.Data = result;
            }
            else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Addcart")]
        [Authorize]
        public IActionResult AddCartController([FromQuery] int bookId )
        {
            var role = User.FindFirstValue("Role");
            ResponseModel<string> response = new ResponseModel<string>();
             var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            if (role == "user")
            {
                var result = _bookBL.AddCart(userId,bookId);
                if (result != null)
                {
                    response.Message = "success";
                }
                else
                {
                    response.Message = "Unsuccesfull";
                    response.Success = false;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("you are Not authorize");
            }
        }



        //get all cart
        [HttpGet]
        [Authorize]
        [Route("getAllCart")]
        public IActionResult GetAllCartController()
        {
            var role = User.FindFirstValue("Role");
            ResponseModel<List<CartResponseModel>> response = new ResponseModel<List<CartResponseModel>>();

            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            if (role == "user")
            {
                var result = _bookBL.GetAllCart(userId);
                Console.WriteLine(result);
                if (result != null)
                {
                    response.Message = "success";
                    response.Data = result;
                }
                else
                {
                    response.Message = "Unsuccesfull";
                    response.Success = false;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("you are Not authorize");
            }
        }

        //delete cart
        [HttpDelete]
        [Authorize]
        [Route("deleteCart")]
        public IActionResult DeleteCartController([FromQuery] int cartId)
        {

            var role = User.FindFirstValue("Role");
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            ResponseModel<CartEntity> response = new ResponseModel<CartEntity>();

            if (role == "user")
            {

                var result = _bookBL.DeleteCart(cartId, userId);
                if (result != null)
                {
                    response.Message = "success";
                    response.Data = result;
                }
                else
                {
                    response.Message = "Unsuccesfull";
                    response.Success = false;
                }
                return Ok(response);


            }
            else
            {
                return BadRequest("you are Not authorize");
            }

        }


        //Addwishlist
        [HttpPost]
        [Authorize]
        [Route("addwishlist")]
        public IActionResult AddwishListController([FromQuery ]int bookid) {
            var role = User.FindFirstValue("Role");
            ResponseModel<bool> response = new ResponseModel<bool>();
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            if (role == "user")
            {
                var result = _bookBL.AddWishlist(userId, bookid);
                if (result != null)
                {   response.Message = "success";
                    response.Data = result;
                }
                else
                {
                    response.Message = "Unsuccesfull";
                    response.Success = false;
                    response.Data = result;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("you are Not authorize");
            }
        }
        //get all wishlist
        [HttpGet]
        [Route("GetAllWishlist")]
        [Authorize]
        public IActionResult GetAllWishlisController()
        {         
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            var result = _bookBL.GetAllWishlist(userId);
            ResponseModel<List<WishlistResponseModel>> response = new ResponseModel<List<WishlistResponseModel>>();
            if (result != null)
            {
                response.Message = "success";
                response.Data = result;
            } else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
            }
            return Ok(response);
        }
        //delete wishlist
        [HttpDelete]
        [Authorize]
        [Route("deleteWishlist")]
        public IActionResult DeleteWishlisController([FromQuery] int bookid)
        {
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            ResponseModel<bool> response = new ResponseModel<bool>();
            var result = _bookBL.deletewishlist(userId,bookid);
            if (result )
            {
                response.Message = "success";
                response.Data = result;
            }else
            {
                response.Message = "Unsuccesfull";
                response.Success = false;
            }
            return Ok(response);

        }

    }
}
