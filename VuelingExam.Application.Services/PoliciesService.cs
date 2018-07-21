using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Application.Dto;
using VuelingExam.Application.Services.Contracts;

namespace VuelingExam.Application.Services
{
    public class PoliciesService : IService<PoliciesDto>
    {
        public List<PoliciesDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PoliciesDto GetTById(string id)
        {
            throw new NotImplementedException();
        }

        public PoliciesDto GetTByUserName(PoliciesDto username)
        {
            throw new NotImplementedException();
        }
    }
}
