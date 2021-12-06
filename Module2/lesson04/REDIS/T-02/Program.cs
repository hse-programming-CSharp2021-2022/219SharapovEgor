using System;
using StackExchange.Redis;

namespace T_02
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect($"{connectionString},allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer(connectionString, 6379);
        }

        public static void AddOne(string key)
        {
            throw new NotImplementedException();
        }

        public static void RemoveOne(string key)
        {
            throw new NotImplementedException();
        }

        public static bool Exist(string key)
        {
            throw new NotImplementedException();
        }

        public static long GetAsLong(string key)
        {
            throw new NotImplementedException();
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

        }
    }
}