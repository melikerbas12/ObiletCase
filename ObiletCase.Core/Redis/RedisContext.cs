using Newtonsoft.Json;
using StackExchange.Redis;

namespace ObiletCase.Core
{
    public class RedisContext : IRedisContext
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly IServer _server;

        public RedisContext(string host)
        {
            var options = ConfigurationOptions.Parse(host);
            options.ConnectRetry = 5;
            options.AbortOnConnectFail = false;
            // options.AllowAdmin = true;

            _connectionMultiplexer = ConnectionMultiplexer.Connect(options);

            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                _server = Connect().GetServer(endpoint);
            }
        }

        public ConnectionMultiplexer Connect()
        {
            return _connectionMultiplexer;
        }

        public IDatabase GetDb(int db = 0) => Connect().GetDatabase(db);

        public async Task<bool> Exists(int db, string key) => await GetDb(db).KeyExistsAsync(key);

        public async Task<bool> SaveAsync<T>(int db, string key, T data, TimeSpan? expiry)
        {
            var value = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //MetadataPropertyHandling = MetadataPropertyHandling.Ignore
            });
            return await GetDb(db).StringSetAsync(key, value, expiry);
        }

        public async Task<T> GetAsync<T>(int db, string key)
        {
            var data = await GetDb(db).StringGetAsync(key);

            if (data.IsNullOrEmpty)
                return default(T);

            return JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
        }

        public async Task RemoveAsync(int db, string key)
        {
            await GetDb(db).KeyDeleteAsync(key, CommandFlags.FireAndForget);
        }

        public async Task RemoveRangeAsync(int db, string pattern)
        {
            //"NAP:users:*:menu*"
            var result = _server.Keys(db, pattern: pattern);

            foreach (var key in result)
            {
                await GetDb(db).KeyDeleteAsync(key, CommandFlags.FireAndForget);
            }
        }

        public void Remove(int db, string key)
        {
            GetDb(db).KeyDelete(key, CommandFlags.FireAndForget);
        }

        public void RemoveRange(int db, string pattern)
        {
            //"NAP:users:*:menu*"
            var result = _server.Keys(db, pattern: pattern);

            foreach (var key in result)
            {
                GetDb(db).KeyDelete(key, CommandFlags.FireAndForget);
            }
        }

        public void Clear()
        {
            _server.FlushAllDatabases();
        }
    }
}