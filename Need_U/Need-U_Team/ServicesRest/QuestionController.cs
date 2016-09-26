using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebApiNeedU.Deal.Entities;

namespace ServicesRest
{
    class QuestionController
    {

        string serviceUrl = "http://need-u-app.com/api/Question/";
  public bool Insert(EntitieQuestion question)
        {
            bool resultado = (bool)ConsumirServicioRest(typeof(EntitieOptionQuestion), typeof(bool), question, serviceUrl, "Insert", "POST");
            return resultado;
        }

        private object ConsumirServicioRest(Type entidadParametros, Type entidadResultado, object valoresParametros, string serviceUrl, string operacion, string tipoOperacion)
        {
            object resultado = null;
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";

            MemoryStream memoryStream = new MemoryStream();
            DataContractJsonSerializer serializarCredencial = new DataContractJsonSerializer(entidadParametros);
            serializarCredencial.WriteObject(memoryStream, valoresParametros);

            byte[] cargarDatos = webClient.UploadData(string.Concat(serviceUrl, operacion), tipoOperacion, memoryStream.ToArray());
            Stream cargarDatosStream = new MemoryStream(cargarDatos);
            DataContractJsonSerializer serializarAutenticacion = new DataContractJsonSerializer(entidadResultado);
            resultado = serializarAutenticacion.ReadObject(cargarDatosStream);

            memoryStream.Close();
            cargarDatosStream.Close();

            return resultado;
        }
    }
}
