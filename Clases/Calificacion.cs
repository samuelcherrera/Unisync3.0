using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace Unisync.Clases
{
    public class Calificacion
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public CALIFICACION calificacion { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        public String Insertar()
        {
            try
            {
                DBUniSync.CALIFICACIONs.Add(calificacion); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                return "calificación ingresada correctamente "+ calificacion;
            }
            catch (Exception ex)
            {
                return "error al insertar la calificacion " + ex.Message;
            }

        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            CALIFICACION    cali = Consultar(calificacion.ID_CALIFICACION);
            if (cali == null)
            {
                return "el documento no es valido";
            }
            DBUniSync.CALIFICACIONs.AddOrUpdate(calificacion);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado el usuario correctamente";



        }
        public CALIFICACION Consultar(  int id)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            CALIFICACION cali = DBUniSync.CALIFICACIONs  .FirstOrDefault(e => e.ID_CALIFICACION == id);//consulta el empleado por documento
            return cali;
        }

        public List<CALIFICACION> ConsultarTodos()
        {
            return DBUniSync.CALIFICACIONs
                .OrderBy(e => e.ID_CALIFICACION)
                .ToList();//consulta todos los empleados
        }


        public String EliminarXid(int id)
        {
            try
            {
                //consultamos el empleado
                CALIFICACION    cali = Consultar(id);
                if (cali == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.CALIFICACIONs.Remove(cali);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado la calificacion correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }


        }
    }

}
