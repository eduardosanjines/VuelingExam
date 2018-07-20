using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Application.Dto;
using VuelingExam.Application.Services.Contracts;
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repository.Contracts;
using VuelingExam.Infrastructure.Repository.Repository;

namespace VuelingExam.Application.Services
{
    public class ClientsService : IService<ClientsDto>
    {
        private readonly IRepository<ClientsEntity> clientsRepository;
        public ClientsService() : this(new ClientsRepository())
        {
        }
        public ClientsService(ClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }

        public List<ClientsDto> GetAll()
        {
            List<ClientsDto> clientsDto;
            List<ClientsEntity> clientsEntity;
            clientsEntity = clientsRepository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientsDto, ClientsEntity>());
            IMapper iMapper = config.CreateMapper();

            clientsDto = iMapper.Map<List<ClientsDto>>(clientsEntity);
            return clientsDto;
        }

        public ClientsDto GetTById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ClientsDto GetTByUserName(ClientsDto username)
        {
            throw new NotImplementedException();
        }
    }
}
