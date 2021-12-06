using System;
using StackExchange.Redis;

namespace TS_01
{
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

        }
    }
    
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect(connectionString);
            database = redis.GetDatabase();
        }

        public static string GetSet(string key, string value)
        {
            throw new NotImplementedException();
        }

        public static bool Exist(string key)
        {
            throw new NotImplementedException();
        }
        
        public static void Set(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}