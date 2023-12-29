using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace DemCuu.Models
{
    public static class DbContext
    {
        static MySqlConnection connection = null;

        public static MySqlConnection GetConnection()
        {
            if(connection == null)
            {
                connection = new MySqlConnection("server=127.0.0.1;Database=bai4;uid=root;pwd=hieutq");
            }
            
            return connection;
        }

        public static QueryFactory db = null;

        public static QueryFactory GetQueryFactory()
        {
            if(db == null)
            {
                var compiler = new MySqlCompiler();
                db = new QueryFactory(GetConnection(), compiler);
            }

            return db;
        }
    }
}
