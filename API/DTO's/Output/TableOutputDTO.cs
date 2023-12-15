namespace API.DTO_s.Output
{
    public class TableOutputDTO
    {
  

        public int Id { get; set; } 
        public int TableNumber { get; set; }
        public int NrOfplaces { get; set; }
        public TableOutputDTO(int id, int tableNumber, int nrOfplaces)
        {
            Id = id;
            TableNumber = tableNumber;
            NrOfplaces = nrOfplaces;
        }

    }
}
