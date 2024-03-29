﻿using JobBoardPlatform.BLL.Services.Session.Tokens;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace JobBoardPlatform.DAL.Repositories.Cache
{
    public abstract class CacheRepositoryCore<T> : ICacheRepository<T>
    {
        private readonly IDistributedCache cache;


        public CacheRepositoryCore(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task UpdateAsync(string entryKey, T entry)
        {
            var serialized = GetSerialized(entry);
            if (!IsSerializedEmpty(serialized))
            {
                var bytes = TryGetBytesFromSerialized(serialized);
                await cache.SetAsync(entryKey, bytes, GetOptions());
            }
        }

        public async Task<T> GetAsync(string entryKey)
        {
            var bytes = await cache.GetAsync(entryKey);
            var serialized = TrySerializedFromBytes(bytes);
            var entry = TryDeserializeEntry(serialized);
            return entry!;
        }

        public Task DeleteAsync(string entryKey)
        {
            return cache.RemoveAsync(entryKey);
        }

        protected virtual JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings();
        }

        protected abstract DistributedCacheEntryOptions GetOptions();

        private string GetSerialized(T entry)
        {
            return JsonConvert.SerializeObject(entry, GetSerializerSettings());
        }

        private byte[] TryGetBytesFromSerialized(string serialized)
        {
            if (IsSerializedEmpty(serialized))
            {
                throw CacheEntryException.UnableToUpdateEntry(serialized);
            }
            var bytes = GetBytesFromSerialized(serialized);
            return bytes;
        }

        private byte[] GetBytesFromSerialized(string serialized)
        {
            return Encoding.UTF8.GetBytes(serialized);
        }

        private string TrySerializedFromBytes(byte[]? bytes)
        {
            if (bytes == null)
            {
                throw CacheEntryException.UnableToGetDataEntry(bytes);
            }
            var serialized = GetSerializedFromBytes(bytes);
            return serialized;
        }

        private string GetSerializedFromBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        private T TryDeserializeEntry(string serialized)
        {
            var entry = JsonConvert.DeserializeObject<T>(serialized, GetSerializerSettings());
            if (entry == null)
            {
                throw CacheEntryException.UnableToGetEntryDeserialization();
            }
            return entry;
        }

        private bool IsSerializedEmpty(string serialized)
        {
            return string.IsNullOrEmpty(serialized) || serialized == "[]";
        }
    }
}
