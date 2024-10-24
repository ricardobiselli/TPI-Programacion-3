using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public ActionResult<ClientDTO> Add([FromBody] ClientDTO clientDto)
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
            var clients = _clientService.GetAll();

            if (clients == null || clients.Count == 0)
            {
                return NotFound();
            }

            var listOfClientsDto = new List<ClientDTO>();

            return Ok(listOfClientsDto);
        }

        [HttpGet("Get-One/{id}")]
        public ActionResult<ClientDTO> GetById([FromRoute] int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }
            var client = _clientService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

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
            if (client == null)
            {
                return NotFound();
            }

            _clientService.Delete(id);
            return NoContent();
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] ClientDTO clientDto)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }
            var client = _clientService.GetById(clientDto.Id);
            if (client == null )
            {
                return NotFound();
            }

            _clientService.UpdateClient(clientDto);
            return NoContent();
        }


    }
}
