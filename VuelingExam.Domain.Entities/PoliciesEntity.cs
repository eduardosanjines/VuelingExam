using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Entities
{
    public class PoliciesEntity
    {
        Guid Id { get; set; }
        Decimal AmountInsured { get; set; }
        string Email { get; set; }
        DateTime InceptionDate { get; set; }
        Boolean InstallmentPayment { get; set; }
        int ClientId { get; set; }

    }
}
