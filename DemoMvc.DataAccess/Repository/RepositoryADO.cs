using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using DemoMVC.Utility.Extentions;
using DemoMVC.Utility;
using System.Reflection;

namespace DemoMVC.DataAccess.Repository
{
    public class RepositoryADO<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;

        public RepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var table = typeof(T).Name.Pluralize();
                var command = new SqlCommand($"SELECT * FROM {table}", connection);

                var reader = command.ExecuteReader();

                List<T> list = new List<T>();

                while (reader.Read())
                {
                    T item = Activator.CreateInstance<T>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string fieldName = reader.GetName(i);
                        object value = reader.GetValue(i);

                        PropertyInfo? property = typeof(T).GetProperty(fieldName);
                        if (property != null && value != DBNull.Value)
                        {
                            property.SetValue(item, Convert.ChangeType(value, property.PropertyType), null);
                        }
                    }

                    list.Add(item);
                }

                return list;
            }
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }
        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
