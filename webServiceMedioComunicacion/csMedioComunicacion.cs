using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace webServiceMedioComunicacion
{
    public class csMedioComunicacion
    {

        String conection = "cnConnection";
        public Int32 save(string nombre, string tipo, string pais, DateTime fecha, bool estado)
        {
            Int32 result = 0;
            string insert = "INSERT INTO medio_comunicacion(nombre_medio_comunicacion, tipo_medio_comunicacion, pais_origen, fecha_creacion, estado) values( ";

            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;
                cn.Open();

                MySqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandText += string.Format("'{0}', '{1}', '{2}', '{3}', {4} ); select last_insert_id();", nombre, tipo, pais, fecha.ToString("yyyy-MM-dd H:mm:ss"), estado);

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

    }
}