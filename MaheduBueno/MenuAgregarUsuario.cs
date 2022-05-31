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
        private SqlCommand cmd;
        private DataTable usuarios;
        public MenuAgregarUsuario()
        {
            InitializeComponent();
            manejadorBD = new ManejadorBD();
            usuarios = new DataTable();
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
               
                panelErrores.Visible = true;
                textErrores.Text = "El nombre no puede estar vacío";

                
                //MessageBox.Show("El nombre no puede estar vacío");
            }
            else
            {

                if (ApellidoP.Text == "")
                {
                    panelErrores.Visible = true;
                    textErrores.Text = "El apellido paterno no debe de estar vacío";
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
                             //   Nombre5 nc = new Nombre5();

                                
                                ////DialogResult dg = nc.ShowDialog(); ;
                                panelErrores.Visible = true;
                                textErrores.Text = "Las contraseñas no coinciden";
                                //MessageBox.Show("La contraseña no debe de estar vacía");
                            }
                            else
                            {
                                if (userBox.Text == "")
                                {
                                    panelErrores.Visible = true;
                                    textErrores.Text = "El nombre de usuario no puede ser vacio";
                                }
                                else
                                {
                                    bool existe = false;

                                    for (int i = 0; i < usuarios.Rows.Count; i++)
                                    {
                                        if (userBox.Text.Equals(usuarios.Rows[i][4].ToString()))
                                        {
                                            existe = true;
                                            break;
                                        }
                                    }

                                    if (existe)
                                    {
                                        panelErrores.Visible = true;
                                        textErrores.Text = "Nombre de usuario ya en uso";
                                    }
                                    else
                                    {
                                        if (contraAd.Text == "")
                                        {
                                            panelErrores.Visible = true;
                                            textErrores.Text = "La contraseña segura no puede ser vacia";
                                        }
                                        else
                                        {
                                            int id = 6;
                                            if (comboBox1.SelectedItem == "Administrador")
                                            {
                                                id = 5;
                                            }
                                            else if (comboBox1.SelectedItem == "Vendedor")
                                            {
                                                id = 6;
                                            }

                                            try
                                            {
                                                ManejadorBD.Conectar();

                                                String qery = "INSERT INTO mahedu.usuario VALUES('" + NombreU.Text + "','" + ApellidoP.Text + "','" + ApellidoM.Text + "','" +
                                                    userBox.Text + "','" + Contraseña.Text + "'," + id + ", '" + contraAd.Text + "')";
                                                Console.WriteLine(qery);

                                                cmd = new SqlCommand(qery, ManejadorBD.Conectar());
                                                SqlDataAdapter r = new SqlDataAdapter(cmd);
                                                DataTable s = new DataTable();
                                                r.Fill(s);

                                                PanelAgregado.Visible = true;
                                            }
                                            catch (Exception ex)
                                            {

                                                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                                            }
                                        }
                                    }
                                }

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
            panelErrores.Visible = false;

            String qery = "SELECT * FROM mahedu.usuario";
            cmd = new SqlCommand(qery, ManejadorBD.Conectar());
            SqlDataAdapter r = new SqlDataAdapter(cmd);

            r.Fill(usuarios);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdministrarUsuarioscs MenuAgregar = new AdministrarUsuarioscs();

            MenuAgregar.Show();
             this.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdministrarUsuarioscs MenuAgregar = new AdministrarUsuarioscs();

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

        private void panelErrores_Paint(object sender, PaintEventArgs e)
        {
            int c = panelErrores.Width / 2;

            // Establecemos la nueva posición del control Label.
            //
            textErrores.Location = new Point(c - textErrores.Width / 2, textErrores.Location.Y);
        }
    }
}
