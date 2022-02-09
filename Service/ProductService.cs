using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Getall();
        Task<Product> Get(int id);
        Task<bool> Add(Product model);
        Task<bool> Update(Product model);

        Task<bool> Delete(int id);
    }
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //obtener lista de clientes
        public async Task<IEnumerable<Product>> Getall()
        {
            var result = new List<Product>();

            try
            {
                result = await _applicationDbContext.Products.ToListAsync();
            }
            catch (Exception e)
            {

            }

            return result;
        }

        //obtener producto por id
        public async Task<Product> Get(int id)
        {
            var result = new Product();

            try
            {
                result = await _applicationDbContext.Products.SingleAsync(x => x.ProductId == id);
            }
            catch (Exception e)
            {

            }
            return result;
        }

        //agregar nuevo client
        public async Task<bool> Add(Product model)
        {
            try
            {
                await _applicationDbContext.Products.AddAsync(model);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        //actualizar cliente
        public async Task<bool> Update(Product model)
        {
            try
            {
                var orginalModel = await this.Get(model.ProductId);
                orginalModel.Name = model.Name;
                orginalModel.price = model.price;
                orginalModel.stock = model.stock;

                _applicationDbContext.Update(orginalModel);
                await _applicationDbContext.SaveChangesAsync();
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
                var product = new Product { ProductId = id };
                //_studentDbContext.Student.Attach(student);
                _applicationDbContext.Products.Remove(product);

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
