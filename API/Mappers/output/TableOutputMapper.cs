using API.DTO_s.Output;
using BL.Models;

namespace API.Mappers.output
{
    public class TableOutputMapper
    {
        public TableOutputDTO MapToTableDTO(Table table)
        {
            return new TableOutputDTO(table.Id, table.TableNumber, table.NrOfPlaces);
        }

        public List<TableOutputDTO> MapToTableDTOList(List<Table> tables)
        {
            List<TableOutputDTO> tableDTOs = new List<TableOutputDTO>();
            foreach (Table table in tables)
            {
                tableDTOs.Add(MapToTableDTO(table));
            }
            return tableDTOs;

        }
    }
}
