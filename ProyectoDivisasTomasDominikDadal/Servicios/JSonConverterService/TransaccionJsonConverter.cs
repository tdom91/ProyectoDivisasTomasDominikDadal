using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using ProyectoDivisasTomasDominikDadal.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Models;

namespace ProyectoDivisasTomasDominikDadal.Servicios.JSonConverterService
{
    public class TransaccionJsonConverter : IJsonConverter<Transaccion>
    {
        public List<Transaccion> ImportJson(string ApiPath)
        {
            var listaTransacciones = new List<Transaccion>();
            using (var client = new HttpClient())
            {

                HttpResponseMessage response =
                    client.GetAsync(ApiPath).Result;
                string contenido = response.Content.ReadAsStringAsync().Result;
                {
                    listaTransacciones = JsonConvert.DeserializeObject<List<Transaccion>>(contenido);
                    

                }
                return listaTransacciones;
            }
        }
    }
}