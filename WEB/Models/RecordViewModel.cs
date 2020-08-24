using LogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace WEB.Models
{
    public class RecordViewModel
    {
        public IEnumerable<RecordDTO> Records { get; set; }
    }
}
