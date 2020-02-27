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
    public class DivisasJsonConverter : IJsonConverter<Divisa>
    {
        public List<Divisa> ImportJson(string ApiPath)
        {
            
                var listaDivisas = new List<Divisa>();
                using (var client = new HttpClient())
                {

                    HttpResponseMessage response =
                        client.GetAsync(ApiPath).Result;
                    string contenido = response.Content.ReadAsStringAsync().Result;
                    {
                        listaDivisas = JsonConvert.DeserializeObject<List<Divisa>>(contenido);


                    }
                    return listaDivisas;
                }
                
            
            
            
        }
    }
}