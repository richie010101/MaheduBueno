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
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;


        }

        private void AdministrarUsuarioscs_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet9.tipousuario' Puede moverla o quitarla según sea necesario.
            this.tipousuarioTableAdapter.Fill(this.maheduDataSet9.tipousuario);
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
                        //new MessageBox2().Show();
                        MessageBox2 borrado = new MessageBox2();

                        DialogResult dg = borrado.ShowDialog();

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

            panel2.Visible = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                ManejadorBD.Conectar();


                if (nombre.Text == "")
                {
                    MessageBox.Show("El nombre no puede estar vacío");
                }

                if (ApellidoP.Text == "")
                {
                    MessageBox.Show("El apellido paterno no debe de estar vacío");
                }
                if (ApellidoM.Text == "")
                {
                    MessageBox.Show("El apellido materno no debe de estar vacío");
                }
                else
                {
                    int id = 6;

                    if (tipoUsuario.SelectedItem.ToString() == "SuperUsuario")
                    {
                        id = 4;
                    }
                    else if (tipoUsuario.SelectedItem.ToString() == "Administrador")
                    {
                        id = 5;
                    }
                    else if (tipoUsuario.SelectedItem.ToString() == "Vendedor")
                    {
                        id = 6;
                    }

                    String qery = "UPDATE mahedu.usuario SET Nombres='" + nombre.Text + "', ApellidoP='" + ApellidoP.Text + "', ApellidoM ='" + ApellidoM.Text + "', tipoUsuario_idtipoUsuario ='" + id + "' WHERE idUsuario = " + dataGridView1.CurrentCell.Value.ToString();
                    Console.WriteLine(qery);
                    // Console.WriteLine(dataGridView1.CurrentCell.Value.ToString());


                    Console.WriteLine(qery);
                    // new MessageBox2().Show();

                    SqlCommand cmd = new SqlCommand(qery, ManejadorBD.Conectar());
                    SqlDataAdapter r = new SqlDataAdapter(cmd);
                    DataTable s = new DataTable();
                    r.Fill(s);



                }
            }
            catch (Exception ex)
            {


                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
            }



            panel3.Visible = false;


            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet9.tipousuario' Puede moverla o quitarla según sea necesario.
            this.tipousuarioTableAdapter.Fill(this.maheduDataSet9.tipousuario);
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet2.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.maheduDataSet2.usuario);
        }
    }
}

    
    

