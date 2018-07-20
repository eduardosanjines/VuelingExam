using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Dto
{
    public class ClientsDto
    {
        public ClientsDto()
        {
        }

        public ClientsDto(DataRow table) { }

        public ClientsDto(Guid id, string name, string email, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
