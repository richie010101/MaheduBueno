using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaheduBueno
{
    public partial class MenuAgregarUsuario : Form
    {
        public MenuAgregarUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombre=NombreU.Text;
            string apeP=ApellidoP.Text;
            string apeM=ApellidoM.Text;
            string user = userBox.Text;
            string contra=Contraseña.Text;
            string tipoU=TipoUsuario.Text;


            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion1);
                String qery = "INSERT INTO Usuario (Nombres, ApellidoP, ApellidoM, UserName, Contraseña, tipoUsuario_idtipoUsuario) VALUES('"+ nombre + "','"+ apeP + "','" + apeM + "','" + user + "','" + contra + "','" + tipoU +"')";
                
                Console.WriteLine(qery);
                SqlDataAdapter ada = new SqlDataAdapter(qery, con);

                con.Open();

                DataSet data = new DataSet();

              

             

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
