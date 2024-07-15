using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {

        public OrderEntity AddOrder(int UserId, OrderRequestModel model);
        public List<OrderResponsModel> GetAllOrders(int UserId);
    }
}
