using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Services.Contracts
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetTById(Guid id);
        T GetTByUserName(T username);
    }
}
