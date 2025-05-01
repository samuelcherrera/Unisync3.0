using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace Unisync.Clases
{
    public class Tarea
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public TAREA tarea { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        public String Insertar()
        {
            try
            {
                DBUniSync.TAREAs.Add(tarea); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                return "tarea ingresada correctamente " + tarea;
            }
            catch (Exception ex)
            {
                return "error al insertar la tarea " + ex.Message;
            }

        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            TAREA tar = Consultar(tarea.ID_TAREA);
            if (tar == null)
            {
                return "el horario no es valido";
            }
            DBUniSync.TAREAs.AddOrUpdate(tarea);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado la tarea correctamente";



        }
        public TAREA Consultar(int id)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            TAREA tar = DBUniSync.TAREAs.FirstOrDefault(e => e.ID_TAREA == id);//consulta el empleado por documento
            return tar;
        }

        public List<TAREA> ConsultarTodos()
        {
            return DBUniSync.TAREAs
                .OrderBy(e => e.ID_TAREA)
                .ToList();//consulta todos los empleados
        }

        public String Eliminar()
        {
            try
            {
                //consultamos el empleado
                TAREA tar = Consultar(tarea.ID_TAREA);
                if (tar == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.TAREAs.Remove(tar);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado la tarea correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }
        }

        public String EliminarXDocumento(int id)
        {
            try
            {
                //consultamos el empleado
                TAREA tar = Consultar(id);
                if (tar == null)
                {
                    return "el id no es valido";
                }
                DBUniSync.TAREAs.Remove(tar);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado la tarea correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }


        }
    }

}
