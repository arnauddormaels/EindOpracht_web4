using API.DTO_s.Input;
using BL.Models;

namespace API.Mappers.input
{
    public class TableInputMapper
    {
        public Table MapFromTableDTO(TableInputDTO tableDTO)
        {
            return new Table(tableDTO.TableNumber, tableDTO.NrOfplaces);
        }

    }
}
