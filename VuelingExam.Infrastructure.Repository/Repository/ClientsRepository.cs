using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Layer;
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repository.Contracts;
using VuelingExam.Infrastructure.Repository.DataModel;
using VuelingExam.Infrastructure.Repository.Properties;

namespace VuelingExam.Infrastructure.Repository.Repository
{
    public class ClientsRepository : IRepository<ClientsEntity>
    {
        //private readonly VuelingExamEntities db;
        //LogMan log = new LogMan();
        public ClientsRepository() { }

        public List<ClientsEntity> GetAll()
        {
            List<ClientsEntity> clientsEntity = null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientsEntity, PoliciesEntity>());
            IMapper iMapper = config.CreateMapper();

            var en = iMapper.Map<List<ClientsEntity>>(clientsEntity);

            return en;

        }

        public ClientsEntity GetTById(string id)
        {
            throw new NotImplementedException();
        }

        public ClientsEntity GetTByUserName(ClientsEntity username)
        {
            throw new NotImplementedException();
        }
    }
}
