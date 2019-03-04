using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Buisness.Models;

namespace TestTask.Buisness.Abstract
{
    public interface IOrderBusiness
    {
        Task<OrderModel> AddOrder(OrderModel model);
        Task<IEnumerable<OrderModel>> GetOrders();
    }
}
