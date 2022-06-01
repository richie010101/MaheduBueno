using MaheduBueno.clases2;
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
    public partial class BuscarProductos : Form
    {
       
        public BuscarProductos()
        {
            InitializeComponent();
            label2.Text = usuario.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }

        private void BuscarProductos_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion1);
                String qery = "select SKU, Nombre, Precio, Cantidad from mahedu.producto ;";
                Console.WriteLine(qery);
                SqlDataAdapter ada = new SqlDataAdapter(qery, con);

                con.Open();

                DataSet data = new DataSet();

                ada.Fill(data, "producto");

                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "producto";


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
            }

            label2.Text = usuario.Nombre + " " + usuario.apellidoP;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion1);
                String qery = "select SKU, Nombre, Precio, Cantidad from mahedu.producto where " + comboBox1.Text + " like '%" + textBox1.Text + "%';";
                Console.WriteLine(qery);
                SqlDataAdapter ada = new SqlDataAdapter(qery, con);

                con.Open();

                DataSet data = new DataSet();

                ada.Fill(data, "producto");

                dataGridView1.DataSource = data;
                dataGridView1.DataMember = "producto";

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
            }
        }

        private void BuscarProductos_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = this.ClientRectangle;

            // Punto intermedio del área cliente.
            //
            int c = r.Width / 2;

            // Establecemos la nueva posición del control Label.
            //
            label2.Location = new Point(c - label2.Width / 2, label2.Location.Y);
            label1.Location = new Point(c - label1.Width / 2, label1.Location.Y);
        }
    }
}
