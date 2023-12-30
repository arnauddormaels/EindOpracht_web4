namespace API.DTO_s.Output
{
    public class ReservationOutputDTO
    {
        public ReservationOutputDTO(int id, int nrOfPlaces, string date, string time, RestaurantOutputDTO restaurant, ClientOutputDTO client, TableOutputDTO table)
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
        public string Date { get; set; }
        public string Time { get; set; }
        public RestaurantOutputDTO Restaurant { get; set; }
        public ClientOutputDTO Client { get; set; }
        public TableOutputDTO Table { get; set; }


    }
}
