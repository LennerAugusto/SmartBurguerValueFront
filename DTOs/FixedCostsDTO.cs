﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class FixedCostsDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal Value { get; set; }
        public Guid? EnterpriseId { get; set; }
    }
}
