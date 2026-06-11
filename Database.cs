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

    public void InsertHabit(string date, int quantity)
    {
        using var connection = new SqliteConnection("Data Source=habitsDatabase.db");
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO habits (Date, Quantity) VALUES (@date, @quantity)";
        command.Parameters.AddWithValue("@date", date);
        command.Parameters.AddWithValue("@quantity", quantity);
        command.ExecuteNonQuery();
    }

    public void ViewHabit()
    {
        using var connection = new SqliteConnection("Data Source=habitsDatabase.db");
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM habits";
        var reader = command.ExecuteReader();
        while (reader.Read())
            {
            var date = reader["Date"].ToString();
            var quantity = int.Parse(reader["Quantity"].ToString());
            var Id = int.Parse(reader["Id"].ToString());
            Console.WriteLine($"{Id} - {date} - {quantity}");
            }
        reader.Close();
        connection.Close();
    }

    public void UpdateHabit(int Id, string date, int quantity)
    {
        using var connection = new SqliteConnection("Data Source=habitsDatabase.db");
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE habits SET Date = @date, Quantity = @quantity WHERE Id = @Id";
        command.Parameters.AddWithValue("@date", date);
        command.Parameters.AddWithValue("@quantity", quantity);
        command.Parameters.AddWithValue("@Id", Id);
        command.ExecuteNonQuery();
    }

    public void DeleteHabit(int Id)
    {
        using var connection = new SqliteConnection("Data Source=habitsDatabase.db");
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM habits WHERE Id = @Id";
        command.Parameters.AddWithValue("@Id", Id);
        command.ExecuteNonQuery();
    }
  
}