using System;
using StackExchange.Redis;

namespace TS_022
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com:19876,password=cg7bY38Ry4NjsESqKVeVXKSgD1CPc1lj,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com", 19876);
        }

        public static void AddOne(string key)
        {
            if (Exist(key))
            {
                database.StringIncrement(key);
            }
            else
            {
                database.StringSet(key, 1);
            }
        }

        public static void RemoveOne(string key)
        {
            if (database.StringDecrement(key) <= 0)
            {
                database.KeyDelete(key);
            }
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static long GetAsLong(string key)
        {
            return (long)database.StringGet(key);
        }
        
        public static string[] GetKeys(string keyBeginning = "")
        {
            return server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string command;
            Console.WriteLine(@"Input command (add/remove/show) 
            Or input empty line to exit");
            while ((command = Console.ReadLine()) != "exit")
            {
                string productName;
                switch (command)
                {
                    case "add":
                        Console.Write("Input product name: ");
                        productName = Console.ReadLine();

                        RedisClient.AddOne($"TaskInt_{productName}");
                        Console.WriteLine("Ok.");
                        break;

                    case "remove":
                        Console.Write("Input product name: ");
                        productName = Console.ReadLine();

                        if (RedisClient.Exist($"TaskInt_{productName}"))
                        {
                            RedisClient.RemoveOne($"TaskInt_{productName}");
                            Console.WriteLine("Ok.");
                        }
                        else
                        {
                            Console.WriteLine("This product is not in warehouse.");
                        }
                        break;

                    case "show":
                        string[] keys = RedisClient.GetKeys("TaskInt_");
                        foreach (var key in keys)
                        {
                            long count = RedisClient.GetAsLong(key);
                            Console.WriteLine($"{key.Replace("TaskInt_", "")}: {count} items.");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }

        }
    }
}