using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPI_P3.Controllers;


namespace Api.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    [Authorize]

    public class ClientController : RoleCheckController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("Register-Client")]
        [AllowAnonymous]
        public ActionResult<AddClientDTO> Add([FromBody] AddClientDTO clientDto)
        {
            var newClient = _clientService.Add(clientDto);
            return Ok(newClient);
        }

        [HttpGet("Get-All")]
        public ActionResult<List<ClientDTO>> GetAll()
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var clients = _clientService.GetAll()
                .Where(c => c.State == EntitiesState.Active)
                .Select(ClientDTO.Create)
                .ToList();

            if (!clients.Any())
            {
                return NotFound(new { message = "No active clients found" });
            }

            return Ok(clients);
        }


        [HttpGet("Get-One/{id}")]
        public ActionResult<ClientDTO> GetById([FromRoute] int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var client = _clientService.GetById(id);
            var clientDto = ClientDTO.Create(client);
            return Ok(clientDto);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var client = _clientService.GetById(id);
            _clientService.Delete(id);
            return NoContent();
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] ClientUpdateDto clientDto)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            _clientService.UpdateClient(clientDto);
            return NoContent();
        }

    }
}
