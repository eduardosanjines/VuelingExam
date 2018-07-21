using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Dto
{
    public class PoliciesDto
    {
        public PoliciesDto(Object objeto)
        {
        }

        public PoliciesDto(Object id, Object amountInsured, Object email, Object inceptionDate, Object installmentPayment, Object clientId)
        {
            this.Id = id;
        }

        public Object Id { get; set; }
        public Object AmountInsured { get; set; }
        public Object Email { get; set; }
        public Object InceptionDate { get; set; }
        public Object InstallmentPayment { get; set; }
        public Object ClientId { get; set; }
    }
}
