using Unisync.Clases;
using Unisync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Super.Controllers

{
    //EL RoutePrefix ES UNA DIRECTIVA QUE SE DEFINE ANTES DE LA CLASE PARA DEFINIR LA RUTA VASE DE LA API
    [RoutePrefix("api/Horario")]
    //[Authorize]
    public class HorariosController : ApiController
    {
        //SE DEFINE EL METODO A IMPLEMENTAR (httpGet,httpPost...)
        [HttpGet]
        //LUEGO SE DEFINE LA RUTA DEL MOTODO CON Route
        [Route("ConsultarTodos")]
        //FINALMENTE SE DEFINE EL METODO QUE SE VA A EJECUTAR
        public List<HORARIO> ConsultarTodos()
        {
            //SE CREA UN OBJETO DE LA clsEmpleado
            Horario horario = new Horario();

            //SE LLAMA AL METODO ConsultarTodos DE LA CLASE clsEmpleado
            return horario.ConsultarTodos();
        }


        [HttpGet]
        [Route("ConsultarXCorreo")]
        public HORARIO ConsultarXCorreo(int id)
        {
            Horario horario = new Horario();
            return horario.Consultar(id);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] HORARIO horario)
        {
            Horario Horario = new Horario();
            Horario.horario = horario;

            return Horario.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] HORARIO horario)
        {
            Horario Horario = new Horario();
            Horario.horario = horario;
            return Horario.Actualizar();
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] HORARIO horario)
        {
            Horario Horario = new Horario();
            Horario.horario = horario;
            return Horario.Eliminar();
        }


        [HttpDelete]
        [Route("EliminarX")]
        public string EliminarXDocumento(int id)
        {
            Horario Horario = new Horario();
            return Horario.EliminarXDocumento(id);
        }



    }
}