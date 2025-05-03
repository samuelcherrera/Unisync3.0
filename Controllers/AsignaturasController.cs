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

    [RoutePrefix("api/Asignatura")]
    //[Authorize] // Puedes habilitar la autorización si es necesario
    public class AsignaturasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ASIGNATURA> ConsultarTodos()
        {
            Asignatura asignatura = new Asignatura();
            return asignatura.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorNombre")]
        public ASIGNATURA ConsultarPorNombre(string nombre)
        {
            Asignatura asignatura = new Asignatura();
            return asignatura.ConsultarXNombreAsignatura(nombre);
        }

       /* [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ASIGNATURA asignatura)
        {
            Asignatura AsignaturaClase = new Asignatura();
            AsignaturaClase.asignatura = asignatura;
            return AsignaturaClase.Insertar();
        }*/

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ASIGNATURA asignatura)
        {
            Asignatura AsignaturaClase = new Asignatura();
            AsignaturaClase.asignatura = asignatura;
            return AsignaturaClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ASIGNATURA asignatura)
        {
            Asignatura AsignaturaClase = new Asignatura();
            AsignaturaClase.asignatura = asignatura;
            return AsignaturaClase.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarPorNombre")]
        public string EliminarPorNombre(string nombre)
        {
            Asignatura AsignaturaClase = new Asignatura();
            return AsignaturaClase.EliminarXNombreAsignatura(nombre);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ASIGNATURA asignatura, int usuarioId) // Recibimos el ID del usuario
        {
            Asignatura AsignaturaClase = new Asignatura();
            AsignaturaClase.asignatura = asignatura;
            return AsignaturaClase.Insertar(usuarioId); // Pasamos el usuarioId para asociarlo
        }


    }
}