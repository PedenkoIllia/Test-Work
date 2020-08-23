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
        private readonly IMapper _mapper;


        public RecordService(IUnitOfWork db, IMapper mapper)
        {
            Database = db;
            _mapper = mapper;
        }

        public RecordDTO GetRecord(int id)
        {
            Record rec = Database.Records.Get(id);
            if (rec == null)
                return null;

            return _mapper.Map<RecordDTO>(rec);
        }

        public void AddRecord(RecordDTO rec)
        {
            Record record = _mapper.Map<Record>(rec);
            Database.Records.Create(record);
            Database.Save();
        }

        public void ChangeRecord(RecordDTO rec)
        {
            Record record = _mapper.Map<Record>(rec);
            Database.Records.Update(record);
        }

        public IEnumerable<RecordDTO> GetRecords()
        {
            return _mapper.Map<List<RecordDTO>>(Database.Records.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
