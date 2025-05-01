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
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public USUARIO usuario { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        public String Insertar()
        {
            try
            {
                DBUniSync.USUARIOs.Add(usuario); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                return "Usuario ingresado correctamente " + usuario.NOMBRE;
            }
            catch (Exception ex)
            {
                return "error al insertar el usuario " + ex.Message;
            }

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
        public USUARIO ConsultarXCorreo(String correo)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            USUARIO emp = DBUniSync.USUARIOs.FirstOrDefault(e => e.CORREO == correo);//consulta el empleado por documento
            return emp;
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
