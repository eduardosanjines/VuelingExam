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
        public ClientsDto(Object id, Object name, Object email, Object role)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Role = role;
        }

        public ClientsDto(Object[] objeto) { }

        public ClientsDto()
        {
        }

        public Object Id { get; set; }
        public Object Name { get; set; }
        public Object Email { get; set; }
        public Object Role { get; set; }
    }
}
