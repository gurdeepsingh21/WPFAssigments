using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace Assignment.view.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=(Localdb)\trishitadb;Initial Catalog=Users;Integrated Security=True;Pooling=False";


        }
        protected SqlConnection GetConnection()
        {
          return new SqlConnection(_connectionString);
        }
    }
}
