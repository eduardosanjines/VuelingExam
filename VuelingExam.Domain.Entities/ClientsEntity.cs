﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Entities
{
    public class ClientsEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Role { get; set; }
    }
}
