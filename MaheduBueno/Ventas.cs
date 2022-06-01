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
    public partial class Ventas : Form
    {
        int tota=0;
        String user;
        public Ventas()
        {
            InitializeComponent();
        }
        public Ventas(String id)
        {
            InitializeComponent();
            user = id;
            
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
            label2.Text = usuario.Nombre + " " + usuario.apellidoP;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PanelAgregado.Visible = true;
            try
            {

              //  Confirmar r = new Confirmar("Confirmar la venta", "Confirmar");


               // DialogResult dg = r.ShowDialog();
              /*  if (dg.ToString() == "OK")
                {
                    ManejadorBD.Conectar();


                    //Saca el id venta actual
                    String consulta1 = "SELECT count(*) FROM mahedu.venta";
                    SqlCommand cmd1 = new SqlCommand(consulta1, ManejadorBD.Conectar());
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

                    DataTable dt1 = new DataTable();

                    adapter1.Fill(dt1);

                    int id_venta = Convert.ToInt32(dt1.Rows[0][0]) + 2;
                    Console.WriteLine("siuuu"+id_venta);

                    //registra la venta con la fecha y el vendedor

                    ManejadorBD.Conectar();
                    String consulta = "insert into mahedu.venta values(" + user + ", '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "');";
                    SqlCommand cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);




                    //registra cada producto con su venta
                    for (int fila = 0; fila < dataGridView2.RowCount; fila++)
                    {
                        ManejadorBD.Conectar();
                        String consulta2 = "insert into mahedu.producto_has_venta values (" + Convert.ToInt32(dataGridView2.Rows[fila].Cells[3].Value) + ", " + id_venta + ", " + Convert.ToInt32(dataGridView2.Rows[fila].Cells[1].Value) + ");";
                        SqlCommand cmd2 = new SqlCommand(consulta2, ManejadorBD.Conectar());
                        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                        
                        DataTable dt0 = new DataTable();

                        adapter2.Fill(dt0);

                        Console.WriteLine(consulta2);

                        ManejadorBD.Conectar();
                        //Le resta los productos vendidos a la tabla productos
                        String query = "UPDATE mahedu.producto SET Cantidad = mahedu.producto.Cantidad - "+ Convert.ToInt32(dataGridView2.Rows[fila].Cells[1].Value) + "where idProducto = "+Convert.ToInt32(dataGridView2.Rows[fila].Cells[3].Value)+";";
                        SqlCommand cm = new SqlCommand(query, ManejadorBD.Conectar());
                        SqlDataAdapter adap = new SqlDataAdapter(cm);
                        Console.WriteLine(query);
                        DataTable dataT = new DataTable();

                        adap.Fill(dataT);
                    }

                }   */

               

                
                

            }
            catch (Exception ex)
            {

                throw;
            }



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
                int _ID = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[3].Value);

                if (cantidad > 0)
                {
                    tota = 0;
                    dataGridView2.Rows.Add(nombre, cantidad, precio, _ID);
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
           // Confirmar r = new Confirmar();


            panel3.Visible = true;

          /*  DialogResult dg = r.ShowDialog();
            if (dg.ToString() == "OK")
            {
                
                tota = tota - Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value) * Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                Total.Text = "Total: $" + tota.ToString();
            }   */

        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
        }

        private void dataGridView2_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* Confirmar r = new Confirmar("Seguro que quieres cancelar la compra?", "Confirmar");


             DialogResult dg = r.ShowDialog();
             if (dg.ToString() == "OK") {

                 dataGridView2.Rows.Clear();

             } */
            panel2.Visible = true;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ManejadorBD.Conectar();


            //Saca el id venta actual
            String consulta1 = "SELECT count(*) FROM mahedu.venta";
            SqlCommand cmd1 = new SqlCommand(consulta1, ManejadorBD.Conectar());
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);

            DataTable dt1 = new DataTable();

            adapter1.Fill(dt1);

            int id_venta = Convert.ToInt32(dt1.Rows[0][0]) + 2;
            Console.WriteLine("siuuu" + id_venta);

            //registra la venta con la fecha y el vendedor

            ManejadorBD.Conectar();
            String consulta = "insert into mahedu.venta values(" + user + ", '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "');";
            SqlCommand cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);




            //registra cada producto con su venta
            for (int fila = 0; fila < dataGridView2.RowCount; fila++)
            {
                ManejadorBD.Conectar();
                String consulta2 = "insert into mahedu.producto_has_venta values (" + Convert.ToInt32(dataGridView2.Rows[fila].Cells[3].Value) + ", " + id_venta + ", " + Convert.ToInt32(dataGridView2.Rows[fila].Cells[1].Value) + ");";
                SqlCommand cmd2 = new SqlCommand(consulta2, ManejadorBD.Conectar());
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);

                DataTable dt0 = new DataTable();

                adapter2.Fill(dt0);

                Console.WriteLine(consulta2);

                ManejadorBD.Conectar();
                //Le resta los productos vendidos a la tabla productos
                String query = "UPDATE mahedu.producto SET Cantidad = mahedu.producto.Cantidad - " + Convert.ToInt32(dataGridView2.Rows[fila].Cells[1].Value) + "where idProducto = " + Convert.ToInt32(dataGridView2.Rows[fila].Cells[3].Value) + ";";
                SqlCommand cm = new SqlCommand(query, ManejadorBD.Conectar());
                SqlDataAdapter adap = new SqlDataAdapter(cm);
                Console.WriteLine(query);
                DataTable dataT = new DataTable();

                adap.Fill(dataT);
            }


            Productos.Rows.Clear();

            String consulta3 = "select  a.* from mahedu.producto as A where (A.Cantidad <= A.CantidadMinima*1.25);";

            SqlCommand cmd3= new SqlCommand(consulta3, ManejadorBD.Conectar());
            SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
            DataTable productosN = new DataTable();

            adapter3.Fill(productosN);
            try
            {
                int i;
                if(productosN.Rows.Count==0)
                {

                }
                else
                {
                    for (i = 0; i < productosN.Rows.Count; i++)
                    {
                        Productos.Rows.Add();
                        Productos[0, i].Value = productosN.Rows[i][2].ToString();
                        Productos[1, i].Value = productosN.Rows[i][5].ToString();
                        Productos[2, i].Value = productosN.Rows[i][7].ToString();

                        Console.WriteLine(productosN.Rows[i][2].ToString());

                    }
                    panel4.Visible = true;
                }
               


            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }



            panel1.Visible = true;
            PanelAgregado.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            panel2.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tota = tota - Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value) * Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            Total.Text = "Total: $" + tota.ToString();
            panel3.Visible = false;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void Ventas_Paint(object sender, PaintEventArgs e)
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
