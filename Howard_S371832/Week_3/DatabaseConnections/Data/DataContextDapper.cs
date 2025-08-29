using System.Data;
using Dapper;
using DatabaseConnections.Models;
using Microsoft.Data.SqlClient;

namespace DatabaseConnections.Data
{
  public class DataContextDapper
  {
    private readonly string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;User Id=SA;Password=SQLConnect1;";

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