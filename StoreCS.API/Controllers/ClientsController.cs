using Microsoft.AspNetCore.Mvc;
using StoreCS.API.DTOs;
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
            var result = await _uow.ClientRepository.GetAllAsync(x => true);
            return result;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<Client> GetClientById(int id)
        {
            Client result = await _uow.ClientRepository.GetByIdAsync(id);

            return result;
        }

        // іменинники
        [HttpGet("/birthday/{date}")]
        public async Task<List<ClientBirthdayDto>> GetClientsByBirthday(string date)
        {
            var clients = await _uow.ClientRepository
                .GetAllAsync(x => x.BirthDate?.ToString("yyyy-MM-dd") == date);

            var result = clients.Select(x => new ClientBirthdayDto() { Id = x.Id, Name = x.FirstName }).ToList();

            return result;
        }


        [HttpGet("/lastClients/{nDays}")]
        public async Task<List<ClientLastBuyersDto>> GetClientsWhichBuySomethingForNDays(int nDays)
        {
            var startDate = DateTime.Now.AddDays(-nDays);

            var clients = await _uow.ClientRepository
                .GetAllAsync(x => x.Orders.Any(o => startDate <= o.BoughtDate));

            var result = clients.Select(x => new ClientLastBuyersDto()
            {
                Id = x.Id,
                Name = x.FirstName,
                LastPurchaseDate = x.Orders!.LastOrDefault()!.BoughtDate
            }).ToList();

            return result;
        }

        [HttpGet("/PopularCategory/{id}")]
        public async  Task<ActionResult<List<ClientCategoryQuantityDto>>> GetPopularCategory(int id)
        {
            var client = await _uow.ClientRepository.GetByIdAsync(id);
            if (client == null) return BadRequest($"There is no client with id: {id}");

            var productCategories = client.Orders
                .SelectMany(o => o.OrderItems)
                .GroupBy(oi => oi.Product.Category)
                .Select(group => new ClientCategoryQuantityDto()
                {
                    Category = group.Key?.Name,
                    Quantity = (int)group.Sum(oi => oi.Quantity)
                })
                .ToList();
            
            if(productCategories.Count == 0) 
                return BadRequest($"There are no popular product categories for client with id: {id}");

            return Ok(productCategories);
        }
    }
}
