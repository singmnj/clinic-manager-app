using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class SqliteDataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public readonly string DBFile;

        public readonly string ConnectionString;

        public SqliteDataAccess(IConfiguration config)
        {
            _config = config;
            DBFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + _config.GetSection("DBFile").Value;
            ConnectionString = $"Data Source={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + _config.GetSection("DbFile").Value}";
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqliteConnection(ConnectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqliteConnection(ConnectionString))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }

        public void Setup()
        {
            if (!File.Exists(DBFile))
            {
                using (IDbConnection connection = new SqliteConnection(ConnectionString))
                {
                    connection.Execute(@"
                        CREATE TABLE patient (
                            Id        INTEGER       PRIMARY KEY AUTOINCREMENT
                                                    UNIQUE
                                                    NOT NULL,
                            FirstName VARCHAR (50)  NOT NULL,
                            LastName  VARCHAR (50)  NOT NULL,
                            Phone     VARCHAR (15),
                            Address   VARCHAR (100),
                            City      VARCHAR (50)  NOT NULL,
                            Notes     TEXT          NOT NULL
                        );
                     ");
                }
            }
        }
    }
}
