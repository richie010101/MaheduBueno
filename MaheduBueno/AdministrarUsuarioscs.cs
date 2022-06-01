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
    public partial class AdministrarUsuarioscs : Form
    {
        private ManejadorBD manejadorBD;

        SqlCommand cmd;
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
            this.Close();
            int i;
            /*
            for(i=0;i<tipoUsuario.Items.Count;i++)
            {
                if (tipoUsuario.Items[i].ToString().Equals("SuperUsuario")) ;
                tipoUsuario.Items.RemoveAt(i);
            }  */
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
            
            
            PanelAgregado.Visible = false;
            panel4.Visible = false;

          



            label2.Text = usuario.Nombre + " " + usuario.apellidoP;

            actualizar();



        }

        private void actualizar()
        {
            dataGridView1.Rows.Clear();
            String consulta = "select * from mahedu.usuario where mahedu.usuario.tipoUsuario_idtipoUsuario!=4;";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable productosN = new DataTable();


            adapter.Fill(productosN);
            try
            {
                int i;
                for (i = 0; i < productosN.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = productosN.Rows[i][0].ToString();
                    dataGridView1[1, i].Value = productosN.Rows[i][1].ToString();
                    dataGridView1[2, i].Value = productosN.Rows[i][2].ToString();
                    dataGridView1[3, i].Value = productosN.Rows[i][3].ToString();

                    if (productosN.Rows[i][6].ToString().Equals("5"))
                    {
                        dataGridView1[4, i].Value = "Administrador";
                    }
                    else
                    {
                        dataGridView1[4, i].Value = "Vendedor";
                    }
                }


            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
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
                   // MessageBox.Show("Contraseña correcta");
                    try
                    {
                        ManejadorBD.Conectar();


                        String qery = "DELETE FROM mahedu.usuario WHERE idUsuario = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                

                        Console.WriteLine(dataGridView1.CurrentCell.Value.ToString());


                        Console.WriteLine(qery);
                        //new MessageBox2().Show();
                       // MessageBox2 borrado = new MessageBox2();

                       // DialogResult dg = borrado.ShowDialog();

                        panel4.Visible = true;
                        textError.Text = "Usuario eliminado con exito";

                        SqlCommand cmd = new SqlCommand(qery, ManejadorBD.Conectar());
                        SqlDataAdapter r = new SqlDataAdapter(cmd);
                        DataTable s = new DataTable();
                        r.Fill(s);


                        actualizar();




                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                    }

                }
                else
                {
                    // MessageBox.Show("Contraseña incorrecta");
                    panel4.Visible = true;
                    textError.Text = "Contraseña Incorrecta";
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
                    panel4.Visible = true;
                    textError.Text = "El nombre no puede estar vacio";
                }

                else if (ApellidoP.Text == "")
                {

                    panel4.Visible = true;
                    textError.Text = "El apellido paterno no debe de estar vacío";
                }
                else if (ApellidoM.Text == "")
                {

                    panel4.Visible = true;
                    textError.Text = "El apellido materno no debe de estar vacío";
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
            PanelAgregado.Visible = true;


            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet9.tipousuario' Puede moverla o quitarla según sea necesario.
            this.tipousuarioTableAdapter.Fill(this.maheduDataSet9.tipousuario);
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet2.usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.maheduDataSet2.usuario);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdministrarUsuarioscs_Paint(object sender, PaintEventArgs e)
        {
            // Área cliente del formulario.
            //
            Rectangle r = this.ClientRectangle;

            // Punto intermedio del área cliente.
            //
            int c = r.Width / 2;

            // Establecemos la nueva posición del control Label.
            //
            label2.Location = new Point(c - label2.Width / 2, label2.Location.Y);
            label1.Location = new Point(c - label1.Width / 2, label1.Location.Y);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void textError_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            int c = panel4.Width / 2;

            // Establecemos la nueva posición del control Label.
            //
            textError.Location = new Point(c - textError.Width / 2, textError.Location.Y);
        }
    }
}




