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
    //EL RoutePrefix ES UNA DIRECTIVA QUE SE DEFINE ANTES DE LA CLASE PARA DEFINIR LA RUTA VASE DE LA API
    [RoutePrefix("api/Tarea")]
    //[Authorize]
    public class TareasController : ApiController
    {
        //SE DEFINE EL METODO A IMPLEMENTAR (httpGet,httpPost...)
        [HttpGet]
        //LUEGO SE DEFINE LA RUTA DEL MOTODO CON Route
        [Route("ConsultarTodos")]
        //FINALMENTE SE DEFINE EL METODO QUE SE VA A EJECUTAR
        public List<TAREA> ConsultarTodos()
        {
            //SE CREA UN OBJETO DE LA clsEmpleado
            Tarea tarea = new Tarea();

            //SE LLAMA AL METODO ConsultarTodos DE LA CLASE clsEmpleado
            return tarea.ConsultarTodos();
        }


        [HttpGet]
        [Route("ConsultarXCorreo")]
        public TAREA ConsultarXCorreo(int id)
        {
            Tarea tarea = new Tarea();
            return tarea.Consultar(id);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TAREA tarea)
        {
            Tarea Tarea = new Tarea();

            //SE LE ASIGNA EL OBJETO empleado AL OBJETO empleado DE LA CLASE clsEmpleado 
            Tarea.tarea = tarea;

            return Tarea.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TAREA tarea)
        {
            Tarea Tarea = new Tarea();
            Tarea.tarea = tarea;
            return Tarea.Actualizar();
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] TAREA tarea)
        {
            Tarea Tarea = new Tarea();
            Tarea.tarea = tarea;
            return Tarea.Eliminar();
        }


        [HttpDelete]
        [Route("EliminarXCorreo")]
        public string EliminarXDocumento(int id)
        {
            Tarea Tarea = new Tarea();
            return Tarea.EliminarXDocumento(id);
        }



    }
}