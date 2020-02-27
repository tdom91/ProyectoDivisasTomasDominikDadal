using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.Models
{
    public class Transaccion
    {
            public int Id { get; set; }
            public string sku { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }

    }
}