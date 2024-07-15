using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Interface
{
    public interface IOrderBL
    {
        public OrderEntity AddOrder(int UserId, OrderRequestModel model);
        public List<OrderResponsModel> GetAllOrders(int UserId);
    }
}
