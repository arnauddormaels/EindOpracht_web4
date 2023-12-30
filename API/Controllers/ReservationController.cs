using API.DTO_s.Input;
using API.DTO_s.Output;
using API.Mappers.input;
using API.Mappers.output;
using BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ReservationInputMapper reservationInputMapper;
        private ReservationOutputMapper reservationOutputMapper;
        private ReservationManager reservationManager;
        private ClientManager clientManager;
        private RestaurantManager reserstaurantManager;
        private readonly ILogger logger;
        public ReservationController(ReservationInputMapper reservationInputMapper, ReservationOutputMapper reservationOutputMapper, ReservationManager reservationManager, ClientManager clientManager, RestaurantManager reserstaurantManager)
        {
            this.reservationInputMapper = reservationInputMapper;
            this.reservationOutputMapper = reservationOutputMapper;
            this.reservationManager = reservationManager;
            this.clientManager = clientManager;
            this.reserstaurantManager = reserstaurantManager;
        }

        [HttpGet("AllReservations")]
        public ActionResult<List<ReservationOutputDTO>> GetAllReservations()
        {
            //Nog eventueel controle voor als er geen reservations zijn?

            return Ok(reservationOutputMapper.MapToReservationDTOList(reservationManager.GetAllReservations()));


        }

        [HttpPost("AddReservation")]
        public ActionResult<ReservationOutputDTO> AddReservation([FromBody] ReservationInputDTO reservationInputDTO)
        {
            /*
             2024-05-12
             15:00:00.000
             
             */


            if (reservationInputDTO.ClientId == null)
            {
                var ex = new ServiceException("AddReservation");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                ex.Error = new Error("Please enter a clientId");
                ex.Error.Values.Add(new PropertyInfo("ClientId", reservationInputDTO.ClientId));
                throw ex;
            }if(reservationInputDTO.RestaurantId == null)
            {
                var ex = new ServiceException("AddReservation");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                ex.Error = new Error("Please enter a RestaurantId");
                ex.Error.Values.Add(new PropertyInfo("RestaurantId", reservationInputDTO.RestaurantId));
                throw ex;
            }
            if (!clientManager.ClientExists(reservationInputDTO.ClientId))
            {
                var ex = new ServiceException("AddReservation");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                ex.Error = new Error("this customer does not exist, please enter a valid customer");
                ex.Error.Values.Add(new PropertyInfo("CustomerId", reservationInputDTO.ClientId));
                throw ex;
            }
            if (!reserstaurantManager.RestaurantExists(reservationInputDTO.RestaurantId))
            {
                var ex = new ServiceException("AddReservation");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                ex.Error = new Error("this restuarant does not exist, please enter a valid restaurant");
                ex.Error.Values.Add(new PropertyInfo("RestaurantId", reservationInputDTO.RestaurantId));
                throw ex;
            }
            if (reservationInputDTO.NrOfPlaces == 0)
            {
                var ex = new ServiceException("AddReservation");
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                ex.Error = new Error("Nr of places must be bigger than 0");
                ex.Error.Values.Add(new PropertyInfo("nrOfplaces", reservationInputDTO.NrOfPlaces));
                throw ex;
            }

            ReservationOutputDTO reservationOutputDTO = reservationOutputMapper.MapToReservationDTO(reservationManager.AddReservation(reservationInputMapper.MapFromReservationToReservationWithIdsDTO(reservationInputDTO)));
            return Ok(reservationOutputDTO);

        }

        [HttpPut("EditReservation/{reservationId}")]
        public ActionResult<ReservationOutputDTO> UpdateReservation(int reservationId, [FromBody] ReservationInputDTO reservationInputDTO)
        {

            //TODO 
            if (reservationManager.ReservationExists(reservationId))
            {
                ReservationOutputDTO reservationOutputDTO = reservationOutputMapper.MapToReservationDTO(reservationManager.UpdateReservation(reservationId, reservationInputMapper.MapFromReservationDTO(reservationInputDTO)));
                return Ok(reservationOutputDTO);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpDelete("RemoveReservation/{reservationId}")]
        public ActionResult<ReservationOutputDTO> RemoveReservation(int reservationId)
        {
            if (reservationManager.ReservationExists(reservationId))
            {
                return reservationOutputMapper.MapToReservationDTO(reservationManager.RemoveReservation(reservationId));
            }
            else
            {
                return NotFound();
            }

        }
    }
}
