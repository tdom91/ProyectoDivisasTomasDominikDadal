using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.TransversarInfraestructure
{
    public class DivisasRepositoryException: Exception
    {
        public DivisasRepositoryException(string mensaje, Exception inner) : base(mensaje, inner)
        {


        }
    }
}