using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace TS_04
{
    class Program
    {
        public static class RedisClient
        {
            private static ConnectionMultiplexer redis;
            private static IDatabase database;

            public static void Connect(string connectionString)
            {
                redis = ConnectionMultiplexer.Connect($"{connectionString}:19876,password=cg7bY38Ry4NjsESqKVeVXKSgD1CPc1lj,ConnectTimeout=10000,allowAdmin=true");
                database = redis.GetDatabase();
            }

            public static void Add(string key, string value)
            {
                database.SetAdd(key, value);
            }

            public static bool Exist(string key)
            {
                return database.KeyExists(key);
            }

            public static bool ExistProduct(string key, string productName)
            {
                return database.SetContains(key, productName);
            }

            public static List<string> GetProducts(string key)
            {
                return new List<string>(Array.ConvertAll(database.SetMembers(key),t=>t.ToString()));
            }
        }
        
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
            string storage;
            string product;
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
                            storage = inputLines[1];
                            product = inputLines[2];
                            RedisClient.Add(storage, product);
                            Console.WriteLine("New product set");
                            break;
                        case "get":
                            storage = inputLines[1];
                            if (RedisClient.Exist(storage))
                            {
                                List<string> products = RedisClient.GetProducts(storage);
                                foreach (string pr in products)
                                    Console.WriteLine(pr);
                            }
                            else
                            {
                                Console.WriteLine("This storage doesn't exist");
                            }
                            break;
                        case "exist":
                            storage = inputLines[1];
                            product = inputLines[2];
                            if (RedisClient.ExistProduct(storage, product))
                                Console.WriteLine($"Product {product} exists in stourage {storage}");
                            else
                                Console.WriteLine($"Product {product} doesn't exist in stourage {storage}");
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}