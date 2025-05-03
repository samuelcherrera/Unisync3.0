using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace UniSync.Clases
{
    public class Usuario
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();

        public USUARIO usuario { get; set; } 

        public String Insertar()
        {
            try
            {
                DBUniSync.USUARIOs.Add(usuario); 
                DBUniSync.SaveChanges(); 
                return "Usuario ingresado correctamente " + usuario.NOMBRE;
            }
            catch (Exception ex)
            {
                return "error al insertar el usuario " + ex.Message;
            }

        }
        public USUARIO ConsultarXCorreo(String correo)
        {
            
            USUARIO emp = DBUniSync.USUARIOs.FirstOrDefault(e => e.CORREO == correo);
            return emp;
        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            USUARIO usu = ConsultarXCorreo(usuario.CORREO);
            if (usu == null)
            {
                return "el documento no es valido";
            }
            DBUniSync.USUARIOs.AddOrUpdate(usuario);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado el usuario correctamente";



        }
        

        public List<USUARIO> ConsultarTodos()
        {
            return DBUniSync.USUARIOs
                .OrderBy(e => e.CORREO)
                .ToList();//consulta todos los empleados
        }

        public String Eliminar()
        {
            try
            {
                //consultamos el empleado
                USUARIO usu = ConsultarXCorreo(usuario.CORREO);
                if (usu == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.USUARIOs.Remove(usu);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado el empleado correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }
        }

        public String EliminarXCorreo(string correo)
        {
            try
            {
                //consultamos el empleado
                USUARIO usu = ConsultarXCorreo(correo);
                if (usu == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.USUARIOs.Remove(usu);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado el empleado correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }


        }
    }

}
