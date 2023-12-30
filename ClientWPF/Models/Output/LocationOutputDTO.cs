﻿namespace ClientWPF.Models.Output
{ 
    public class LocationOutputDTO
    {

        public int Id { get; set; }
        public int PoststalCode { get; set; }
        public string Commune { get; set; }
        public string? StreetName { get; set; }
        public string? HouseNumebr { get; set; }
        public LocationOutputDTO(int id, int poststalCode, string commune, string? streetName, string? houseNumebr)
        {
            Id = id;
            PoststalCode = poststalCode;
            Commune = commune;
            StreetName = streetName;
            HouseNumebr = houseNumebr;
        }

        public override string? ToString()
        {
            return $"Location id = {Id}" +
                $"\nAddress = {Commune}|{PoststalCode}|{StreetName}|{HouseNumebr}";
        }
    }
}
