namespace MongoLabSurveyor.Unity
{
    using System;
    using Microsoft.Practices.Unity;
    using Contracts;
    using Service;

    public static class UnityHelper
    {        
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }        

        public static void RegisterTypes(IUnityContainer container)
        {            
            container.RegisterTypes(AllClasses.FromApplication(false, false),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.ContainerControlled
                                );

            container.RegisterType<IMongoLabDataService, MongoLabDataService>();
        }        
    }
}
