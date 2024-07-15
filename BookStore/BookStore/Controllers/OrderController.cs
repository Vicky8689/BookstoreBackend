using BusineesLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System.Data;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly IOrderBL _orderBL;
        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
            
        }
        [HttpPost]
        [Route("addorder")]
        [Authorize]
        public IActionResult AddOrderController(OrderRequestModel model)
        {
            var role = User.FindFirstValue("Role");
            ResponseModel<OrderEntity> response = new ResponseModel<OrderEntity>();
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            if (role == "user")
            {
                var result = _orderBL.AddOrder(userId, model);
                if (result != null)
                {
                    response.Message = "Success";
                    response.Data = result;

                }
                else
                {
                    response.Success = false;
                    response.Message = "UnSuccessfull";
                }
                return Ok(response);

            }
            else
            {
                return BadRequest("you are Not authorize");
            }

        }

        [HttpGet]
        [Route("GetallOrder")]
        public IActionResult GetAllOrdereController()
        {
            var role = User.FindFirstValue("Role");
            ResponseModel<List<OrderResponsModel>> response = new ResponseModel<List<OrderResponsModel>>();
            var id = User.FindFirstValue("UserID");
            int userId = Convert.ToInt32(id);
            if (role == "user")
            {
                var result = _orderBL.GetAllOrders(userId);
                if (result != null)
                {
                    response.Message = "Success";
                    response.Data = result;


                }
                else
                {
                    response.Success = false;
                    response.Message = "UnSuccessfull";
                }
                return Ok(response);

            }
            else
            {
                return BadRequest("you are Not authorize");
            }
        }
    }
}
