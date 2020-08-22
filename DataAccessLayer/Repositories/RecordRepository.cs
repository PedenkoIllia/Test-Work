using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    class RecordRepository : IRepository<Record>
    {
        private RecordContext db;

        public RecordRepository(RecordContext context)
        {
            this.db = context;
        }

        public void Create(Record item)
        {
            db.Records.Add(item);
        }

        public Record Get(int id)
        {
            return db.Records.Find(id);
        }

        public void Update(Record item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Record> GetAll()
        {
            return db.Records;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> Find(Func<Record, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
