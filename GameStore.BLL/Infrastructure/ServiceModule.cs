using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using GameStore.DAL.Intefaces;
using GameStore.DAL.Repositories;
using AutoMapper;
using GameStore.BLL.Configuration;

namespace GameStore.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            MapperConfiguration conf = new MapperConfiguration(
             cfg =>
             {
                 cfg.AddProfile<MappingBLLProfile>();
             });

            var mapper = conf.CreateMapper();
            Bind<IMapper>().ToConstant(mapper);
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
