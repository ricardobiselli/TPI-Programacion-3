using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Models.Users;
using Infrastructure.Data;
using Application.Interfaces;
using Domain.Models.Products;

namespace Api.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Client>> AddAsync([FromBody] Client client)
        {

            await _clientService.AddAsync(client);
            return Ok(client);


        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllAsync()
        {
            var clients = await _clientService.GetAllAsync();
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetByIdAsync([FromRoute] int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteAsync([FromRoute]int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>>UpdateAsync([FromRoute] int id, Product product)
        {
            var client = await _clientService.GetByIdAsync(id);
            await _clientService.UpdateAsync(client);
            return NoContent();
        }






    }
}
