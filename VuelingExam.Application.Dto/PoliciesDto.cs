﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Dto
{
    public class PoliciesDto
    {
        Guid Id { get; set; }
        Decimal AmountInsured { get; set; }
        string Email { get; set; }
        DateTime InceptionDate { get; set; }
        Boolean InstallmentPayment { get; set; }
        int ClientId { get; set; }
    }
}
