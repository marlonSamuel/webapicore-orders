using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> Getall();
        Task<Client> Get(int id);
        Task<bool> Add(Client model);
        Task<bool> Update(Client model);

        Task<bool> Delete(int id);
    }
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClientService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //obtener lista de clientes
        public async Task<IEnumerable<Client>> Getall()
        {
            var result = new List<Client>();

            try
            {
                result = await _applicationDbContext.Clients.ToListAsync();
            }
            catch (Exception e)
            {

            }

            return result;
        }

        //obtener cliente por id
        public async Task<Client> Get(int id)
        {
            var result = new Client();

            try
            {
                result = await _applicationDbContext.Clients.SingleAsync(x => x.ClientId == id);
            }
            catch (Exception e)
            {

            }
            return result;
        }

        //agregar nuevo client
        public async Task<bool> Add(Client model)
        {
            try
            {
                await _applicationDbContext.Clients.AddAsync(model);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        //actualizar cliente
        public async Task<bool> Update(Client model)
        {
            try
            {
                var orginalModel = await this.Get(model.ClientId);
                orginalModel.nombre = model.nombre;

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
                var student = new Client { ClientId = id };
                //_studentDbContext.Student.Attach(student);
                _applicationDbContext.Clients.Remove(student);

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
