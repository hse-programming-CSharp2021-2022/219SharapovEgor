using System;
using StackExchange.Redis;

namespace TL_03
{
    public static class RedisClient
    {
        public const uint MaxCount = 5;

        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString)
        {
            redis = ConnectionMultiplexer.Connect($"{connectionString}:19876,password=cg7bY38Ry4NjsESqKVeVXKSgD1CPc1lj," +
                                                  $"ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
        }

        public static string Get(string key)
        {
            return database.ListGetByIndex(key,-1);
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Add(string key, string value)
        {
            database.ListRightPush(key, value);
            if(database.ListLength(key) > MaxCount)
            {
                database.ListLeftPop(key);
            }
        }
        public static string Back(string key)
        {
            if (database.ListLength(key) > 1)
            {
                return $"Version {database.ListRightPop(key)} has been removed";
            }
            else
            {
                database.KeyDelete(key);
                return "Application was deleted";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string query = "";
            string name;
            string newVersion;
            while (query != "exit")
            {
                Console.Write("input: ");
                query = Console.ReadLine();
                try
                {
                    string[] inputLines = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = inputLines[0];

                    switch (command)
                    {
                        case "add":
                            name = inputLines[1];
                            newVersion = inputLines[2];
                            RedisClient.Add(name, newVersion);
                            Console.WriteLine("New version set");
                            break;
                        case "back":
                            name = inputLines[1];
                            Console.WriteLine(RedisClient.Back(name));
                            break;
                        case "get":
                            name = inputLines[1];
                            if (RedisClient.Exist(name))
                            {
                                Console.WriteLine(RedisClient.Get(name));
                            }
                            else
                            {
                                Console.WriteLine("This application doesn't exist");
                            }
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}