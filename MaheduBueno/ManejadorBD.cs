using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaheduBueno
{
    class ManejadorBD
    {


        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection("SERVER=mahedu.database.windows.net;DATABASE=mahedu;USER ID=K-Dev;PASSWORD=NEBRLURIMI.1");
            try
            {
                
                conexion.Open();
                return conexion;
            }
            catch (Exception)
            {
                Confirmar confirmar = new Confirmar("Error en la conexion con la base de datos intenta nuevamente", "");
                DialogResult dg = confirmar.ShowDialog();
                if (dg.ToString() == "OK")
                {

                    Conectar();

                }
            }
            return conexion;
            
        }



           
            
            


    }
}
