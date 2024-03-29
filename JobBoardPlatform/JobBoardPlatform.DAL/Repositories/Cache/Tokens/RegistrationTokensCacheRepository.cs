﻿using Microsoft.Extensions.Caching.Distributed;

namespace JobBoardPlatform.DAL.Repositories.Cache.Tokens
{
    public class RegistrationTokensCacheRepository : CacheRepositoryCore<RegistrationToken>
    {
        private const int CacheExpirationTimeInMinutes = 60;


        public RegistrationTokensCacheRepository(IDistributedCache cache) : base(cache)
        {

        }

        protected override DistributedCacheEntryOptions GetOptions()
        {
            return new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheExpirationTimeInMinutes));
        }
    }
}
