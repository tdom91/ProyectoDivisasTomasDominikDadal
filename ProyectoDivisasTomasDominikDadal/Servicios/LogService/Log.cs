using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using ProyectoDivisasTomasDominikDadal.TransversarInfraestructure;

namespace ProyectoDivisasTomasDominikDadal.LogService
{
    public class Log:ILog
    {
        public void EscribirLog(string aLogear)
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Log Producción.txt");
                if (!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine($"{aLogear}  [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}]");
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"{aLogear}  [{DateTime.Now.ToString(CultureInfo.CurrentCulture)}]");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new LogServiceException("Error en LogService", ex);
            }
            
        }
    }
}