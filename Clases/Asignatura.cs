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

        public String Insertar()
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
    }

}
