using UniSync.Clases;

using Unisync.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using Unisync.Clases;

namespace Super.Controllers

{

    //EL RoutePrefix ES UNA DIRECTIVA QUE SE DEFINE ANTES DE LA CLASE PARA DEFINIR LA RUTA BASE DE LA API

    [RoutePrefix("api/Calificacion")]

    //[Authorize] // Puedes habilitar la autorización si es necesario

    public class CalificacionesController : ApiController

    {

        //SE DEFINE EL METODO A IMPLEMENTAR (httpGet, httpPost, etc.)

        [HttpGet]

        //LUEGO SE DEFINE LA RUTA DEL METODO CON Route

        [Route("ConsultarTodos")]

        //FINALMENTE SE DEFINE EL METODO QUE SE VA A EJECUTAR

        public List<CALIFICACION> ConsultarTodos()

        {

            //SE CREA UN OBJETO DE LA clase Calificacion

            Calificacion calificacion = new Calificacion();

            //SE LLAMA AL METODO ConsultarTodos DE LA CLASE Calificacion

            return calificacion.ConsultarTodos();

        }

        [HttpGet]

        [Route("ConsultarXId")] // Se define un parámetro en la ruta para recibir el ID

        public CALIFICACION ConsultarXId(int id)

        {

            //SE CREA UN OBJETO DE LA clase Calificacion

            Calificacion calificacion = new Calificacion();

            //SE LLAMA AL METODO Consultar DE LA CLASE Calificacion y se retorna el resultado

            return calificacion.Consultar(id);

        }

        [HttpPost]

        [Route("Insertar")]

        public string Insertar([FromBody] CALIFICACION calificacion)

        {

            //SE CREA UN OBJETO DE LA clase Calificacion

            Calificacion Calificacion = new Calificacion();

            //SE LE ASIGNA EL OBJETO calificacion AL OBJETO calificacion DE LA CLASE Calificacion

            Calificacion.calificacion = calificacion;

            return Calificacion.Insertar();

        }

        [HttpPut]

        [Route("Actualizar")]

        public string Actualizar([FromBody] CALIFICACION calificacion)

        {

            //SE CREA UN OBJETO DE LA clase Calificacion

            Calificacion Calificacion = new Calificacion();

            Calificacion.calificacion = calificacion;

            return Calificacion.Actualizar();

        }

        [HttpDelete]

        [Route("Eliminar")] // Se define un parámetro en la ruta para recibir el ID a eliminar

        public string Eliminar(int id)

        {

            //SE CREA UN OBJETO DE LA clase Calificacion

            Calificacion Calificacion = new Calificacion();

            return Calificacion.EliminarXid(id);

        }

    }

}
