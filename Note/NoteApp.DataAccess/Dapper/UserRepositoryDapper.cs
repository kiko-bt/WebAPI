using Dapper;
using Dapper.Contrib.Extensions;
using NoteApp.DataModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NoteApp.DataAccess.Dapper
{
    public class UserRepositoryDapper : IRepository<UserDTO>
    {
        private readonly string _connectionString;

        public UserRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }



        public void Add(UserDTO entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(entity);
            }
        }

        public void Delete(UserDTO entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(entity);
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                List<UserDTO> result = connection.Query<UserDTO>("SELECT * FROM Users").ToList();
                return result;
            }
        }

        public UserDTO GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                UserDTO result = connection.Query<UserDTO>($"SELECT * FROM Users WHERE ID = {id}").SingleOrDefault();
                return result;
            }
        }

        public void Update(UserDTO entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(entity);
            }
        }
    }
}
