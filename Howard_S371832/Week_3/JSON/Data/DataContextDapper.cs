using System.Data;
using Dapper;
using JSON.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JSON.Data
{
  public class DataContextDapper(IConfiguration config)
  {
    private readonly string _connectionString = config.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    public IEnumerable<T> LoadData<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Query<T>(sql);
    }

    public T LoadDataSingle<T>(string sql)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.QuerySingle<T>(sql);
    }

    public bool ExecuteSql<T>(string sql, T parameters)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return (dbConnection.Execute(sql, parameters) > 0);
    }

    public int ExecuteSqlWithRowCount<T>(string sql, T parameters)
    {
      IDbConnection dbConnection = new SqlConnection(_connectionString);
      return dbConnection.Execute(sql, parameters);
    }
  }
}