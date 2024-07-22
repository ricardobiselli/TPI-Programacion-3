using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Models.Users;
using Infrastructure.Data;
using Application.Interfaces;
using Domain.Models.Products;
using Application.Services;
using Application.Models.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    [Authorize(Roles = "admin, superadmin")]
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
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Client updatedClient)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.UpdateAsync(id, updatedClient);
            return NoContent();
        }

        
    }
}
