namespace API.DTO_s.Input
{
    public class TableInputDTO
    {
        public TableInputDTO(int tableNumber, int nrOfplaces)
        {
            TableNumber = tableNumber;
            NrOfplaces = nrOfplaces;
        }

        public int TableNumber { get; set; }
        public int NrOfplaces { get; set; }

    }
}
