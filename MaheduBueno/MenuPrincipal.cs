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
            AdministrarUsuarioscs AdministrarUsuario = new AdministrarUsuarioscs();

            AdministrarUsuario.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuscarProductos buscarProduct = new BuscarProductos();

            buscarProduct.Show();
            this.Close();

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgregarProductos r = new AgregarProductos();
            r.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("tis "+id_user);
            Ventas r = new Ventas(id_user);
            r.Show();
            this.Close();
        }
    }
}
