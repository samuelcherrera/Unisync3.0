using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Unisync.Models;

namespace Unisync.Clases
{
    public class Apunte
    {
        private UNISYNCEntities1 DBUniSync = new UNISYNCEntities1();// objeto de la bd que permite manipular el CRUD de los objetos generados por el entityFramework

        public APUNTE apunte { get; set; } // objeto de la clase USUARIO que permite manipular los datos del usuario

        public String Insertar()
        {
            try
            {
                DBUniSync.APUNTEs.Add(apunte); // agg un nuevo empleado a la tabla EMPLEADO (INSERT)
                DBUniSync.SaveChanges(); // guarda los cambios en la base de datos
                return "Apunte ingresado correctamente " + apunte.ETIQUETA;
            }
            catch (Exception ex)
            {
                return "error al insertar el apunte " + ex.Message;
            }

        }

        public String Actualizar()
        {
            //para corroborar que si se actualizo primero consultamos el empleado
            APUNTE apu = Consultar(apunte.ID_APUNTE);
            if (apu == null)
            {
                return "el documento no es valido";
            }
            DBUniSync.APUNTEs.AddOrUpdate(apunte);//actualiza el empleado de la tabla empleadoes
            DBUniSync.SaveChanges();
            return "se ha actualizado el apunte correctamente";



        }
        public APUNTE Consultar(int id)
        {
            //EXPRESIONES LAMBDA:funciones anonimas que permiten filtrar los datos de una tabla
            //FirstOrDefault: devuelve el primer elemento que cumpla con la condicion de la expresion lambda
            APUNTE apu = DBUniSync.APUNTEs.FirstOrDefault(e => e.ID_APUNTE == id);//consulta el empleado por documento
            return apu;
        }

        public List<APUNTE> ConsultarTodos()
        {
            return DBUniSync.APUNTEs
                .OrderBy(e => e.ID_APUNTE)
                .ToList();//consulta todos los empleados
        }

        public String Eliminar()
        {
            try
            {
                //consultamos el empleado
                APUNTE apu = Consultar(apunte.ID_APUNTE);
                if (apu == null)
                {
                    return "el id no es valido";
                }
                DBUniSync.APUNTEs.Remove(apunte);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado el apunte correctamente";

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
                APUNTE apu = Consultar(id);
                if (apu == null)
                {
                    return "el id no es valido";
                }
                DBUniSync.APUNTEs.Remove(apu);//actualiza el empleado de la tabla empleadoes
                DBUniSync.SaveChanges();
                return "se ha eliminado el apunte correctamente";

            }
            catch (Exception ex)
            {
                return ex.Message;// MENSAJE DE ERROR
            }


        }
    }

}
