using DemoMVC.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DataAccess.Repository.IRepository
{
    public interface ICategoryRepositoryADO : IRepository<Category>
    {
        public IEnumerable<Category> GetAll();
    }
}
