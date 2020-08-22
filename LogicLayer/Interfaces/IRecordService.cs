using LogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IRecordService
    {
        public IEnumerable<RecordDTO> GetRecords();
        void AddRecord();
        void ChangeRecord(int id);
    }
}
