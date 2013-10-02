namespace MongoLabSurveyor.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoLabSurveyor.Services;
    using Microsoft.Practices.Unity;

    public class ViewModelLocator : IDisposable
    {
        private readonly ContainerLocator containerLocator;
        private bool disposed;

        public ViewModelLocator()
        {
            this.containerLocator = new ContainerLocator();
        }

        public DatabaseViewModel DatabaseViewModel
        {
            get { return this.containerLocator.Container.Resolve<DatabaseViewModel>(); }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return this.containerLocator.Container.Resolve<SettingsViewModel>(); }
        }

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
                this.containerLocator.Dispose();
            }

            this.disposed = true;
        }
    }
}
