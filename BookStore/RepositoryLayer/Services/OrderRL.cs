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
    public class OrderRL:IOrderRL
    {
        private readonly BookStoreContext _context;
        public OrderRL(BookStoreContext context)
        {
            _context = context;
        }
        public OrderEntity AddOrder(int UserId ,OrderRequestModel model )
        {
            try
            {
                var book = _context.Books.FirstOrDefault(x => x.bookId == model.BookId);
                var cart = _context.Cart.FirstOrDefault(x=>x.CartId== model.CartId);

           OrderEntity order = new OrderEntity();   
            order.UserId = UserId;
            order.cCity = model.cCity;
            order.cAdd = model.cAdd;
            order.cState = model.cState;
            order.BookId = model.BookId;
            order.cMobil =model.cMobil;
            order.cName = model.cName;
            order.orderDate = DateTime.Now;
                order.totalPrice = book.price * cart.bookQuantity;
                order.totladiscountPrice = book.discountPrice * cart.bookQuantity;
            _context.Order.Add(order);
            int result =_context.SaveChanges();
            var findCart = _context.Cart.FirstOrDefault(x=>x.CartId == model.CartId);
            if (findCart != null)
                {
                    _context.Cart.Remove(findCart);
                    _context.SaveChanges();
                }




            if (result > 0)
            {
                return order;

            }else{
                return null;
            }
            }catch (Exception ex)
            {
                return null;
            }


        }
        public List<OrderResponsModel> GetAllOrders(int UserId)
        {
            var getOrder = _context.Order.Where(x=> x.UserId == UserId).ToList();
 
            if (getOrder != null)
            {
                List<OrderResponsModel> alldata = new List<OrderResponsModel>();
                foreach (var order in getOrder)
                {

                        var book = _context.Books.FirstOrDefault(x => x.bookId == order.BookId );
                    if(book != null)
                    {

                        OrderResponsModel data = new OrderResponsModel();
                        data.orderId = order.orderId;
                        data.bookName = book.bookName;
                        data.bookAuthor = book.author;
                        data.orderDate = order.orderDate;
                        data.totalPrice = order.totalPrice;
                        data.totalDiscountPrice = order.totladiscountPrice;
                        alldata.Add(data);
                    }


                }
                return alldata;

            }
            return null;
            
        }
    }
}
