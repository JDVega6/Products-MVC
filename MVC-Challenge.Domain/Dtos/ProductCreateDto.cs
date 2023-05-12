using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Domain.Dtos
{
    public class ProductCreateDto
    {
        public string? Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
        public DateTime DatePurchase { get; set; }
        public EntityStatus Status { get; set; }

        public ProductCreateDto()
        {
            DatePurchase = DateTime.Now;
            Status = (EntityStatus)1;
        }
    }
}
