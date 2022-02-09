using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Getall();
        Task<Order> Get(int id);
        Task<bool> Add(Order model);

        Task<bool> Delete(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //obtener lista de clientes
        public async Task<IEnumerable<Order>> Getall()
        {
            var result = new List<Order>();

            try
            {
                result = await _applicationDbContext.Orders.OrderByDescending(x => x.OrderId)
                                    .Include(x => x.Client)
                                    .Include(x => x.Items)
                                        .ThenInclude(x => x.Product).ToListAsync();
            }
            catch (Exception e)
            {

            }

            return result;
        }

        //obtener producto por id
        public async Task<Order> Get(int id)
        {
            var result = new Order();

            try
            {
                result = await _applicationDbContext.Orders.Include(x => x.Client)
                                    .Include(x => x.Items)
                                        .ThenInclude(x => x.Product).SingleAsync(x => x.OrderId == id);
            }
            catch (Exception e)
            {

            }
            return result;
        }

        //agregar nuevo client
        public async Task<bool> Add(Order model)
        {
            try
            {
                //using var transaction = _applicationDbContext.Database.BeginTransaction();

                await _applicationDbContext.Orders.AddAsync(model);
                await _applicationDbContext.SaveChangesAsync();
              /*_applicationDbContext.Orders.Add(new Order
                {
                    ClientId = model.ClientId,
                    Total = model.Total,
                    Date = model.Date
                });
                _applicationDbContext.SaveChanges();
                

                foreach(var item in model.Items)
                {
                    await _applicationDbContext.OrderDetail.AddAsync( new OrderDetail
                    {
                        OrderId = model.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    });
                }

                await _applicationDbContext.SaveChangesAsync();*/
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
