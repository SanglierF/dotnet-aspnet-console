using System.Data;
using System.Data.SQLite;

namespace dotnet_aspnet_infrastructure.Data;

public sealed class SQLiteConnector : IDisposable
{
    private const string _DATABASE_FILE = "aspnet-console.sqlite3";

    private readonly SQLiteConnection _connection;

    public SQLiteConnector(bool seedDatabaseOnCreation = false)
    {
        bool dbExists = File.Exists(_DATABASE_FILE);
        if (!dbExists)
        {
            SQLiteConnection.CreateFile(_DATABASE_FILE);
        }

        string connectionString = $"Data Source={_DATABASE_FILE};Version=3;";
        _connection = new SQLiteConnection(connectionString);

        if (dbExists) return;

        CreateTables();
        if (seedDatabaseOnCreation)
        {
            SeedDatabase();
        }
    }

    public bool CheckConnection()
    {
        return _connection.State == ConnectionState.Open;
    }

    public bool ExecuteQuery(string sql)
    {
        _connection.Open();
        var command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();
        _connection.Close();
        return true;
    }

    private bool CreateTables()
    {
        _connection.Open();
        // varchar will likely be handled internally as TEXT
        // the (20) will be ignored
        // see https://www.sqlite.org/datatype3.html#affinity_name_examples
        string sql = "Create Table Recipes (name varchar(20), description varchar(20))";
        // you could also write sql = "CREATE TABLE IF NOT EXISTS highscores ..."
        SQLiteCommand command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();

        sql = "Insert into Recipes (name, description) values ('name', 'desc')";
        command = new SQLiteCommand(sql, _connection);
        command.ExecuteNonQuery();

        _connection.Close();
        return true;
    }

    private bool SeedDatabase()
    {
        return true;
    }

    public void Dispose()
    {
        _connection.Close();
        _connection.Dispose();
    }
}