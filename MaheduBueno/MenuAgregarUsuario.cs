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
        private ManejadorBD manejadorBD;
        public MenuAgregarUsuario()
        {
            InitializeComponent();
            manejadorBD = new ManejadorBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (NombreU.Text == "")
            {
                Nombre1cs nombre = new Nombre1cs();

                DialogResult dg = nombre.ShowDialog();
                //MessageBox.Show("El nombre no puede estar vacío");
            }
            else
            {

                if (ApellidoP.Text == "")
                {
                    Nombre2 nombrep = new Nombre2();

                    DialogResult dg = nombrep.ShowDialog();
                    //MessageBox.Show("El apellido paterno no debe de estar vacío");
                }
                else
                {
                    if (ApellidoM.Text == "")
                    {
                       // Nombre3 nombrem = new Nombre3();

                        //DialogResult dg = nombrem.ShowDialog();
                        panelErrores.Visible = true;
                        textErrores.Text = "El apellido materno no debe de estar vacío";
                        //MessageBox.Show("El apellido materno no debe de estar vacío");
                    }
                    else
                    {
                        if (Contraseña.Text == "")
                        {
                            //Nombre4 cc = new Nombre4();

                            //    DialogResult dg = cc.ShowDialog();
                            panelErrores.Visible = true;
                            textErrores.Text = "La contraseña no debe de estar vacía";
                        }
                        else
                        {
                            if (Contraseña.Text != ConfirContra.Text)
                            {
                                Nombre5 nc = new Nombre5();

                                DialogResult dg = nc.ShowDialog(); ;
                                panelErrores.Visible = true;
                                textErrores.Text = "La contraseña no debe de estar vacía";
                                //MessageBox.Show("La contraseña no debe de estar vacía");
                            }

                            //MessageBox.Show("Las contraseñas no coinciden");
                        

                            else
                            {
                                int id = 6;

                                if (comboBox1.SelectedItem == "SuperUsuario")
                                {
                                    id = 4;
                                }
                                else if (comboBox1.SelectedItem == "Administrador")
                                {
                                    id = 5;
                                }
                                else if (comboBox1.SelectedItem == "Vendedor")
                                {
                                    id = 6;
                                }


                                try
                                {
                                    /* SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion1); */
                                    ManejadorBD.Conectar();

                                    String qery = "INSERT INTO mahedu.usuario VALUES('" + NombreU.Text + "','" + ApellidoP.Text + "','" + ApellidoM.Text + "','" + userBox.Text + "','" + Contraseña.Text + "'," + id + ", '" + contraAd.Text + "')";

                                    Console.WriteLine("Corriste");


                                    Console.WriteLine(qery);
                                    /*
                                   SqlDataAdapter ada = new SqlDataAdapter(qery, con);

                                    con.Open();

                                    DataSet data = new DataSet();
                                    */

                                    SqlCommand cmd = new SqlCommand(qery, ManejadorBD.Conectar());
                                    SqlDataAdapter r = new SqlDataAdapter(cmd);
                                    DataTable s = new DataTable();
                                    r.Fill(s);


                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                                }

                                PanelAgregado.Visible = true;
                              //Felicitaciones agre = new Felicitaciones();

                           //     DialogResult dg = agre.ShowDialog();



                               // MenuAgregarUsuario MenuAgregar = new MenuAgregarUsuario();

                              //  this.Close();
                            }

                       
                        }

                    
                    }

                }
            }

            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void TipoUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuAgregarUsuario_Load(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuAgregarUsuario MenuAgregar = new MenuAgregarUsuario();

            MenuAgregar.Show();
             this.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuAgregarUsuario MenuAgregar = new MenuAgregarUsuario();

            MenuAgregar.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = false;
        }
    }
}
