using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {

        /// <summary>
        /// This method will go to a table and get information out of it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"> SELECT* FROM TABLE</param>
        /// <param name="parameters">Can send everything</param>
        /// <param name="connectionString">With this we can connect with the database</param>
        /// <returns></returns>
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            // Opens a connection to the MySQL database using the connection string that was passed in.
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            
            using (IDbConnection connection = new MySqlConnection(connectionString))
            { 
               return connection.ExecuteAsync(sql, parameters);

            }
        }
    }
}
