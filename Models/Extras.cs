using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class Extras
    {
        public long ExtrasId { get; set; }
        public long ProductId { get; set; }
        public string ExtrasName { get; set; }
        public double ExtrasPrice { get; set; }
    }
}
