using Application.Interfaces;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Clients")]
    [ApiController]
    //[Authorize(Roles = "admin, superadmin")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("register")]
        public  ActionResult<Client> Add([FromBody] Client client)
        {

             _clientService.Add(client);
            return Ok(client);


        }

        [HttpGet]
        public  ActionResult<IEnumerable<Client>> GetAll()
        {
            var clients =  _clientService.GetAll();
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public  ActionResult<Client> GetById([FromRoute] int id)
        {
            var client =  _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public  ActionResult Delete([FromRoute] int id)
        {
            var client =  _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

             _clientService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public  ActionResult Update([FromRoute] int id, [FromBody] Client updatedClient)
        {
            var client =  _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

             _clientService.Update(id, updatedClient);
            return NoContent();
        }

        
    }
}
