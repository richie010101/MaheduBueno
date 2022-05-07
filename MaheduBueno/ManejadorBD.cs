using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaheduBueno
{
    class ManejadorBD
    {


        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection("SERVER=mahedu.database.windows.net;DATABASE=mahedu;USER ID=K-Dev;PASSWORD=NEBRLURIMI.1");
            conexion.Open();
            return conexion;
        }



           
            
            


    }
}
