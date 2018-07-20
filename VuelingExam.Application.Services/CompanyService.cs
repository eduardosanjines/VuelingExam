using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Application.Dto;
using VuelingExam.Application.Services.Contracts;

namespace VuelingExam.Application.Services
{
    public class CompanyService : IService<ClientsDto>
    {
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
