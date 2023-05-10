using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Challenge.Domain.Dtos
{
    public enum EntityTypeOption
    {
        Property = 0,
        vehicles,
        land,
        apartments
    }
    public enum EntityStatus
    {
        Inactivo,
        Activo
    }
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
        public DateTime DatePurchase { get; set; }
        public EntityStatus Status { get; set; }
    }
}
