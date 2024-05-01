using AlinaPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlinaPractice.Combiners
{
    public class DeliveryDTO
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public string Address { get; set; }
        public string Status { get; set; }

        public string Car {  get; set; }

        public string Technic {  get; set; }

        public string DeliveryStaff { get; set; } 
    }
}
