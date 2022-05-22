﻿using MaheduBueno.clases2;
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
        int idProducto;
        int productoEditando;
        List<int> idMaterias;
        List<float> cantidades;
        List<Producto> Productos;
        SqlCommand cmd;
        DataTable dt;
        DataTable medidas;
        DataTable productosN;

        public AgregarProductos()
        {
            InitializeComponent();
            nuevo = new Producto();
            cantidades = new List<float>();
            idMaterias = new List<int>();

            Productos = new List<Producto>();
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


            InfoProducto.Visible = false;
            dataGridView1.MultiSelect = false;


            String consulta = "SELECT * FROM mahedu.producto";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            productosN = new DataTable();

            adapter.Fill(productosN);

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].Width = 60;


            try
            {
                int i;
                for (i = 0; i < productosN.Rows.Count; i++)
                {
                    Producto nuevoP = new Producto();
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = productosN.Rows[i][0].ToString();
                    nuevoP.Id = int.Parse(productosN.Rows[i][0].ToString());

                    dataGridView1[1, i].Value = productosN.Rows[i][1].ToString();
                    nuevoP.Sku = productosN.Rows[i][1].ToString();

                    dataGridView1[2, i].Value = productosN.Rows[i][2].ToString();
                    nuevoP.Nombre = productosN.Rows[i][2].ToString();

                    dataGridView1[3, i].Value = productosN.Rows[i][3].ToString();
                    nuevoP.Descripcion = productosN.Rows[i][3].ToString();

                    dataGridView1[4, i].Value = productosN.Rows[i][6].ToString();
                    nuevoP.Precio =float.Parse (productosN.Rows[i][6].ToString());

                    dataGridView1[5, i].Value = productosN.Rows[i][4].ToString();
                    nuevoP.Costo = float.Parse(productosN.Rows[i][4].ToString());

                    dataGridView1[6, i].Value = productosN.Rows[i][5].ToString();
                    nuevoP.Cantidad = int.Parse(productosN.Rows[i][5].ToString());

                    nuevoP.CantidadMin = int.Parse(productosN.Rows[i][7].ToString());
                    nuevoP.CantidadMax = int.Parse(productosN.Rows[i][8].ToString());

                    Productos.Add(nuevoP);

                    
                }
                addPanel3.Visible = true;
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }





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
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            dt = new DataTable();

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
            int elegido = int.Parse(dataGridView1.CurrentCell.Value.ToString());

            int i;

            for(i=0; i<1000;i++)
            {
                if(Productos[i].Id==elegido)
                {
                    detallesNombre.Text = Productos[i].Nombre;
                    detallesSKU.Text= Productos[i].Sku;
                    detallesPrecio.Value= (decimal)Productos[i].Precio;
                    detallesCosto.Value= (decimal)Productos[i].Costo;  
                    detallesCantMax.Value= Productos[i].CantidadMax;
                    detallesCantMin.Value= Productos[i].CantidadMin;
                    detallesDesc.Text= Productos[i].Descripcion;
                    productoEditando = i;
                    break;

                }
            }


            InfoProducto.Visible = true;


        }
          /*
        private void agregaMedidas_Click(object sender, EventArgs e)
        {

            String consulta = "SELECT * FROM mahedu.medida";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            dt = new DataTable();

            adapter.Fill(medidas);


            try
            {
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                   comboBoxMedidas.Items.Add(dt.Rows[i][1].ToString());
                }
                panelMedidas.Visible = true;
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
        }            */

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textCantidadPrimaAgregada.Text = textCantidadPrimaAgregada.Text + "\n" + comboBoxMateriaPrima.SelectedItem + "......................" + CantidadMateriaPrima.Value + "m";


            idProducto = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            Console.WriteLine(idProducto);


            cantidades.Add((float)CantidadMateriaPrima.Value);
            CantidadMateriaPrima.Value = 0;

            int i;

            for(i=0;i<dt.Rows.Count;i++)
            {
                   if(comboBoxMateriaPrima.SelectedItem.ToString().Equals(dt.Rows[i][1].ToString()))
                {
                    idMaterias.Add(int.Parse(dt.Rows[i][0].ToString()));
                    comboBoxMateriaPrima.SelectedItem = null;
                    break;
                }
            }




        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            int i;

            for(i=0;i<idMaterias.Count;i++)
            {
                String qery = "INSERT INTO mahedu.producto_has_materiaprima values (" + idProducto + "," + idMaterias[i] + "," + cantidades[i] + ")";



                SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                command.ExecuteNonQuery();
                command.Connection.Close();
                agregarPanel.Visible = false;
                addPrima.Visible = false;
                PanelAgregado.Visible = true;
                addPanel3.Visible = false;
                panelEdicion.Visible = false;
                textCantidadPrimaAgregada.Text = "";
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            panelEdicion.Visible = false;
            addPanel3.Visible = false;
            InfoProducto.Visible = false;
        }

        private void InfoProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

            
            Productos[productoEditando].Nombre = detallesNombre.Text;
            Productos[productoEditando].Sku = detallesSKU.Text;
            Productos[productoEditando].Descripcion = detallesDesc.Text;
            Productos[productoEditando].Costo = (float)detallesCosto.Value;
            Productos[productoEditando].Precio = (float)detallesPrecio.Value;
            Productos[productoEditando].CantidadMax = (int)detallesCantMax.Value;
            Productos[productoEditando].CantidadMin = (int)detallesCantMin.Value;



           String sql= "Update mahedu.producto SET Nombre='" + Productos[productoEditando].Nombre + "',SKU='" + Productos[productoEditando].Sku +
                       "',Descripcion='" + Productos[productoEditando].Descripcion + "', [Costo/unidad]=" + Productos[productoEditando].Costo+ " ,[Precio]=" + Productos[productoEditando].Precio
                        + ",CantidadMinima= " + Productos[productoEditando].CantidadMin + ",CantidadMaxRecom=" +  Productos[productoEditando].CantidadMax + 
                        " WHERE idProducto=" + Productos[productoEditando].Id;

            SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
            command.ExecuteNonQuery();
            command.Connection.Close();


            InfoProducto.Visible = false;
            PanelAgregado.Visible = true;
            panelEdicion.Visible = false;


        }
    }
    }

