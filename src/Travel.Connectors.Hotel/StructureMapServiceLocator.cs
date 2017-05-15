using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using System.Net;
using Travel.Connectors.Hotel.Common.ErrorHandling;

namespace Travel.Connectors.Hotel
{


    public class StructureMapServiceLocator : IServiceLocator
    {
        private readonly Container _container;
        public StructureMapServiceLocator(Container container)
        {
            //container.Configure(x => x.Policies.Interceptors(new ProfilerInjectorPolicy()));
            _container = container;
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            try
            {
                var output = _container.GetAllInstances(serviceType);
                return Convert(output);
            }
            catch (StructureMapException ex)
            {
                throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType(serviceType.Name, ex.Message), HttpStatusCode.InternalServerError, ex);
            }
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            try
            {
                return _container.GetAllInstances<TService>();
            }
            catch (StructureMapException ex)
            {
                throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType(typeof(TService).Name, ex.Message), HttpStatusCode.InternalServerError, ex);
            }
        }

        public object GetInstance(Type serviceType)
        {
            try
            {
                return _container.GetInstance(serviceType);
            }
            catch (StructureMapException ex)
            {
                throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType(serviceType.Name, ex.Message), HttpStatusCode.InternalServerError, ex);
            }
        }

        public object GetInstance(Type serviceType, string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return _container.GetInstance(serviceType);
                return _container.GetInstance(serviceType, key);
            }
            catch (StructureMapException ex)
            {
                //throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType($"{serviceType.Name} for key {key}", ex.Message), HttpStatusCode.InternalServerError, ex);
                throw new Exception("dependencies missing");
            }
        }

        public TService GetInstance<TService>()
        {
            try
            {
                return _container.GetInstance<TService>();
            }
            catch (StructureMapException ex)
            {
                throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType(typeof(TService).Name, ex.Message), HttpStatusCode.InternalServerError, ex);
            }
        }

        public TService GetInstance<TService>(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return _container.GetInstance<TService>();
                return _container.GetInstance<TService>(key);
            }
            catch (StructureMapException ex)
            {
                throw new DependencyException(FaultCodes.CouldNotResolveType, ErrorMessages.CouldNotResolveType($"{typeof(TService).Name} for key {key}", ex.Message), HttpStatusCode.InternalServerError, ex);
            }
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType);
        }

        private static IEnumerable<object> Convert(IEnumerable enumerable)
        {
            return enumerable.Cast<object>().ToList();
        }
    }
}
