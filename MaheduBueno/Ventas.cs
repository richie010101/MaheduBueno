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
    public partial class Ventas : Form
    {
        int tota=0;
        public Ventas()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet11.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.maheduDataSet11.producto);
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            errorcantidad.Visible = false;
            try
            {
                String nombre = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int precio = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[2].Value);
                int cantidad = Convert.ToInt32(numericUpDown1.Value);


                if (cantidad > 0)
                {
                    tota = 0;
                    dataGridView2.Rows.Add(nombre, cantidad, precio);
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    { 
                        tota = tota + Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value) * Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
                        Total.Text = "Total: $" + tota.ToString();
                    }
                }
                else
                    errorcantidad.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void D(object sender, KeyEventArgs e)
        {
            
        }

        private void F(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Holamundo");
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Confirmar r = new Confirmar();
            

            DialogResult dg = r.ShowDialog();
            if (dg.ToString() == "OK")
            {
                
                tota = tota - Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value) * Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                Total.Text = "Total: $" + tota.ToString();
            }

        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
        }

        private void dataGridView2_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {

        }
    }
}
