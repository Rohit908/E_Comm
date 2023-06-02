using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DataAccess.Repository
{
    public class CategoryRepositoryADO : RepositoryADO<Category>, ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepositoryADO(string connectionString):base(connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Categories", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Category
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        };
                    }
                }
            }
        }

        public void Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
