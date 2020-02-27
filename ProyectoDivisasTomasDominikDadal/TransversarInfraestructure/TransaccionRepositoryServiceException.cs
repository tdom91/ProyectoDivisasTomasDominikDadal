using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.TransversarInfraestructure
{
    public class TransaccionRepositoryServiceException: Exception
    {
        public TransaccionRepositoryServiceException(string mensaje, Exception inner) : base(mensaje, inner)
        {


        }
    }
}