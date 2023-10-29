using StackExchange.Redis;

namespace ObiletCase.Core
{
    public interface IRedisContext
    {
        void Clear();
        public ConnectionMultiplexer Connect();
        Task<bool> Exists(int db, string key);
        Task<T> GetAsync<T>(int db, string key);
        public IDatabase GetDb(int db = 0);
        void Remove(int db, string key);
        Task RemoveAsync(int db, string key);
        void RemoveRange(int db, string pattern);
        Task RemoveRangeAsync(int db, string pattern);
        Task<bool> SaveAsync<T>(int db, string key, T data, TimeSpan? expiry);
    }
}