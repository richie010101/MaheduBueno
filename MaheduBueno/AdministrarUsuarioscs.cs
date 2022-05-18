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
    public partial class AdministrarUsuarioscs : Form
    {
        private ManejadorBD manejadorBD;
        public AdministrarUsuarioscs()
        {
            InitializeComponent();
            manejadorBD = new ManejadorBD();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MenuAgregarUsuario().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CambiarUsuario editUsuario = new CambiarUsuario();
            editUsuario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           panel2.Visible = true;
           

        }

        private void AdministrarUsuarioscs_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet2.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.maheduDataSet2.usuario);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            String qery2 = "SELECT * FROM mahedu.usuario where ContraseñaAdmin='" + textBox1.Text + "'";

            SqlCommand cmd2 = new SqlCommand(qery2, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);

            DataTable dt = new DataTable();

            adapter.Fill(dt);


            try
            {
                if (dt.Rows[0][0].ToString() != null)
                {
                    MessageBox.Show("Contraseña correcta");
                    try
                    {
                        ManejadorBD.Conectar();


                        String qery = "DELETE FROM mahedu.usuario WHERE idUsuario = " + dataGridView1.CurrentCell.Value.ToString();

                        Console.WriteLine(dataGridView1.CurrentCell.Value.ToString());


                        Console.WriteLine(qery);
                        new MessageBox2().Show();

                        SqlCommand cmd = new SqlCommand(qery, ManejadorBD.Conectar());
                        SqlDataAdapter r = new SqlDataAdapter(cmd);
                        DataTable s = new DataTable();
                        r.Fill(s);


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                    }

                }
                else
                {
                   // MessageBox.Show("Contraseña incorrecta");
                }
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);
                MessageBox.Show("Contraseña incorrecta");

            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
