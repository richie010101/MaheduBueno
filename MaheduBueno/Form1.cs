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

    public partial class Form1 : Form
    {
        private ManejadorBD manejadorBD;
        bool click1;
        bool click2;
        public Form1()
        {
            InitializeComponent();

           
            manejadorBD = new ManejadorBD();
            click1 = false;
            click2 = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user;
            String contra;

            user = textBox1.Text;
            contra = textBox2.Text;

            
           /*
            ManejadorBD.Conectar();
            


            String consulta = "SELECT * FROM mahedu.usuario where UserName= '" + user + "' and Contraseña='" + contra + "'";
            SqlCommand cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);


            try
            {
                if (dt.Rows[0][0].ToString() != null)
                {
                    new MenuPrincipal().Show();
                    Program.form1.Hide();
                }
                else
                {
                    //    System.Windows.Forms.MessageBox.Show("usuario o contraseña incorrectos, verifique");
                    Form1 res = new Form1();
                    //Respuesta.Text = "Usuario o Contraseña incorrectos, verifique";
                    // MessageBox.Show("Usuario o contraseña incorrectos, verifique");
                    new MessageBox1().Show();

                }
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);
                //Respuesta.Text = "Usuario o Contraseña incorrectos, verifique";
                //MessageBox.Show("Usuario o contraseña incorrectos, verifique");
                new MessageBox1().Show();

            }



            //manejadorBD.leer(user, contra);
            // Respuesta.Text = "hola";
                */                                 

            new MenuPrincipal().Show();
            Program.form1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox2_CursorChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if(!click1)
            {
                textBox2.PasswordChar = '*';
                textBox2.Text = "";
                click1 = true;
                textBox2.ForeColor = Color.Black;
            }
        

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!click2)
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
