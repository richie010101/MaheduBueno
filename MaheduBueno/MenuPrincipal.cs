using System;
using MaheduBueno.clases2;
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
    public partial class MenuPrincipal : Form
    {
        String id_user;

        public MenuPrincipal(String id_user)
        {
            InitializeComponent();
            this.id_user = id_user;
        }

        public MenuPrincipal()
        {
            InitializeComponent();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (usuario.tipoUser == 4)
            {
                AdministrarUsuarioscs AdministrarUsuario = new AdministrarUsuarioscs();

                AdministrarUsuario.Show();
                this.Close();
            }
            else
            {
                mostrarpanel();
                
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuscarProductos buscarProduct = new BuscarProductos();

            buscarProduct.Show();
            this.Close();

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
            configPanel.Visible = false;


            label2.Text = usuario.Nombre + " " + usuario.apellidoP;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (usuario.tipoUser == 4 || usuario.tipoUser == 5)
            {
                AgregarProductos r = new AgregarProductos();
                r.Show();
                this.Close();
            }
            else
            {
                mostrarpanel();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("tis " + id_user);
            Ventas r = new Ventas(id_user);
            r.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            configPanel.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (usuario.tipoUser == 4 || usuario.tipoUser == 5)
            {

                Estadisticas r = new Estadisticas();

                r.Show();
                this.Close();

            }
            else
            {
                mostrarpanel();
            }
        }

        public void mostrarpanel()
        {
            PanelAgregado.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            configPanel.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.form1.Show();

            usuario.contraMov = "";
            usuario.idUser = 0;
            usuario.tipoUser = 0;
            usuario.username = "";
        }

        private void MenuPrincipal_Paint(object sender, PaintEventArgs e)
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
    }
}
