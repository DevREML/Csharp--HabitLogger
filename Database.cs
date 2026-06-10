using Microsoft.Data.Sqlite;

class Database
{
    // create a sqlite database, if one isn't present
    public void CreateDatabase()
    {
        // Make connection with database
        using var connection = new SqliteConnection("Data Source=habitsDatabase.db"); // 
        connection.Open();
        
        // create table (if doesn't exist) 
        var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS habits (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";
        command.ExecuteNonQuery();
                
    }
  
}

// create a table in the database, where the habit will be logged

// store and retrieve data