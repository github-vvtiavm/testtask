using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Buisness.Models;

namespace TestTask.Buisness.Abstract
{
    public interface IOrderBuisness
    {
        Task<OrderModel> AddOrder(OrderModel model);
        Task<IEnumerable<OrderModel>> GetOrrders();
    }
}
