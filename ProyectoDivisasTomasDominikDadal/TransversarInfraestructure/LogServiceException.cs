using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.TransversarInfraestructure
{
    public class LogServiceException:Exception
    {
        public LogServiceException(string mensaje, Exception inner) : base(mensaje, inner)
        {


        }
    }
}