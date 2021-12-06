using System;
using StackExchange.Redis;

namespace TSS_011
{
        
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com:19876,password=cg7bY38Ry4NjsESqKVeVXKSgD1CPc1lj,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
        }

        public static string GetSet(string key, string value)
        {
            return database.StringGetSet(key, value);
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Set(string key, string value)
        {
            database.StringSet(key, value);
        }
        public static string Get(string key)
        {
            return database.StringGet(key);
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

            string query;
            int i = 0;
            while (i++ < 10)
            {
                Console.WriteLine("input: ");
                query = Console.ReadLine();

                string[] inputLines = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputLines[0];
                string newVersion = inputLines[1];

                if (RedisClient.Exist(name))
                {
                    Console.WriteLine(RedisClient.Get(name));
                    Console.WriteLine(RedisClient.GetSet(name, newVersion));
                }
                else
                {
                    RedisClient.Set(name, newVersion);
                    Console.WriteLine("newVersion set");
                }
            }
        }
    }

}