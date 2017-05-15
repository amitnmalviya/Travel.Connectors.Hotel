using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.Platform.Common.Configurations;
using Travel.Connectors.Hotel.Configuration.Models;

namespace Travel.Connectors.Hotel.Configuration
{
    public class DatabaseConfiguration : IConfigurationProvider
    {
        public T GetGlobalConfiguration<T>(string section, string key)
        {
            throw new NotImplementedException();
        }

        public T GetGlobalConfiguration<T>(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection GetGlobalConfigurationAsNameValueCollection(string section, string key)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection GetGlobalConfigurationAsNameValueCollection(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<NameValueCollection> GetGlobalConfigurationAsNameValueCollectionAsync(string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<NameValueCollection> GetGlobalConfigurationAsNameValueCollectionAsync(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public string GetGlobalConfigurationAsString(string section, string key)
        {
            throw new NotImplementedException();
        }

        public string GetGlobalConfigurationAsString(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetGlobalConfigurationAsStringAsync(string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetGlobalConfigurationAsStringAsync(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetGlobalConfigurationAsync<T>(string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetGlobalConfigurationAsync<T>(string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public T GetTenantConfiguration<T>(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public T GetTenantConfiguration<T>(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection GetTenantConfigurationAsNameValueCollection(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public NameValueCollection GetTenantConfigurationAsNameValueCollection(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<NameValueCollection> GetTenantConfigurationAsNameValueCollectionAsync(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<NameValueCollection> GetTenantConfigurationAsNameValueCollectionAsync(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public string GetTenantConfigurationAsString(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public string GetTenantConfigurationAsString(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTenantConfigurationAsStringAsync(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTenantConfigurationAsStringAsync(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetTenantConfigurationAsync<T>(string tenantId, string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetTenantConfigurationAsync<T>(string tenantId, string applicationName, string section, string key)
        {
            throw new NotImplementedException();
        }
    }
}
