using Microsoft.AspNetCore.Mvc;
using StoreCS.DAL.Abstract.Repository.Base;
using StoreCS.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ClientsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<List<Client>> GetAll()
        {
            var result = await _uow.ClientRepository.GetAllAsync(x=>true);
            return result;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            // List<Client> Clients = new List<Client>()
            // {
            //     new Client(){Id = 1, FirstName = "Oleksii"},
            //     new Client(){Id = 2, FirstName = "Dima"}
            //
            // };

            Client result = await _uow.ClientRepository.GetByIdAsync(id);

            return result;
        }

       
    }
}
