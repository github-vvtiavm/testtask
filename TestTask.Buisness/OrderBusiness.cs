using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Buisness.Abstract;
using TestTask.Buisness.Models;
using TestTask.Common.Abstract;
using TestTask.Common.Entities;

namespace TestTask.Buisness
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderBusiness(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderModel> AddOrder(OrderModel model)
        {
            model.Id = 0;
            int clientTimeZone = (int)model.OrderDateTime.Offset.TotalMinutes;
            var entity = Mapper.Map<Order>(model);
            entity.SourceTimeZone = clientTimeZone;
            await _orderRepository.AddAsync(entity);
            return Mapper.Map<OrderModel>(entity);
        }

        public async Task<IEnumerable<OrderModel>> GetOrders()
        {
            var entities = (await _orderRepository.GetAllAsync()).ToList();
            entities.ForEach(x =>
            {
                x.OrderDateTime =
                    new DateTimeOffset(
                        x.OrderDateTime.ToUniversalTime().DateTime + TimeSpan.FromMinutes(x.SourceTimeZone),
                        TimeSpan.FromMinutes(x.SourceTimeZone));
            });
            return Mapper.Map<IEnumerable<OrderModel>>(entities);
        }
    }
}