using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class RecordRepository : IRepository<Record>
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
            return db.Records.ToList();
        }

        public void Save() 
        {
            db.SaveChanges();
        }
    }
}
