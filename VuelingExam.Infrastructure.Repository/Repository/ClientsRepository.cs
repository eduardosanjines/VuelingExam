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
        private readonly VuelingExamEntities db;
        LogMan log = new LogMan();
        public ClientsRepository() { }

        public List<ClientsEntity> GetAll()
        {
            List<ClientsEntity> clientsEntity = null;
            IQueryable<Clients> listClients;

            try
            {
                listClients = db.Clients;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.logError(ex);
                throw new VuelingException(RRepository.DbUpdate, ex);
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Clients, ClientsEntity>());
            IMapper iMapper = config.CreateMapper();

            clientsEntity = iMapper.Map<List<ClientsEntity>>(listClients);

            return clientsEntity;

        }

        public ClientsEntity GetTById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ClientsEntity GetTByUserName(ClientsEntity username)
        {
            throw new NotImplementedException();
        }
    }
}
