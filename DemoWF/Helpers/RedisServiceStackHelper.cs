using ServiceStack.Redis;
using System.Collections.Generic;

namespace DemoWF.Helpers
{
    public class RedisServiceStackHelper
    {
        private string host = "localhost";
        private int port = 6377;
        private string password = "123456";
    
        public RedisClient ConnectServer()
        {
            return new RedisClient(host, port, password);            
        }

        public void SetObject<T>(T obj) where T : class
        {
            using (var redis = ConnectServer())
            {
                var redisUsers = redis.As<T>();
                redisUsers.Store(obj);
            }
        }

        public IList<T> GetAll<T>() where T : class
        {
            using (var redis = ConnectServer())
            {
                var redisUsers = redis.As<T>();
                return redisUsers.GetAll();
            }
        }

        public T GetByKey<T>(string key)
        {
            using (var redis = ConnectServer())
            {
                var redisUsers = redis.As<T>();
                return redisUsers.GetById(key);
            }
        }

        public void DeleteByKey<T>(T obj, string key)
        {
            using (var redis = ConnectServer())
            {
                var redisUsers = redis.As<T>();
                redisUsers.DeleteById(key);
            }
        }

        public void DeleteAll<T>()
        {
            using (var redis = ConnectServer())
            {
                var redisUsers = redis.As<T>();
                redisUsers.DeleteAll();
            }
        }
    }
}
