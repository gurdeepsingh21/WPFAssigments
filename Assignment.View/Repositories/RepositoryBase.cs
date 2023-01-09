using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment.View.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectonString;
        public RepositoryBase()
        {
            _connectonString= "Data Source=SAYANKHUTIA;Initial Catalog=Assignment;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectonString);
        }
    }
}
