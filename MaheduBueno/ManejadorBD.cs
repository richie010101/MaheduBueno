using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaheduBueno
{
    class ManejadorBD
    {


        private String conexion = "server=localhost;port=3308;Database=mahedubueno;Uid=root;Pwd=;";
        private MySqlConnection mySqlConnection;
        


        public ManejadorBD()
        {
            mySqlConnection = new MySqlConnection(conexion);
            
        }

        public void leer(String User, String Contraseña)
        {
            mySqlConnection.Open();

            String sql = "SELECT * FROM usuario where UserName= '" + User + "' and Contraseña='" + Contraseña + "'";
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = sql;

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                new MenuPrincipal().Show();
                

            }
            else
            {
            //    System.Windows.Forms.MessageBox.Show("usuario o contraseña incorrectos, verifique");
            Form1 res = new Form1();
            res.respuesta(Form1.ActiveForm);
            }



            mySqlConnection.Close();
        }

    }
}
