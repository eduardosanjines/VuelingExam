using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Dto
{
    public class ClientsDto
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string role { get; set; }
    }
}
