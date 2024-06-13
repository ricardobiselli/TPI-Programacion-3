using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Models.Users;
using Infrastructure.Data;
using Application.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterClient([FromBody] Client client)
        {
            
                await _clientService.AddAsync(client);
                return Ok(client);
            

        }
    }
}
