using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Linq;

public class SqliteRepository
{
    private readonly string _connectionString;

    public SqliteRepository(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
        EnsureDatabase();
    }

    public void EnsureDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var sql = @"
            CREATE TABLE IF NOT EXISTS OnlineOrders (
                Id INTEGER PRIMARY KEY,
                CustomerName TEXT,
                ProductName TEXT,
                Category TEXT,
                Price REAL,
                Quantity INTEGER
            );

            CREATE TABLE IF NOT EXISTS StoreOrders (
                Id INTEGER PRIMARY KEY,
                CustomerName TEXT,
                ProductName TEXT,
                Category TEXT,
                Price REAL,
                Quantity INTEGER
            );";

        using var command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    public List<OrderItem> LoadOnlineOrders()
    {
        return LoadOrders("OnlineOrders");
    }

    public List<OrderItem> LoadStoreOrders()
    {
        return LoadOrders("StoreOrders");
    }

    private List<OrderItem> LoadOrders(string tableName)
    {
        var result = new List<OrderItem>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var sql = $@"
            SELECT Id, CustomerName, ProductName, Category, Price, Quantity
            FROM {tableName}";

        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            result.Add(new OrderItem(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                Convert.ToDecimal(reader.GetDouble(4)),
                reader.GetInt32(5)
            ));
        }

        return result;
    }
}