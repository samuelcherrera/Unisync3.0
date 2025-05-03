using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace Unisync.Clases
{
    public class Asignatura
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public ASIGNATURA asignatura { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        /* public String Insertar()
         {
             try
             {
                 DBUniSync.ASIGNATURAs.Add(asignatura); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                 DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                 return "Asignatura ingresado correctamente " + asignatura.NOMBRE;
             }
             catch (Exception ex)
             {
                 return "error al insertar la Asignatura " + ex.Message;
             }

         }
        */
        public String Insertar(int usuarioId) // Recibimos el ID del usuario para asociarlo
        {
            try
            {
                // Buscar el usuario por su ID
                var usuario = DBUniSync.USUARIOs.FirstOrDefault(u => u.ID_USUARIO == usuarioId);
                if (usuario == null)
                {
                    return "Usuario no encontrado.";
                }

                // Asociar la asignatura al usuario
                asignatura.USUARIOs.Add(usuario); // Agregar el usuario a la asignatura
                DBUniSync.ASIGNATURAs.Add(asignatura);
                DBUniSync.SaveChanges();
                return "Asignatura ingresada correctamente: " + asignatura.NOMBRE;
            }
            catch (Exception ex)
            {
                return "Error al insertar la Asignatura: " + ex.Message;
            }
        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            ASIGNATURA asi = ConsultarXNombreAsignatura(asignatura.NOMBRE);
            if (asi == null)
            {
                return "el documento no es valido";
            }
            DBUniSync.ASIGNATURAs.AddOrUpdate(asignatura);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado la asignatura correctamente";



        }
        public ASIGNATURA ConsultarXNombreAsignatura(String nombre)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            ASIGNATURA asi = DBUniSync.ASIGNATURAs.FirstOrDefault(e => e.NOMBRE == nombre);//consulta el empleado por documento
            return asi;
        }

        public List<ASIGNATURA> ConsultarTodos()
        {
            return DBUniSync.ASIGNATURAs
                .OrderBy(e => e.NOMBRE)
                .ToList();//consulta todos los empleados
        }

        public String Eliminar()
        {
            try
            {
                //consultamos el empleado
                ASIGNATURA asi = ConsultarXNombreAsignatura(asignatura.NOMBRE);
                if (asi == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.ASIGNATURAs.Remove(asi);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado la asignatura correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }
        }

        public String EliminarXNombreAsignatura(string nombre)
        {
            try
            {
                //consultamos el empleado
                ASIGNATURA asi = ConsultarXNombreAsignatura(nombre);
                if (asi == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.ASIGNATURAs.Remove(asi);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado la asignatura correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }


        }
        public string InsertarConUsuario(int userId)
        {
            using (var tx = DBUniSync.Database.BeginTransaction())
            {
                try
                {
                    // 1) Insertar la asignatura
                    DBUniSync.ASIGNATURAs.Add(asignatura);
                    DBUniSync.SaveChanges();

                    // 2) Asociar al usuario
                    var usuario = DBUniSync.USUARIOs.Find(userId);
                    if (usuario == null)
                        return $"Usuario con ID {userId} no encontrado.";

                    usuario.ASIGNATURAs.Add(asignatura);
                    DBUniSync.SaveChanges();

                    tx.Commit();
                    return asignatura.ID_ASIGNATURA.ToString();  // devolvemos el nuevo ID
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return "ERROR: " + ex.Message;
                }
            }
        }
    }

}
