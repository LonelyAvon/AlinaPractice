using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlinaPractice.Combiners
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string Application {  get; set; }
        
        public string Delivery { get; set; }

        public string Status { get; set; }

        public int Cost { get; set; }

        public string Client {  get; set; }
    }
}
