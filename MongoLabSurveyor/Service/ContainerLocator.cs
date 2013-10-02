namespace MongoLabSurveyor.Services
{
    using System.ComponentModel;
    using System.Device.Location;
    using System;
    using System.Windows;
    using Microsoft.Practices.Unity;
    using MongoLabSurveyor.Contracts;
    using MongoLabSurveyor.Service;
    using MongoLabSurveyor.Adapters;
    using Microsoft.Phone.Controls;
    using MongoLabSurveyor.Services;

    public class ContainerLocator : IDisposable
    {
        private bool disposed;

        public ContainerLocator()
        {
            this.Container = new UnityContainer();
            this.ConfigureContainer();
        }

        public IUnityContainer Container { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.Container.Dispose();
            }

            this.disposed = true;
        }

        private void ConfigureContainer()
        {
            Container.RegisterTypes(AllClasses.FromApplication(false, false),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.ContainerControlled
                                );
        }
    }
}
