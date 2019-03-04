using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Buisness.Abstract;
using TestTask.Buisness.Models;

namespace TestTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _orderBusiness;
        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderBusiness.GetOrders());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderModel model)
        {
            return Ok(await _orderBusiness.AddOrder(model));
        }
    }
}
