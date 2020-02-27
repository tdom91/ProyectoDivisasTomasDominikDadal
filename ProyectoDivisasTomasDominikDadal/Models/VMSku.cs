using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.Models
{
    public class VMSku
    {
        [Key]
        public string Sku { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}