using Assignment.view.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.view.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
           
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
                using (var command=new SqlCommand())
            {
                connection.Open();
                command.Connection=connection;
                command.CommandText = "select *from [User] where email=@email and [password]=@password";
                command.Parameters.Add("@email",SqlDbType.NVarChar).Value= credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.UserName;
                validUser=command.ExecuteScalar()==null ? false : true; 

            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where email=@email";
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = username;
                using (var reader= command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            FirstName= reader[1].ToString(),
                            Password= string.Empty,
                            LastName= reader[4].ToString(),
                            Email= reader[5].ToString(),

                        };
                    }
                }
                
                

            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
