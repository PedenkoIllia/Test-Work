using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using LogicLayer.DataTransferObjects;
using LogicLayer.Exceptions;
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

        public int AddRecord(RecordDTO rec)
        {
            Record record = _mapper.Map<Record>(rec);
            Database.Records.Create(record);
            Database.Save();

            return record.Id;
        }

        public void ChangeRecord(RecordDTO rec)
        {
            Record record = _mapper.Map<Record>(rec);
            Record originRec = Database.Records.Get(record.Id);
            if (originRec == null)
                throw new RecordNotFoundException($"Запись с id: {record.Id} не существует.", "IdProblem");

            originRec.Code = record.Code;
            originRec.Name = record.Name;

            Database.Records.Update(originRec);
            Database.Save();
                
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
