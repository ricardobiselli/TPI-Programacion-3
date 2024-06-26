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

        /*[HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] ClientUpdateDto updatedClient)
        {
            if (id != updatedClient.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingClient = await _clientService.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            try
            {
                // Update the existing client with the new data
                existingClient.UserName = updatedClient.UserName;
                existingClient.Email = updatedClient.Email;
                existingClient.FirstName = updatedClient.FirstName;
                existingClient.LastName = updatedClient.LastName;
                existingClient.DniNumber = updatedClient.DniNumber;
                existingClient.Address = updatedClient.Address;

                // Now update with the modified client object
                await _clientService.UpdateAsync(existingClient);

                // Return the updated client data
                return Ok(existingClient);
            }
            catch (Exception ex)
            {
                // Log the exception
                //_logger.LogError(ex, "An error occurred while updating client with ID {ClientId}", id);
                return StatusCode(500, "An error occurred while updating the client");
            }
        }*/

    }
}
