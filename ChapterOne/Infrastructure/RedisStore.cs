using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChapterOne.Infrastructure
{
    public sealed class RedisStore
    {
        private static RedisStore instance = null;
        private static readonly object redisStoreLock = new object();
        private ConnectionMultiplexer connection;
        private IDatabase redisCache;

        RedisStore()
        {
            var configurationOptions = new ConfigurationOptions{
                EndPoints = {ConfigurationManager.AppSettings["redis.connection"]}
            };
            connection = ConnectionMultiplexer.Connect(configurationOptions);
            redisCache = connection.GetDatabase();
        }

        public static RedisStore Instance
        {
            get
            {
                lock (redisStoreLock)
                {
                    if (instance == null)
                    {
                        instance = new RedisStore();
                    }
                    return instance;
                }
            }
        }

        public ConnectionMultiplexer Connection
        {
            get
            {
                return connection;
            }
        }

        public IDatabase RedisCache
        {
            get
            {
                return redisCache;
            }
        }
    }
}