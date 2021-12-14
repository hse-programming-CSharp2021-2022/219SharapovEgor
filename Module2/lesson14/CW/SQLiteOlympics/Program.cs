using System;
using Microsoft.Data.Sqlite;

namespace SQLPrac
{
    class Program
    {
        // Put your SQL queries here:
        private static string task01 = "SELECT name, area_sqkm FROM Countries WHERE area_sqkm > 1000000";
        private static string task02 = "SELECT c.name, o.year, o.city FROM Olympics o JOIN Countries c ON o.country_id = c.country_id";
        private static string task03 = "SELECT name FROM Players WHERE name LIKE 'Mi%'";
        private static string task04 = "SELECT e.name FROM Events e " +
                                       "JOIN Olympics o ON e.olympic_id = o.olympic_id " +
                                       "WHERE o.year = 2000";
        private static string task05 = "SELECT p.name, r.result, e.result_noted_in FROM Results r " +
                                       "JOIN Players p ON p.player_id = r.player_id " +
                                       "JOIN Events e ON r.event_id = e.event_id " +
                                       "JOIN Olympics o ON e.olympic_id = o.olympic_id " +
                                       "WHERE r.medal ='GOLD' AND o.year = 2004";
        private static string task06 = "SELECT c.name, count(*) FROM Results r " +
                                       "JOIN Players p ON p.player_id = r.player_id " +
                                       "JOIN Countries c ON p.country_id = c.country_id " +
                                       "GROUP BY c.country_id " +
                                       "ORDER BY count(*) DESC";

        /// <summary>
        /// Executes the SQL query corresponding to the task.
        /// </summary>
        /// <param name="connection">Connection to a SQLite database</param>
        /// <param name="task">A console key that specifies the number of the ефыл to be executed</param>
        public static void ExecuteTask(SqliteConnection connection, ConsoleKey task)
        {
            switch (task)
            {
                case ConsoleKey.D1:
                    SQLUtilities.ExecuteAndPrint(connection, task01);
                    break;
                case ConsoleKey.D2:
                    SQLUtilities.ExecuteAndPrint(connection, task02);
                    break;
                case ConsoleKey.D3:
                    SQLUtilities.ExecuteAndPrint(connection, task03);
                    break;
                case ConsoleKey.D4:
                    SQLUtilities.ExecuteAndPrint(connection, task04);
                    break;
                case ConsoleKey.D5:
                    SQLUtilities.ExecuteAndPrint(connection, task05);
                    break;
                case ConsoleKey.D6:
                    SQLUtilities.ExecuteAndPrint(connection, task06);
                    break;
                default:
                    Console.WriteLine("Unknown task.");
                    break;
            }
            Console.WriteLine($"{Environment.NewLine}Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main()
        {
            using (var connection = new SqliteConnection("Data Source=olympics.db"))
            {
                connection.Open();
                do
                {
                    Console.WriteLine($"Press ESC to exit.{Environment.NewLine}");
                    Console.Write("Select task to execute [1; 6]: ");

                    ConsoleKey task = Console.ReadKey().Key;
                    if (task == ConsoleKey.Escape)
                        break;
                    Console.Clear();
                    ExecuteTask(connection, task);
                } while (true);
            }
        }
    }
}