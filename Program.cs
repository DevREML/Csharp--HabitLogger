// Calling HabitsDatabase.db

var database = new Database();
database.CreateDatabase();

// Variables 
string choosenOption;

do
{
    Console.WriteLine("Welcome to the Habit Logger!");
    Console.WriteLine(
        "Press one of the following options:\n0.Exit\n1.Insert new log occurrence\n2.View logs\n3.Update logs\n4.Delete logs");
    choosenOption = Console.ReadLine();

    switch (choosenOption)
    {
        case "1":
            // Ask the user for input 
            Console.WriteLine("Insert the date");
            string date = Console.ReadLine();

            int quantity = GetValidInt("Insert the quantity");

            // Insert into database
            database.InsertHabit(date, quantity);
            
            // Wait for input to show menu again 
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            
            break;

        case "2":
            // Viewing the database
            database.ViewHabit();
            // Wait for input to show menu again 
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "3":
            // Updating the database
            database.ViewHabit();
            int updatedId = GetValidInt("Select the Id you wish to change");
            Console.WriteLine($"Choose a new date");
            string updatedDate = Console.ReadLine();
            int updatedQuantity = GetValidInt("Choose a new quantity");
            database.UpdateHabit(updatedId, updatedDate, updatedQuantity);
            
            // Wait for input to show menu again 
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "4":
            // Delete data from database
            database.ViewHabit();
            int deletedId = GetValidInt("Select the Id you wish to delete");
            database.DeleteHabit(deletedId);
            
            // Wait for input to show menu again 
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "0":
            Console.WriteLine("Goodbye");
            break;

    }
} while (choosenOption != "0");


// Method to check for valid input for int. 
    int GetValidInt(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            try
            {
                return int.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }

    }
