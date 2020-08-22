using LogicLayer.DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayer.Interfaces
{
    public interface IRecordService
    {
        public IEnumerable<RecordDTO> GetRecords();
        void AddRecord(RecordDTO record);
        void ChangeRecord(RecordDTO record);
        void Dispose();
    }
}
