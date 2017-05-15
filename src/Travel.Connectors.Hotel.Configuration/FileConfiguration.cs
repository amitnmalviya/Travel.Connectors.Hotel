using System.IO;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Travel.Connectors.Hotel.Common;
using Travel.Connectors.Hotel.Configuration.Models;
using System.Reflection;

namespace Travel.Connectors.Hotel.Configuration
{
    public class FileConfiguration : Tavisca.Platform.Common.Configurations.IConfigurationProvider
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IMemoryCache memoryCache = null;
        public FileConfiguration(IHostingEnvironment env, IMemoryCache cache)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _configuration = builder.Build();

            memoryCache = cache;
        }

        public T GetGlobalConfiguration<T>(string section, string key)
        {
            T t;
            if (memoryCache == null)
            {
                t = GetConfiguration<T>(section, key);
            }
            else if (!memoryCache.TryGetValue(key, out t))
            {
                t = GetConfiguration<T>(section, key);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(ApplicationConstants.CacheTimeoutInSeconds));

                memoryCache.Set(ApplicationConstants.ConfigurationSettings, t, cacheEntryOptions);
            }
            return t;
        }

        private T GetConfiguration<T>(string section, string key)
        {
            IConfigurationSection configurationSection = _configuration.GetSection(section);
            var setting = configurationSection.Get<ConfigurationSetting>();
            return (T)GetPropValue(setting, key);
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public T GetGlobalConfiguration<T>(string applicationName, string section, string key)
        {
            return GetConfiguration<T>(section,key);
        }

        public NameValueCollection GetGlobalConfigurationAsNameValueCollection(string section, string key)
        {
            return GetConfigurationValues(section, key);

        }

        public NameValueCollection GetGlobalConfigurationAsNameValueCollection(string applicationName, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public async Task<NameValueCollection> GetGlobalConfigurationAsNameValueCollectionAsync(string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public async Task<NameValueCollection> GetGlobalConfigurationAsNameValueCollectionAsync(string applicationName, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public string GetGlobalConfigurationAsString(string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public string GetGlobalConfigurationAsString(string applicationName, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<string> GetGlobalConfigurationAsStringAsync(string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<string> GetGlobalConfigurationAsStringAsync(string applicationName, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<T> GetGlobalConfigurationAsync<T>(string section, string key)
        {
            return GetConfiguration<T>(section, key);
        }

        public async Task<T> GetGlobalConfigurationAsync<T>(string applicationName, string section, string key)
        {
            return GetConfiguration<T>(section,key);
        }

        public T GetTenantConfiguration<T>(string tenantId, string section, string key)
        {
            return GetConfiguration<T>(section, key);
        }

        public T GetTenantConfiguration<T>(string tenantId, string applicationName, string section, string key)
        {
            return GetConfiguration<T>(section, key);
        }

        public NameValueCollection GetTenantConfigurationAsNameValueCollection(string tenantId, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public NameValueCollection GetTenantConfigurationAsNameValueCollection(string tenantId, string applicationName, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public async Task<NameValueCollection> GetTenantConfigurationAsNameValueCollectionAsync(string tenantId, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public async Task<NameValueCollection> GetTenantConfigurationAsNameValueCollectionAsync(string tenantId, string applicationName, string section, string key)
        {
            return GetConfigurationValues(section, key);
        }

        public string GetTenantConfigurationAsString(string tenantId, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public string GetTenantConfigurationAsString(string tenantId, string applicationName, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<string> GetTenantConfigurationAsStringAsync(string tenantId, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<string> GetTenantConfigurationAsStringAsync(string tenantId, string applicationName, string section, string key)
        {
            return GetConfigurationValue(section, key);
        }

        public async Task<T> GetTenantConfigurationAsync<T>(string tenantId, string section, string key)
        {
            return GetConfiguration<T>(section, key);
        }

        public async Task<T> GetTenantConfigurationAsync<T>(string tenantId, string applicationName, string section, string key)
        {
            return GetConfiguration<T>(section, key);
        }

        private string GetConfigurationValue(string section, string key)
        {
            string configKeyValue = string.Empty;
            IConfigurationSection configSection = _configuration.GetSection(section);

            var configuationValues = configSection.AsEnumerable();
            foreach (var configValue in configuationValues)
            {
                if (key.Equals(configValue.Key))
                {
                    configKeyValue = configValue.Value;
                }
            }

            return configKeyValue;
        }
        private NameValueCollection GetConfigurationValues(string section, string key)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();
            IConfigurationSection configurationSection = _configuration.GetSection(section);

            foreach (var configSection in configurationSection.AsEnumerable())
            {
                if (!string.IsNullOrEmpty((key)) && configSection.Key == key)
                {
                    nameValueCollection.Add(configSection.Key, configSection.Value);
                }
                else if (string.IsNullOrEmpty(key))
                {
                    nameValueCollection.Add(configSection.Key, configSection.Value);
                }
            }

            return nameValueCollection;
        }
    }
}
