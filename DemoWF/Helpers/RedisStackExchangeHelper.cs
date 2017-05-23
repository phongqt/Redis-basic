using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using StackExchange.Redis.Extensions.Newtonsoft;
using System.Linq;
using StackExchange.Redis.Extensions.Core;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DemoWF.Helpers
{
    public static class RedisStackExchangeHelper
    {
        private static string host = "localhost";
        private static int port = 6377;
        private static string password = "123456";
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        private static StackExchangeRedisCacheClient cacheClient;
        static RedisStackExchangeHelper()
        {
            if (lazyConnection == null || !lazyConnection.IsValueCreated)
            {
                lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
                {
                    ConfigurationOptions config = new ConfigurationOptions()
                    {
                        SyncTimeout = 500000,
                        EndPoints =
                        {
                        { host,port }
                        },
                        Password = password,
                        AbortOnConnectFail = false,
                        AllowAdmin = true
                    };
                    return ConnectionMultiplexer.Connect(config);
                });
            }

            var serializer = new NewtonsoftSerializer();
            cacheClient = new StackExchangeRedisCacheClient(lazyConnection.Value, serializer);
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        #region Basic
        public static void ReadData()
        {
            var cache = Connection.GetDatabase();

            var devicesCount = 10000;
            for (int i = 0; i < devicesCount; i++)
            {
                var value = cache.StringGet($"Device_Status:{i}");
                Console.WriteLine($"Valor={value}");
            }
        }

        public static List<T> GetAll<T>()
        {
            var cache = Connection.GetDatabase();
            var serializer = new NewtonsoftSerializer();
            var keys = cacheClient.SearchKeys("*").ToList();
            var list = new List<T>();
            foreach (var item in keys)
            {
                var value = cacheClient.Get<string>(item.ToString());
                var obj = JsonConvert.DeserializeObject<T>(value);
                if (obj != null)
                {
                    list.Add(obj);
                }
            }

            return list;
        }

        public static void SaveBigData<T>(List<T> list, string keyField)
        {

            #region Basic
            //var cache = Connection.GetDatabase();
            //foreach (var item in list)
            //{
            //    cache.StringSet(item.GetType().GetProperty(keyField).GetValue(item).ToString(), JsonConvert.SerializeObject(item));
            //}
            #endregion
            var values = new List<Tuple<string, string>>();
            foreach (var item in list)
            {
                values.Add(new Tuple<string, string>(item.GetType().GetProperty(keyField).GetValue(item).ToString(), JsonConvert.SerializeObject(item)));
            }

            cacheClient.AddAll(values);
        }

        public static void RemoveAll()
        {
        }
        #endregion

        #region Extentsion
        public static T Get<T>(string key)
        {
            var cache = Connection.GetDatabase();
            var r = cache.StringGet(key);
            return Deserialize<T>(r);
        }

        public static List<T> GetList<T>(string key)
        {
            return (List<T>)Get(key);
        }

        public static void SetList<T>(string key, List<T> list)
        {
            Set(key, list);
        }

        public static object Get(string key)
        {
            var cache = Connection.GetDatabase();

            return Deserialize<object>(cache.StringGet(key));
        }

        public static string GetDefault(string key)
        {
            var cache = Connection.GetDatabase();

            return cache.StringGet(key);
        }

        public static void Set(string key, object value)
        {
            var cache = Connection.GetDatabase();
            cache.StringSet(key, Serialize(value));
        }

        static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                memoryStream.Flush();
                memoryStream.Close();
                return result;
            }

        }

        public static void Increment(string key)
        {
            var cache = Connection.GetDatabase();
            cache.StringIncrement(key);
        }

        public static void Decrement(string key)
        {
            var cache = Connection.GetDatabase();
            cache.StringDecrement(key);
        }

        #endregion

        #region Member
        public static void SetMember<T>(string key, T value)
        {
            var cache = Connection.GetDatabase();
            cache.SetAdd(key, Serialize(value));
        }

        public static List<T> GetMember<T>(string key)
        {
            List<T> list = new List<T>();
            var cache = Connection.GetDatabase();
            var values = cache.SetMembers(key).ToList();
            foreach (var item in values)
            {
                list.Add(Deserialize<T>(item));
            }

            return list;
        }

        public static void RemoveMember<T>(string key, T value)
        {
            var cache = Connection.GetDatabase();
            cache.SetRemove(key, Serialize(value));
        }
        #endregion

        #region List
        public static void AddListDefault<T>(string key, T value)
        {
            var cache = Connection.GetDatabase();            
            cache.ListRightPush(key, JsonConvert.SerializeObject(value));
        }

        public static List<T> GetListDefault<T>(string key)
        {
            var list = new List<T>();
            var cache = Connection.GetDatabase();
            var values = cache.ListRange(key).ToList();
            foreach (var item in values)
            {
                list.Add(JsonConvert.DeserializeObject<T>(item));
            }
            
            return list;
        }

        public static void InsertIntoList<T>(string key, T value)
        {
            var cache = Connection.GetDatabase();
            var list = cache.ListRange(key).ToList();
            if (list.Count ==0)
            {
                AddListDefault(key, value);
            }
            
        }

        private static int FindIndex()
        {
            return 0;
        }
        #endregion
    }
}
