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
    public class CompanyService : IService<ClientsDto>
    {
        private readonly IRepository<CompanyEntity> companyRepository;
        public CompanyService() : this(new CompanyRepository())
        {
        }
        public CompanyService(CompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public List<ClientsDto> GetAll()
        {
            throw new NotImplementedException();
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
