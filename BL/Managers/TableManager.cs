using BL.Interfaces;
using BL.Models;
using MiddlewareExceptionsAndLogging.Models;
using MiddlewareExceptionsAndLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class TableManager
    {
        private ITableRepository tableRepository;
        private IRestaurantRepository restaurantRepository;

        public TableManager(ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
        {
            this.tableRepository = tableRepository;
            this.restaurantRepository = restaurantRepository;
        }
        public Restaurant AddTable(int restaurantId, Table table)
        {
            try
            {
                Restaurant restaurant = restaurantRepository.GetRestaurant(restaurantId);
                restaurant.AddTable(table);
                return tableRepository.AddTable(restaurantId,table);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddTable)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(AddTable)));
                throw bex;
            }
        }
        public bool TableExists(int tableId)
        {
            try
            {
                return tableRepository.TableExists(tableId);

            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(TableExists)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(TableExists)));
                throw bex;
            }
        }

        public Restaurant RemoveTable(int tableId)
        {
            try
            {
                return tableRepository.RemoveTable(tableId);
            }
            catch (BLException ex)
            {
                ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveTable)));
                throw ex;
            }

            catch (Exception ex)
            {
                var bex = new BLException("Bussiness Layer", ex);
                bex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(RemoveTable)));
                throw bex;
            }
        }

    }
}
