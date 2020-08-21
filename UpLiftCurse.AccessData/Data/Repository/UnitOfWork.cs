using System;
using System.Collections.Generic;
using System.Text;
using UpLiftCurse.AccessData.Data.Repository.IRepository;
using UpLiftCurse.DataAccess.Data;
using UpLiftCurse.Models;

namespace UpLiftCurse.AccessData.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Frequency = new FrequencyRepository(_db);
            Service = new ServiceRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IFrequencyRepository Frequency { get; private set; }
        public IServiceRepository Service { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
