using API.DTO_s.Input;
using API.DTO_s.Output;
using API.Mappers.input;
using API.Mappers.output;
using BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private RestaurantInputMapper restaurantInputMapper;
        private RestaurantOutputMapper restaurantOutputMapper;
        private RestaurantManager restaurantManager;
        public RestaurantController(RestaurantInputMapper restaurantInputMapper, RestaurantOutputMapper restaurantOutputMapper, RestaurantManager restaurantManager)
        {
            this.restaurantInputMapper = restaurantInputMapper;
            this.restaurantOutputMapper = restaurantOutputMapper;
            this.restaurantManager = restaurantManager;
        }

        [HttpGet("AllRestaurants")]
        public ActionResult<List<RestaurantOutputDTO>> GetAllRestaurants()
        {
            //Nog eventueel controle voor als er geen restaurants zijn?

            return Ok(restaurantOutputMapper.MapToRestaurantDTOList(restaurantManager.GetAllRestaurants()));
        }

        [HttpPost("AddRestaurant")]
        public ActionResult<RestaurantOutputDTO> AddRestaurant([FromBody] RestaurantInputDTO restaurantInputDTO)
        {

            RestaurantOutputDTO restaurantOutputDTO = restaurantOutputMapper.MapToRestaurantDTO(restaurantManager.AddRestaurant(restaurantInputMapper.MapFromRestaurantDTO(restaurantInputDTO)));
            return Ok(restaurantOutputDTO);



        }

        [HttpPut("EditRestaurant/{restaurantId}")]
        public ActionResult<RestaurantOutputDTO> UpdateRestaurant(int restaurantId, [FromBody] RestaurantInputDTO restaurantInputDTO)
        {
            if (restaurantManager.RestaurantExists(restaurantId))
            {
                RestaurantOutputDTO restaurantOutputDTO = restaurantOutputMapper.MapToRestaurantDTO(restaurantManager.UpdateRestaurant(restaurantId, restaurantInputMapper.MapFromRestaurantDTO(restaurantInputDTO)));
                return Ok(restaurantOutputDTO);
            }
            else
            {
                return NotFound();
            }
            //Hier kan er ook een exception gethrowed indien we een nieuw object aan een bepaalde customer willen toveogen,kijk naar p18 


        }

        [HttpDelete("RemoveRestaurant/{restaurantId}")]
        public ActionResult<RestaurantOutputDTO> RemoveRestaurant(int restaurantId)
        {
            if (restaurantManager.RestaurantExists(restaurantId))
            {
                return restaurantOutputMapper.MapToRestaurantDTO(restaurantManager.RemoveRestaurant(restaurantId));
            }
            else
            {
                return NotFound();
            }

        }


        //TODO paramters optioneel maken, hoeft niet maar kan wel (but how?)
        [HttpGet("FilterRestaurants/{keuken?}/{postalCode?}")]
        public ActionResult<List<RestaurantOutputDTO>> FilterRestaurants(string? keuken, int? postalCode )      //zouden mogen null zijn
        {

            List<RestaurantOutputDTO> outputDTOs = restaurantOutputMapper.MapToRestaurantDTOList(restaurantManager.FilterRestaurants(keuken, postalCode));
            if (outputDTOs.Count > 0)
            {
                return Ok(outputDTOs);
            }
            else
            {
                return NotFound();
            } 
        }

        [HttpGet("GetRestaurantsByDateAndNrOfPlaces/{dateString}/{nrOfPlaces}")]
        public ActionResult<List<RestaurantOutputDTO>> GetRestaurantsByDateAndNrOfPlaces(string dateString, int nrOfPlaces)       //format:  2024-05-12 
        {
            DateOnly dateonly;
            if (!DateOnly.TryParse(dateString, out dateonly))
            {
                var ex = new ServiceException("GetRestaurantsByDateAndNrOfPlacesException");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetRestaurantsByDateAndNrOfPlaces)));
                ex.Error = new Error("Please enter a valid dateString format (yyyy-mm-dd)");
                ex.Error.Values.Add(new PropertyInfo("dateString", dateString));
                throw ex;
            }
            List<RestaurantOutputDTO> outputDTOs = restaurantOutputMapper.MapToRestaurantDTOList(restaurantManager.GetRestaurantsByDateAndNrOfPlaces(dateonly, nrOfPlaces));
            if (outputDTOs.Count > 0)
            {
                return Ok(outputDTOs);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
