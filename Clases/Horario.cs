using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace Unisync.Clases
{
    public class Horario
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public HORARIO horario { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        public String Insertar()
        {
            try
            {
                DBUniSync.HORARIOs.Add(horario); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                return "horario ingresado correctamente " + horario;
            }
            catch (Exception ex)
            {
                return "error al insertar el horario " + ex.Message;
            }

        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            HORARIO hor = Consultar(horario.ID_HORARIO);
            if (hor == null)
            {
                return "el horario no es valido";
            }
            DBUniSync.HORARIOs.AddOrUpdate(horario);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado el usuario correctamente";



        }
        public HORARIO Consultar(int id)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            HORARIO hor = DBUniSync.HORARIOs.FirstOrDefault(e => e.ID_HORARIO == id);//consulta el empleado por documento
            return hor;
        }

        public List<HORARIO> ConsultarTodos()
        {
            return DBUniSync.HORARIOs
                .OrderBy(e => e.ID_HORARIO)
                .ToList();//consulta todos los empleados
        }

        public String Eliminar()
        {
            try
            {
                //consultamos el empleado
                HORARIO hor = Consultar(horario.ID_HORARIO);
                if (hor == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.HORARIOs.Remove(hor);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado el empleado correctamente";

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
                HORARIO hor = Consultar(id);
                if (hor == null)
                {
                    return "el documento no es valido";
                }
                DBUniSync.HORARIOs.Remove(hor);//actualiza el empleado de la tabla empleadoes
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
