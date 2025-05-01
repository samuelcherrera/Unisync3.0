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
    [RoutePrefix("api/Apunte")]
    //[Authorize]
    public class ApuntesController : ApiController
    {
        //SE DEFINE EL METODO A IMPLEMENTAR (httpGet,httpPost...)
        [HttpGet]
        //LUEGO SE DEFINE LA RUTA DEL MOTODO CON Route
        [Route("ConsultarTodos")]
        //FINALMENTE SE DEFINE EL METODO QUE SE VA A EJECUTAR
        public List<APUNTE> ConsultarTodos()
        {
            //SE CREA UN OBJETO DE LA clsEmpleado
            Apunte apunte = new Apunte();

            //SE LLAMA AL METODO ConsultarTodos DE LA CLASE clsEmpleado
            return apunte.ConsultarTodos();
        }


        [HttpGet]
        [Route("ConsultarXid")]
        public APUNTE ConsultarXid(int id)
        {
            Apunte apunte = new Apunte();
            return apunte.Consultar(id);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] APUNTE apunte)
        {
            Apunte Apunte = new Apunte();

            //SE LE ASIGNA EL OBJETO empleado AL OBJETO empleado DE LA CLASE clsEmpleado 
            Apunte.apunte = apunte;

            return Apunte.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] APUNTE apunte)
        {
            Apunte Apunte = new Apunte();
            Apunte.apunte = apunte;
            return Apunte.Actualizar();
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] APUNTE apunte)
        {

            Apunte Apunte = new Apunte();
            Apunte.apunte = apunte;
            return Apunte.Eliminar();
        }


        [HttpDelete]
        [Route("EliminarXCorreo")]
        public string EliminarXDocumento(int id)
        {
            Apunte Apunte = new Apunte();

            return Apunte.EliminarXDocumento(id);
        }



    }
}