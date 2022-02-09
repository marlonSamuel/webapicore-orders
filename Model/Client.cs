using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
