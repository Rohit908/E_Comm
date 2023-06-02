using DemoMVC.DataAccess.Data;
using DemoMVC.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IUnitOfWorkADO
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(string connectionString)
        {
            Category = new CategoryRepositoryADO(connectionString);
        }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
