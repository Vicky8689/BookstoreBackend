using BusineesLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Services
{
    public class OrderBL:IOrderBL
    {
        private readonly IOrderRL _orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            _orderRL = orderRL;
            
        }
        public OrderEntity AddOrder(int UserId, OrderRequestModel model)
        {
            return _orderRL.AddOrder(UserId, model);

        }

        public List<OrderResponsModel> GetAllOrders(int UserId)
        {
            return _orderRL.GetAllOrders(UserId);
        }
    }
}
