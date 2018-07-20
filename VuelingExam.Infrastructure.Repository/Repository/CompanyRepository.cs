using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Domain.Entities;
using VuelingExam.Infrastructure.Repository.Contracts;
using VuelingExam.Infrastructure.Repository.Properties;

namespace VuelingExam.Infrastructure.Repository.Repository
{
    public class CompanyRepository : IRepository<CompanyEntity>
    {
        public CompanyRepository() { }

        public List<CompanyEntity> GetAll()
        {
            //List<CompanyEntity> companyEntity = null;
            string clients = RRepository.UrlClients;
            string policies = RRepository.UrlPolicies;

            if (File.Exists(clients) && File.Exists(policies)) { }

               // Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            //log.error(File.Exists(curFile));
            else
            {
                String output = JsonConvert.SerializeObject(clients, Formatting.Indented);
                File.AppendAllText("Alumno.json", output);

            }



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
