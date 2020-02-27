using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.Models
{
    public class Divisa 
    {
            public int Id { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public decimal rate { get; set; }

    }
}