using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDivisasTomasDominikDadal.JSonConverterService
{
    public interface IJsonConverter<T> where T: class
    {
        List<T> ImportJson(string ApiPath);
    }
}
