using MaheduBueno.clases;
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
    public partial class AgregarProductos : Form
    {

        Producto nuevo;

        public AgregarProductos()
        {
            InitializeComponent();
            nuevo = new Producto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }

        private void BTNAGREGAR_Click(object sender, EventArgs e)
        {
            agregarPanel.Visible = true;
            addPanel3.Visible = false;
            addPanel2.Visible = false;
            Addpanel.Visible = false;
            addPrima.Visible = false;
            /*
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion1);
                String qery = "insert SKU, Nombre, Precio, Cantidad from mahedu.producto where " + comboBox1.Text + " like '%" + textBox1.Text + "%';";
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
            }*/
        }

        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet13.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter3.Fill(this.maheduDataSet13.producto);
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet12.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter2.Fill(this.maheduDataSet12.producto);
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet7.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter1.Fill(this.maheduDataSet7.producto);



            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 60;

            addPanel3.Visible = false;
            addPanel2.Visible = false;
            agregarPanel.Visible = false;
            addPrima.Visible = false;
            PanelAgregado.Visible = false;

            panelEdicion.Visible = false;
            Addpanel.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregarPanel.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addpanel.Visible = true;
            addPanel3.Visible = false;
            addPanel2.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            nuevo.Nombre = textNombrePoducto.Text;
            nuevo.Sku = textSKUproducto.Text;
            nuevo.Precio = (float)precio.Value;
            nuevo.Costo = (float)costo.Value;
            nuevo.Cantidad = (int)CantidadProducto.Value;

            textNombrePoducto.Text = "";
            textSKUproducto.Text="";
            precio.Value=0;
            costo.Value=0;
            CantidadProducto.Value=0;

            addPanel2.Visible = true;
            Addpanel.Visible = false;

            Console.WriteLine(nuevo.Cantidad + nuevo.Sku + nuevo.Precio + nuevo.Costo + nuevo.Nombre);





        }                                  

        private void ProductoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void addPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            nuevo.Descripcion = textDescripcionProducto.Text;
            nuevo.CantidadMax = (int)CantidadMaxProducto.Value;
            nuevo.CantidadMin = (int)cantidadMinProducto.Value;

            CantidadMaxProducto.Value=0;
            cantidadMinProducto.Value=0;
            textDescripcionProducto.Text = "";


            try
            {


                String qery = "INSERT INTO mahedu.producto VALUES('"+ nuevo.Sku + "','" + nuevo.Nombre + "','"+ nuevo.Descripcion + "'," + 
                                                                   nuevo.Costo+","+ nuevo.Cantidad+"," + nuevo.Precio +"," + nuevo.CantidadMin+"," +nuevo.CantidadMax +")";

                Console.WriteLine("Corriste");


                Console.WriteLine(qery);



                SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                command.ExecuteNonQuery();
                command.Connection.Close();
                agregarPanel.Visible = false;
                addPrima.Visible = false;
                PanelAgregado.Visible = true;
                


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
            }






            /*
               addPanel3.Visible = true;
               addPanel2.Visible = false;    */

            PanelAgregado.Visible = true;
            addPanel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)                                            
        {
            addPrima.Visible = true;
            textDescripPrima.Text = "";
            textNombrePrima.Text = "";
            textSKUPrima.Text = "";
            CantidadPrima.Value = 0;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textDescripPrima.Text = "";
            textNombrePrima.Text= "";
            textSKUPrima.Text = "";
            CantidadPrima.Value = 0;
            addPrima.Visible = false;

        }

        private void button13_Click(object sender, EventArgs e)
        {

            if(textNombrePrima.Text!="")
            {
                if(textSKUPrima.Text!="")
                {
                     if(CantidadMateriaPrima.Value>=0)
                    {
                        Console.WriteLine(CantidadPrima.Value);
                        
                        try
                        {
                            

                            String qery = "INSERT INTO mahedu.materiaprima VALUES('" + textSKUPrima.Text + "','" + textNombrePrima.Text + "','" + textDescripPrima.Text + "'," + CantidadMateriaPrima.Value.ToString() + ")";

                            Console.WriteLine("Corriste");


                            Console.WriteLine(qery);

                              

                            SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                            command.ExecuteNonQuery();
                            command.Connection.Close();
                            agregarPanel.Visible = false;

                            MessageBox.Show("guardado correctamente");

                            addPrima.Visible = false;


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                        }
                      


                    }
                     else
                    {
                        MessageBox.Show("no es posible poner cantidad negativas a la materia prima, verifique");
                    }
                }
                else
                {

                    MessageBox.Show("agrega SKU a tu materia prima");
                }
            }
            else
            {
                MessageBox.Show("agrega nombre a tu materia prima");
            }




        }

        private void button17_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;
        }

        private void PanelAgregado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTNEDITARSELECCION_Click(object sender, EventArgs e)
        {
            panelEdicion.Visible = true;
        }

        private void editarCantMateria_Click(object sender, EventArgs e)
        {
            


                                      
            String consulta = "SELECT * FROM mahedu.materiaprima";
            SqlCommand cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);


            try
            {
                int i;
                for (i=0;i<dt.Rows.Count;i++)
                {
                    comboBoxMateriaPrima.Items.Add(dt.Rows[i][1].ToString());
                }
                addPanel3.Visible = true;
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }

        }

        private void EditarDetalles_Click(object sender, EventArgs e)
        {
           

        }

        private void agregaMedidas_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
    }
    }

