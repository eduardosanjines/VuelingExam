using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Entities
{
    public class PoliciesEntity
    {
        string Id { get; set; }
        Decimal AmountInsured { get; set; }
        string Email { get; set; }
        DateTime InceptionDate { get; set; }
        Boolean InstallmentPayment { get; set; }
        public string ClientId { get; set; }

    }
}
