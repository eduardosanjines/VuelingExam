using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Repository.Contracts
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetTById(string id);
        T GetTByUserName(T username);
}
}
