using UniSync.Clases;
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
    [RoutePrefix("api/Tarea")]
    //[Authorize]
    public class TareasController : ApiController
    {
        //SE DEFINE EL METODO A IMPLEMENTAR (httpGet,httpPost...)
        [HttpGet]
        //LUEGO SE DEFINE LA RUTA DEL MOTODO CON Route
        [Route("ConsultarTodos")]
        //FINALMENTE SE DEFINE EL METODO QUE SE VA A EJECUTAR
        public List<USUARIO> ConsultarTodos()
        {
            //SE CREA UN OBJETO DE LA clsEmpleado
            Usuario usuario = new Usuario();

            //SE LLAMA AL METODO ConsultarTodos DE LA CLASE clsEmpleado
            return usuario.ConsultarTodos();
        }


        [HttpGet]
        [Route("ConsultarXCorreo")]
        public USUARIO ConsultarXCorreo(String correo)
        {
            Usuario usuario = new Usuario();
            return usuario.ConsultarXCorreo(correo);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] USUARIO usuario)
        {
            Usuario Usuario = new Usuario();

            //SE LE ASIGNA EL OBJETO empleado AL OBJETO empleado DE LA CLASE clsEmpleado 
            Usuario.usuario = usuario;

            return Usuario.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] USUARIO usuario)
        {
            Usuario Usuario = new Usuario();
            Usuario.usuario = usuario;
            return Usuario.Actualizar();
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] USUARIO usuario)
        {
            Usuario Usuario = new Usuario();
            Usuario.usuario = usuario;
            return Usuario.Eliminar();
        }


        [HttpDelete]
        [Route("EliminarXCorreo")]
        public string EliminarXDocumento(string correo)
        {
            Usuario Usuario = new Usuario();
            return Usuario.EliminarXCorreo(correo);
        }



    }
}