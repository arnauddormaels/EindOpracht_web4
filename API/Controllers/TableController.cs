using API.DTO_s.Input;
using API.DTO_s.Output;
using API.Mappers.input;
using API.Mappers.output;
using BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private RestaurantInputMapper restaurantInputMapper;
        private RestaurantOutputMapper restaurantOutputMapper;
        private TableInputMapper tableInputMapper;
        private RestaurantManager restaurantManager;
        TableManager tableManager;
        public TableController(RestaurantInputMapper restaurantInputMapper, RestaurantOutputMapper restaurantOutputMapper, RestaurantManager restaurantManager, TableInputMapper tableInputMapper, TableManager tableManager)
        {
            this.restaurantInputMapper = restaurantInputMapper;
            this.restaurantOutputMapper = restaurantOutputMapper;
            this.restaurantManager = restaurantManager;
            this.tableInputMapper = tableInputMapper;
            this.tableManager = tableManager;
        }

        [HttpPost("AddTable/{restaurantId}")]
        public ActionResult<RestaurantOutputDTO> AddTable(int restaurantId , [FromBody] TableInputDTO tableInputDTO)
        {
            if (restaurantManager.RestaurantExists(restaurantId)){
               return Ok(restaurantOutputMapper.MapToRestaurantDTO( tableManager.AddTable(restaurantId,tableInputMapper.MapFromTableDTO(tableInputDTO))));
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("RemoveTable/{tableId}")]
        public ActionResult<RestaurantOutputDTO> RemoveTable(int tableId)
        {
            if (tableManager.TableExists(tableId))
            {
                return restaurantOutputMapper.MapToRestaurantDTO(tableManager.RemoveTable(tableId));
            }
            else
            {
                return NotFound();
            }

        }

    }
}
