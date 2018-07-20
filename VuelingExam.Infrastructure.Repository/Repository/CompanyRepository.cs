using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repository.Contracts;

namespace VuelingExam.Infrastructure.Repository.Repository
{
    public class CompanyRepository : IRepository<CompanyEntity>
    {
        public List<CompanyEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CompanyEntity GetTById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CompanyEntity GetTByUserName(CompanyEntity username)
        {
            throw new NotImplementedException();
        }
    }
}
