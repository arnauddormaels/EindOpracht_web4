using API.DTO_s.Input;
using API.DTO_s.Output;
using API.Mappers.input;
using API.Mappers.output;
using BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionsAndLogging;
using MiddlewareExceptionsAndLogging.Models;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientInputMapper clientInputMapper;
        private ClientOutputMapper clientOutputMapper;
        private ClientManager clientManager;
        public ClientController(ClientInputMapper clientInputMapper, ClientOutputMapper clientOutputMapper, ClientManager clientManager)
        {
            this.clientInputMapper = clientInputMapper;
            this.clientOutputMapper = clientOutputMapper;
            this.clientManager = clientManager;
        }

        [HttpGet("AllClients")]
        public ActionResult<List<ClientOutputDTO>> GetAllClients()
        {
             //Nog eventueel controle voor als er geen clients zijn?

                return Ok(clientOutputMapper.MapToClientDTOList(clientManager.GetAllClients()));
            

        }

        [HttpPost("AddClient")]
        public ActionResult<ClientOutputDTO> AddClient([FromBody] ClientInputDTO clientInputDTO)
        {
                
                ClientOutputDTO clientOutputDTO = clientOutputMapper.MapToClientDTO(clientManager.AddClient(clientInputMapper.MapFromClientDTO(clientInputDTO)));
                return Ok(clientOutputDTO);
            


        }

        [HttpPut("EditClient/{clientId}")]
        public ActionResult<ClientOutputDTO> UpdateClient(int clientId, [FromBody] ClientInputDTO clientInputDTO) {
                if (clientManager.ClientExists(clientId))
                {
                    ClientOutputDTO clientOutputDTO = clientOutputMapper.MapToClientDTO(clientManager.UpdateClient(clientId, clientInputMapper.MapFromClientDTO(clientInputDTO)));
                    return Ok(clientOutputDTO);
                }
                else
                {
                    return NotFound();
                }
                //Hier kan er ook een exception gethrowed indien we een nieuw object aan een bepaalde customer willen toveogen,kijk naar p18 

            
            }

        [HttpDelete("RemoveClient/{clientId}")]
        public ActionResult<ClientOutputDTO> RemoveClient(int clientId)
        {
                if (clientManager.ClientExists(clientId))
                {
                    return clientOutputMapper.MapToClientDTO(clientManager.RemoveClient(clientId));
                }
                else
                {
                    return NotFound();
                }
            
        }
    }
}
