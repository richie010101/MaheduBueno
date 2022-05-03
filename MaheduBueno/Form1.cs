using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();

           
            manejadorBD = new ManejadorBD();
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


            manejadorBD.leer(user, contra);
            Respuesta.Text = "hola";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        public void respuesta(object sender)
        {
            Console.WriteLine("si llega");
            Respuesta.Text = "Usuario o Contraseña incorrectos, verifique";
            //mostrar();
            
        }

        public void mostrar(object sender)
        {
            Respuesta.Text = "Usuario o Contraseña incorrectos, verifique";
        }
    }
}
