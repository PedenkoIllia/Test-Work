using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class RecordService : IRecordService
    {
        IUnitOfWork Database { get; set; }

        public RecordService(IUnitOfWork db)
        {
            Database = db;
        }

        public void AddRecord(RecordDTO rec)
        {
            Record record = CreateFromDTO(rec);

            Database.Records.Create(record);
            Database.Save();
        }

        public void ChangeRecord(RecordDTO rec)
        {
            Record record = CreateFromDTO(rec);
            Database.Records.Update(record);
        }

        public IEnumerable<RecordDTO> GetRecords()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Record, RecordDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Record>, List<RecordDTO>>(Database.Records.GetAll());
        }

        private Record CreateFromDTO(RecordDTO rec) 
        {
            Record record = new Record()
            {
                Code = rec.Code,
                Name = rec.Name
            };

            return record;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
