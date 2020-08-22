using DataAccessLayer.Entities;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<Record> Records { get; }
        void Save();
    }
}
