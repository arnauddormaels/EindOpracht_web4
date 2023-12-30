using BL.Interfaces;
using BL.Models;
using MiddlewareExceptionsAndLogging.Models;
using MiddlewareExceptionsAndLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTO_s;
using MiddlewareExceptionsAndLogging.Exceptions;
using System.Net;

namespace BL.Managers
{
    public class ReservationManager
    {
        private IReservationRepository reservationRepository;
        private IClientRepository clientRepository;
        private IRestaurantRepository restaurantRepository;
        private ITableRepository tableRepository;

        public ReservationManager(IReservationRepository reservationRepository, IClientRepository clientRepository, IRestaurantRepository restaurantRepository, ITableRepository tableRepository)
        {
            this.reservationRepository = reservationRepository;
            this.clientRepository = clientRepository;
            this.restaurantRepository = restaurantRepository;
            this.tableRepository = tableRepository;
        }

        public List<Reservation> GetAllReservations()
        {
            try
            {
                return reservationRepository.GetAllReservations();
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllReservations)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(GetAllReservations)));
                throw bex;
            }
        }

        public Reservation AddReservation(ReservationWithIdsDTO reservationWithIdsDTO)
        {
            try
            {
                //Opbouwen van reservation moet nog gebeuren
                Client client = clientRepository.GetClient(reservationWithIdsDTO.ClientId);
                Restaurant restaurant = restaurantRepository.GetRestaurant(reservationWithIdsDTO.RestaurantId);
                Table table;
                if (restaurantRepository.RestaurantHasFreeSpace(restaurant, reservationWithIdsDTO.NrOfPlaces, reservationWithIdsDTO.Date))
                {
                   table =  tableRepository.GetAvailableTable(restaurant.Id, reservationWithIdsDTO.NrOfPlaces, reservationWithIdsDTO.Date,reservationWithIdsDTO.Time);

                }
                else
                {
                    var ex = new DomainModelException("InDomainManager-AddReservation-NoAvailable place for reservation");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, "addReservation"));
                    ex.Error = new Error($"This restaurant doesn't have an available table at this time");
                    ex.Error.Values.Add(new PropertyInfo("restaurantId",restaurant.Id ));
                    throw ex;
                }

                Reservation reservation = new Reservation(reservationWithIdsDTO.NrOfPlaces, reservationWithIdsDTO.Date, reservationWithIdsDTO.Time, table, restaurant, client);
                return reservationRepository.AddReservation(reservation);

            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddReservation)));
                throw bex;
            }
        }

        public bool ReservationExists(int reservationId)
        {
            try
            {
                return reservationRepository.ReservationExists(reservationId);

            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ReservationExists)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(ReservationExists)));
                throw bex;
            }
        }

        public Reservation RemoveReservation(int reservationId)
        {
            try
            {
                return reservationRepository.RemoveReservation(reservationId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveReservation)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveReservation)));
                throw bex;
            }
        }

        public Reservation UpdateReservation(int reservationId, Reservation reservation)
        {
            try
            {
                return reservationRepository.UpdateReservation(reservationId, reservation);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateReservation)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(UpdateReservation)));
                throw bex;
            }
        }
    }
}
