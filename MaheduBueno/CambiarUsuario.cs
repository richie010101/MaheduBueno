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
    public partial class CambiarUsuario : Form
    {
        public CambiarUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
        }

        private void CambiarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet8.tipousuario' Puede moverla o quitarla según sea necesario.
            this.tipousuarioTableAdapter.Fill(this.maheduDataSet8.tipousuario);

        }
    }
}
