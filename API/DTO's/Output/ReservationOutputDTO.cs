namespace API.DTO_s.Output
{
    public class ReservationOutputDTO
    {
        public ReservationOutputDTO(int id, int nrOfPlaces, DateOnly date, TimeOnly time, RestaurantOutputDTO restaurant, ClientOutputDTO client, TableOutputDTO table)
        {
            Id = id;
            NrOfPlaces = nrOfPlaces;
            Date = date;
            Time = time;
            Restaurant = restaurant;
            Client = client;
            Table = table;
        }

        public int Id { get; set; }
        public int NrOfPlaces { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public RestaurantOutputDTO Restaurant { get; set; }
        public ClientOutputDTO Client { get; set; }
        public TableOutputDTO Table { get; set; }


    }
}
