using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Ninject.Modules;

namespace LogicLayer.Infrastructure
{
    class ServiceWire : NinjectModule
    {
        private string connection;

        public ServiceWire(string connection)
        {
            this.connection = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<RecordUnitOfWork>().WithConstructorArgument(connection);
        }
    }
}
