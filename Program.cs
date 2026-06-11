// Calling HabitsDatabase.db

var database = new Database();
database.CreateDatabase();

// start menu 
Console.WriteLine("Welcome to the Habit Logger!");
Console.WriteLine("Press one of the following options:\n1.Insert new log occurrence\n2.View logs\n3.Update logs\n4.Delete logs");
string choosenOption = Console.ReadLine();

switch (choosenOption)
{
    case "1":
        // Ask the user for input 
        Console.WriteLine("Insert the date");
        string date = Console.ReadLine();
        
        Console.WriteLine("Insert the quantity");
        int quantity = int.Parse(Console.ReadLine());
        
        // Insert into database
        database.InsertHabit(date, quantity);
        break;
    
    case "2":
        database.ViewHabit();
        break;
    
    case "3":
        database.ViewHabit();
        Console.WriteLine("Select a Id you wish to change");
        int updatedId = int.Parse(Console.ReadLine());
        Console.WriteLine($"Choose a new date");
        string updatedDate = Console.ReadLine();
        Console.WriteLine($"Choose a new quantity");
        int updatedQuantity = int.Parse(Console.ReadLine());
        database.UpdateHabit(updatedId, updatedDate, updatedQuantity);
        break;
    
    case "4":
        database.ViewHabit();
        Console.WriteLine("Select a Id you wish to delete");
        int deletedId = int.Parse(Console.ReadLine());
        database.DeleteHabit(deletedId);
        break;
}
