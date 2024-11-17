using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Sample user data (username and password)
        Dictionary<string, string> userDatabase = new Dictionary<string, string>
        {
            { "admin", "password123" },
            { "user1", "mypassword" },
            { "guest", "guestpass" }
        };

        Console.WriteLine("Welcome to the Login System!");

        // Login attempt
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = ReadPassword();

        // Validate credentials
        if (userDatabase.ContainsKey(username) && userDatabase[username] == password)
        {
            Console.WriteLine("\nLogin successful! Welcome, " + username + "!");
        }
        else
        {
            Console.WriteLine("\nInvalid username or password. Please try again.");
        }
    }

    // Function to hide password input
    static string ReadPassword()
    {
        string password = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        return password;
    }
}
