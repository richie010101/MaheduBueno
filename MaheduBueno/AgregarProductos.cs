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
    public partial class AgregarProductos : Form
    {

        Producto nuevo;
        bool proBien = false;
        bool mateBien = false;
        int idProducto;
        int productoEditando;
        List<int> idMaterias;
        List<float> cantidades;
        List<Producto> Productos;
        List<Producto> ProducLista;
        List<materiaPrima> materiasPrimasLista;
        SqlCommand cmd;
        DataTable dt;
        DataTable medidas;
        DataTable productosN;
        int materiaElegida;

        public AgregarProductos()
        {
            InitializeComponent();
            nuevo = new Producto();
            cantidades = new List<float>();
            idMaterias = new List<int>();


            Productos = new List<Producto>();
            ProducLista = new List<Producto>();
            materiasPrimasLista = new List<materiaPrima>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }

        private void BTNAGREGAR_Click(object sender, EventArgs e)
        {
            cerrar_ventanas();
            agregarPanel.Visible = true;
            addPanel3.Visible = false;
            addPanel2.Visible = false;
            Addpanel.Visible = false;
            addPrima.Visible = false;
            panelErrores.Visible = false;

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
            
            actualizar();
            
            dataGridView1.CurrentCell = null;
            Console.WriteLine(usuario.contraMov + usuario.idUser + usuario.username + usuario.tipoUser);

            label2.Text = usuario.username;
            panelErrores.Visible = false;




            addPanel3.Visible = false;
            addPanel2.Visible = false;
            agregarPanel.Visible = false;
            addPrima.Visible = false;
            PanelAgregado.Visible = false;

            panelEdicion.Visible = false;
            Addpanel.Visible = false;
            InfoProducto.Visible = false;
            dataGridView1.MultiSelect = false;


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
            bool encontrado = false;
            if (textNombrePoducto.Text != "" && textSKUproducto.Text != "")
            {
                foreach (Producto p in ProducLista)
                {
                    //Revisar
                    if(p.Sku == textSKUproducto.Text)
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    if ((float)precio.Value > 0 && (float)costo.Value > 0)
                    {
                        if((float)precio.Value < (float)costo.Value)
                        {
                            MessageBox.Show("El precio no puede ser menor al costo");
                        }
                        else
                        {
                            nuevo.Nombre = textNombrePoducto.Text;
                            nuevo.Sku = textSKUproducto.Text;
                            nuevo.Precio = (float)precio.Value;
                            nuevo.Costo = (float)costo.Value;
                            nuevo.Cantidad = (int)CantidadProducto.Value;

                            textNombrePoducto.Text = "";
                            textSKUproducto.Text = "";
                            precio.Value = 0;
                            costo.Value = 0;
                            CantidadProducto.Value = 0;

                            addPanel2.Visible = true;
                            Addpanel.Visible = false;

                            Console.WriteLine(nuevo.Cantidad + nuevo.Sku + nuevo.Precio + nuevo.Costo + nuevo.Nombre);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio y costo no pueden ser 0");
                    }
                }
                else
                {
                    MessageBox.Show("Ya hay un producto con este SKU");
                }
            }
            else
            {
                MessageBox.Show("El nombre y SKU del producto no pueden ser vacios");
            }
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
            if ((int)CantidadMaxProducto.Value > 0 && (int)cantidadMinProducto.Value > 0)
            {
                if ((int)CantidadMaxProducto.Value > (int)cantidadMinProducto.Value)
                {
                    nuevo.Descripcion = textDescripcionProducto.Text;
                    nuevo.CantidadMax = (int)CantidadMaxProducto.Value;
                    nuevo.CantidadMin = (int)cantidadMinProducto.Value;

                    CantidadMaxProducto.Value = 0;
                    cantidadMinProducto.Value = 0;
                    textDescripcionProducto.Text = "";

                    try
                    {
                        String qery = "INSERT INTO mahedu.producto VALUES('" + nuevo.Sku + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "'," +
                               nuevo.Costo + "," + nuevo.Cantidad + "," + nuevo.Precio + "," + nuevo.CantidadMin + "," + nuevo.CantidadMax + ")";

                        SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                        agregarPanel.Visible = false;
                        addPrima.Visible = false;
                        PanelAgregado.Visible = true;
                        addPanel2.Visible = false;
                        actualizar();
                        dataGridView1.CurrentCell = null;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la conexion del servidor busque ayuda: " + ex);
                    }
                    /*
                       addPanel3.Visible = true;
                       addPanel2.Visible = false;    */
 
                }
                else
                {
                    MessageBox.Show("La cantidad maxima no puede ser menor o igual \n a la cantidad minima.");
                }
            }
            else
            {
                MessageBox.Show("Las cantidades no pueden ser 0");
            }
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
            textNombrePrima.Text = "";
            textSKUPrima.Text = "";
            CantidadPrima.Value = 0;
            addPrima.Visible = false;

            cerrar_ventanas();

        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (textNombrePrima.Text != "")
            {
                if (textSKUPrima.Text != "")
                {
                    String consulta = "SELECT * FROM mahedu.materiaprima";
                    cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable r = new DataTable();
                    bool encontro=false;

                    adapter.Fill(r);
                    try
                    {
                        int i;
                        for (i = 0; i < r.Rows.Count; i++)
                        {
                            if(r.Rows[i][1].ToString().Equals(textSKUPrima.Text))
                            {
                                encontro = true;
                                break;
                            }
                        }

                    }
                    catch (Exception R)
                    {
                        Console.WriteLine("error inesparado" + R);

                    }

                    if(encontro)
                    {
                        textoError.Text = "ya existe una materia prima con este SKU, verifique";
                        panelErrores.Visible = true;
                    }
                    else
                    {
                        if (CantidadMateriaPrima.Value >= 0)
                        {
                            Console.WriteLine(CantidadPrima.Value);

                            try
                            {


                                String qery = "INSERT INTO mahedu.materiaprima VALUES('" + textSKUPrima.Text + "','" + textNombrePrima.Text + "','" + textDescripPrima.Text + "'," + CantidadPrima.Value + ")";
                                Console.WriteLine(CantidadMateriaPrima.Value);

                                Console.WriteLine("Corriste");


                                Console.WriteLine(qery);



                                SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                                command.ExecuteNonQuery();
                                command.Connection.Close();
                                agregarPanel.Visible = false;



                                addPrima.Visible = false;

                                textoError.Text = "Agregado correctamente";
                                panelErrores.Visible = true;


                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Error en la conexion del servidor busque ayuda" + ex);
                            }



                        }
                        else
                        {
                            textoError.Text = "No es posible poner cantidad negativas a la materia prima, verifique";
                            panelErrores.Visible = true;
                        }
                    }


                }
                else
                {
                    textoError.Text = "Agrega SKU a tu materia prima";
                    panelErrores.Visible = true;
                }
            }
            else
            {
                textoError.Text = "Agrega nombre a tu materia prima";
                panelErrores.Visible = true;
            }

            actualizar();


        }

        private void button17_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;

            cerrar_ventanas();

        }

        private void PanelAgregado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTNEDITARSELECCION_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell==null)
            {
                textoError.Text = "seleccione un producto primero";
                panelErrores.Visible = true;
            }
            else  if(dataGridView1.CurrentCell.Value == null)
            {
                textoError.Text = "seleccione un producto primero";
                panelErrores.Visible = true;
            }
            else
            {
                cerrar_ventanas();
                recuperarEleccion();
                if(proBien)
                panelEdicion.Visible = true;
                else
                {
                    MessageBox.Show("Recuerde seleccionar la primer columna o toda la fila para continuar ");
                }
            }

        }

        private void editarCantMateria_Click(object sender, EventArgs e)
        {


            

            String consulta = "SELECT * FROM mahedu.materiaprima";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            dt = new DataTable();
            dt.Rows.Clear();

            adapter.Fill(dt);
            
            comboBoxMateriaPrima.Items.Clear();



            try
            {
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxMateriaPrima.Items.Add(dt.Rows[i][2].ToString());
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
            if (dataGridView1.CurrentCell.Value != null)
            {
                recuperarEleccion();

                if (proBien)
                    InfoProducto.Visible = true;
                else
                    MessageBox.Show("recuerde seleccionar toda la fila o el espacio en la columna 'ID'");
            }
            else
            {

                textoError.Text = "Ningun producto ha sido seleccionado, " +
                                "recuerde seleccionar toda la fila, al elegir el producto";
                panelErrores.Visible = true;
            }

        }

        private void recuperarEleccion()
        {
            if(dataGridView1.CurrentCell.ColumnIndex==0 )
            {
                int elegido = int.Parse(dataGridView1.CurrentCell.Value.ToString());



                int i = 0;

                while (i < Productos.Count)
                {
                    if (Productos[i].Id == elegido)
                    {
                        detallesNombre.Text = Productos[i].Nombre;
                        detallesSKU.Text = Productos[i].Sku;
                        detallesPrecio.Value = (decimal)(float)Productos[i].Precio;
                        detallesCosto.Value = (decimal)(float)Productos[i].Costo;
                        detallesCantMax.Value = Productos[i].CantidadMax;
                        detallesCantMin.Value = Productos[i].CantidadMin;
                        detallesDesc.Text = Productos[i].Descripcion;
                        productoEditando = i;
                        proBien = true;
                        break;

                    }
                    i++;
                }
            }
            else
            {
                proBien = false;
            }
            
        }

        private void recuperarEleccionPrima()
        {
            if(tablaPrima.CurrentCell.ColumnIndex== 0)
            {
                int id = int.Parse(tablaPrima.CurrentCell.Value.ToString());

                int i = 0;

                while (i < materiasPrimasLista.Count)
                {
                    if (materiasPrimasLista[i].IdMateria == id)
                    {

                        materiaElegida = i;
                        Console.WriteLine(materiaElegida);
                        mateBien = true;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                mateBien = false;
            }

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
            cerrar_ventanas();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textCantidadPrimaAgregada.Text = textCantidadPrimaAgregada.Text + "\n" + comboBoxMateriaPrima.SelectedItem + "......................" + CantidadMateriaPrima.Value + "m";


            idProducto = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            Console.WriteLine(idProducto);


            cantidades.Add((float)CantidadMateriaPrima.Value);
            CantidadMateriaPrima.Value = 0;

            int i;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (comboBoxMateriaPrima.SelectedItem.ToString().Equals(dt.Rows[i][1].ToString()))
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

            for (i = 0; i < idMaterias.Count; i++)
            {
                String qery = "INSERT INTO mahedu.producto_has_materiaprima values (" + idProducto + "," + idMaterias[i] + "," + cantidades[i] + ")";



                SqlCommand command = new SqlCommand(qery, ManejadorBD.Conectar());
                command.ExecuteNonQuery();
                command.Connection.Close();
                
            }
            agregarPanel.Visible = false;
            addPrima.Visible = false;
            PanelAgregado.Visible = true;
            addPanel3.Visible = false;
            panelEdicion.Visible = false;
            textCantidadPrimaAgregada.Text = "";
            
            
            
            dataGridView1.CurrentCell = null;
            comboBoxMateriaPrima.SelectedItem=null;
            textCantidadPrimaAgregada.Text = "";

            actualizar();
            idMaterias.Clear();
            cantidades.Clear();
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

            cerrar_ventanas();
            materia_Producto.Rows.Clear();



            String consulta = "select mahedu.producto.Nombre as producto , mahedu.materiaprima.Nombre as materia, mahedu.producto_has_materiaprima.cantidadUtilizada as cantidad from mahedu.producto inner join " +
                "mahedu.producto_has_materiaprima on(mahedu.producto.idProducto= mahedu.producto_has_materiaprima.Producto_idProducto)" +
                "inner join mahedu.materiaprima on(mahedu.producto_has_materiaprima.MateriaPrima_IdMateria= mahedu.materiaprima.IdMateria) where mahedu.producto.idProducto=" + Productos[productoEditando].Id;
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable r = new DataTable();

            adapter.Fill(r);

            try
            {
                int i;
                for (i = 0; i < r.Rows.Count; i++)
                {

                    materia_Producto.Rows.Add();
                    materia_Producto[0, i].Value = r.Rows[i][0].ToString();
                    materia_Producto[1, i].Value = r.Rows[i][1].ToString();
                    materia_Producto[2, i].Value = r.Rows[i][2].ToString();
                }

            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }

            panelPrima.Visible = true;
        }



        private void cerrar_ventanas()
        {
            panelEdicion.Visible = false;
            agregarPanel.Visible = false;
            panelSurtir.Visible = false;
            addPanel3.Visible = false;
            InfoProducto.Visible = false;
            panelBorrarPrima.Visible = false;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool encontrado = false;

            if (detallesNombre.Text != "" && detallesSKU.Text != "")
            {               
                if (!encontrado)
                {
                    if ((float)detallesPrecio.Value > 0 && (float)detallesCosto.Value > 0)
                    {
                        if ((float)detallesPrecio.Value < (float)detallesCosto.Value)
                        {
                            MessageBox.Show("El precio no puede ser menor al costo");
                        }
                        else
                        {
                            if ((int)detallesCantMax.Value > 0 && (int)detallesCantMin.Value > 0)
                            {
                                if ((int)detallesCantMax.Value > (int)detallesCantMin.Value)
                                {
                                    Productos[productoEditando].Nombre = detallesNombre.Text;
                                    Productos[productoEditando].Sku = detallesSKU.Text;
                                    Productos[productoEditando].Descripcion = detallesDesc.Text;
                                    Productos[productoEditando].Costo = (float)detallesCosto.Value;
                                    Productos[productoEditando].Precio = (float)detallesPrecio.Value;
                                    Productos[productoEditando].CantidadMax = (int)detallesCantMax.Value;
                                    Productos[productoEditando].CantidadMin = (int)detallesCantMin.Value;



                                    String sql = "Update mahedu.producto SET Nombre='" + Productos[productoEditando].Nombre + "',SKU='" + Productos[productoEditando].Sku +
                                                "',Descripcion='" + Productos[productoEditando].Descripcion + "', [Costo/unidad]=" + Productos[productoEditando].Costo + " ,[Precio]=" + Productos[productoEditando].Precio +
                                                ",CantidadMinima= " + Productos[productoEditando].CantidadMin + ",CantidadMaxRecom=" + Productos[productoEditando].CantidadMax +
                                                 " WHERE idProducto=" + Productos[productoEditando].Id;
                                    Console.WriteLine(sql);

                                    SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                                    command.ExecuteNonQuery();
                                    command.Connection.Close();


                                    InfoProducto.Visible = false;
                                    PanelAgregado.Visible = true;
                                    panelEdicion.Visible = false;
                                    dataGridView1.CurrentCell = null;
                                    actualizar();
                                }
                                else
                                {
                                    
                                    textoError.Text = "La cantidad maxima no puede ser menor o igual \n a la cantidad minima.";
                                    panelErrores.Visible = true;
                                    
                                }   
                            }
                            else
                            {
                                textoError.Text = "Las cantidades no pueden ser 0";
                                panelErrores.Visible = true;
                               
                            }
                        }
                    }
                    else
                    {
                        textoError.Text = "El precio y costo no pueden ser 0";
                        panelErrores.Visible= true;
                        
                        
                    }
                }
                else
                {
                    textoError.Text = "Ya hay un producto con este SKU";
                    panelErrores.Visible = true;
                }
            }
            else
            {
                
                textoError.Text = "El nombre y SKU del producto no pueden ser vacios";
                panelErrores.Visible = true;
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            cerrar_ventanas();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            cerrar_ventanas();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cerrar_ventanas();


        }

        private void button6_Click(object sender, EventArgs e)
        {

            textDescripcionProducto.Text = "";
            cantidadMinProducto.Value = 0;
            CantidadMaxProducto.Value = 0;
            cerrar_ventanas();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textNombrePoducto.Text = "";
            textSKUproducto.Text = "";
            CantidadProducto.Value = 0;
            precio.Value = 0;
            costo.Value = 0;

            cerrar_ventanas();

        }

        public void actualizar()
        {
            dataGridView1.Rows.Clear();
            Productos.Clear();
            ProducLista.Clear();


            
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
                    nuevoP.Precio = float.Parse(productosN.Rows[i][6].ToString());

                    dataGridView1[5, i].Value = productosN.Rows[i][4].ToString();
                    nuevoP.Costo = float.Parse(productosN.Rows[i][4].ToString());

                    dataGridView1[6, i].Value = productosN.Rows[i][5].ToString();
                    nuevoP.Cantidad = int.Parse(productosN.Rows[i][5].ToString());

                    nuevoP.CantidadMin = int.Parse(productosN.Rows[i][7].ToString());
                    nuevoP.CantidadMax = int.Parse(productosN.Rows[i][8].ToString());

                    Productos.Add(nuevoP);
                    ProducLista.Add(nuevoP);
                    


                }
                

            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {



            actualizar();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            cerrar_ventanas();
            cantidadSurtir.Value = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.Value == null)
                {
                    MessageBox.Show("Ningun producto ha sido seleccionado");
                }
                else
                {
                    recuperarEleccion();
                    if (proBien)
                    {
                        int agregado = (int)cantidadSurtir.Value;
                        Productos[productoEditando].Cantidad += agregado;

                        String sql = "Update mahedu.producto SET cantidad=" + Productos[productoEditando].Cantidad + " WHERE idProducto=" + Productos[productoEditando].Id;
                        Console.WriteLine(sql);

                        SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                        command.ExecuteNonQuery();
                        command.Connection.Close();


                        String Busca = "select A.IdMateria, A.Nombre,A.Cantidad, b.cantidadUtilizada, c.idProducto , C.Nombre  from mahedu.materiaprima A inner join mahedu.producto_has_materiaprima B  " +
                            "on A.IdMateria = B.MateriaPrima_IdMateria inner join mahedu.producto C on c.idProducto = b.Producto_idProducto where C.idProducto = " + Productos[productoEditando].Id;

                        cmd = new SqlCommand(Busca, ManejadorBD.Conectar());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable RestarMateria = new DataTable();




                        adapter.Fill(RestarMateria);


                        if (RestarMateria.Rows is null)
                        {

                        }
                        else
                        {
                            int i = 0;

                            while (i < RestarMateria.Rows.Count)
                            {
                                String borrar = "update mahedu.materiaprima set Cantidad= Cantidad -"
                                                + (float)(agregado * float.Parse(RestarMateria.Rows[i][3].ToString())) + " where IdMateria=" + int.Parse(RestarMateria.Rows[i][0].ToString());

                                SqlCommand command2 = new SqlCommand(borrar, ManejadorBD.Conectar());
                                command2.ExecuteNonQuery();
                                command2.Connection.Close();

                                i++;
                            }
                        }

                        PanelAgregado.Visible = true;
                        dataGridView1.CurrentCell = null;
                        panelEdicion.Visible = false;
                        panelSurtir.Visible = false;

                        actualizar();
                    }
                    else
                        MessageBox.Show("recuerde seleccionar toda la fila o el espacio en la columna 'ID'");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ayuda dios mio: " + ex);
            }
        }

        private void agregaMedidas_Click(object sender, EventArgs e)
        {
            panelSurtir.Visible = true;
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            panelPrima.Visible = false;
            cerrar_ventanas();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            try
            {
                String sql = "DELETE FROM mahedu.producto_has_materiaprima WHERE producto_idproducto=" + Productos[productoEditando].Id;

                SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                command.ExecuteNonQuery();
                command.Connection.Close();

                PanelAgregado.Visible = true;
                panelPrima.Visible = false;
                dataGridView1.CurrentCell = null;
                panelEdicion.Visible = false;
                panelSurtir.Visible = false;

                actualizar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (tablaPrima.CurrentCell == null)
            {
                MessageBox.Show("No se ha seleccionado nada aun");
            }
            else if(tablaPrima.CurrentCell.Value == null)
            {
                MessageBox.Show("No se ha seleccionado nada aun");
            }
            else
            {
                recuperarEleccionPrima();

                if (mateBien)
                    surtirPrima.Visible = true;
                else
                    MessageBox.Show("Recuerde selecionar la primera columna o toda la fila del producto");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            actualizarPrima();
            cerrar_ventanas();
            panel1.Visible = true;
        }

        private void tablaPrima_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            panelPrima.Visible = false;
            panel1.Visible = false;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            cerrar_ventanas();

            surtirPrima.Visible = false;
            nuevaPrima.Value = 0;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                float cantidad = (float)nuevaPrima.Value;
                materiasPrimasLista[materiaElegida].Cantidad = materiasPrimasLista[materiaElegida].Cantidad + cantidad;



                String sql = "Update mahedu.materiaPrima SET cantidad=" + materiasPrimasLista[materiaElegida].Cantidad + " WHERE idMateria=" + materiasPrimasLista[materiaElegida].IdMateria;
                Console.WriteLine(sql);

                SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                command.ExecuteNonQuery();
                command.Connection.Close();

                PanelAgregado.Visible = true;
                dataGridView1.CurrentCell = null;
                panelEdicion.Visible = false;
                panelSurtir.Visible = false;

                actualizarPrima();
                cerrar_ventanas();
                surtirPrima.Visible = false;
                nuevaPrima.Value = 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ayuda dios mio: " + ex);
            }

        }

        private void panelPrima_Paint(object sender, PaintEventArgs e)
        {

        }

        public void actualizarPrima()
        {
            String consulta = "SELECT * FROM mahedu.materiaprima";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable r = new DataTable();
            

            adapter.Fill(r);
            tablaPrima.Rows.Clear();
            materiasPrimasLista.Clear();

            try
            {
                int i;
                for (i = 0; i < r.Rows.Count; i++)
                {
                    materiaPrima materiaNueva = new materiaPrima();
                    tablaPrima.Rows.Add();
                    tablaPrima[0, i].Value = r.Rows[i][0].ToString();
                    materiaNueva.IdMateria = int.Parse(r.Rows[i][0].ToString());
                    tablaPrima[1, i].Value = r.Rows[i][1].ToString();
                    materiaNueva.SkuM = r.Rows[i][1].ToString();
                    tablaPrima[2, i].Value = r.Rows[i][2].ToString();
                    materiaNueva.NombreM = r.Rows[i][2].ToString();
                    tablaPrima[3, i].Value = r.Rows[i][3].ToString();
                    materiaNueva.DescripcionM = r.Rows[i][3].ToString();
                    tablaPrima[4, i].Value = r.Rows[i][4].ToString();
                    materiaNueva.Cantidad = float.Parse(r.Rows[i][4].ToString());

                    materiasPrimasLista.Add(materiaNueva);
                }

                tablaPrima.CurrentCell = null;

            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (tablaPrima.CurrentCell == null)
            {
                MessageBox.Show("No se ha seleccionado aun");
            }
            else if (tablaPrima.CurrentCell.Value == null)
            {
                MessageBox.Show("No se ha seleccionado aun");
            }
            else
            {
                recuperarEleccionPrima();

                if (mateBien)
                {
                    panelBorrarPrima.Visible = true;
                    veri.Visible = false;
                }
                else
                    MessageBox.Show("recuerde seleccionar toda la fila o el espacio en la columna 'ID'");
                
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            panelBorrarPrima.Visible = false;

        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBorrarPrima.Text.Equals(usuario.contraMov))
            {
                try
                {
                    String sql = "delete from mahedu.materiaPrima WHERE idMateria=" + materiasPrimasLista[materiaElegida].IdMateria;
                    Console.WriteLine(sql);

                    SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    PanelAgregado.Visible = true;
                    dataGridView1.CurrentCell = null;
                    panelEdicion.Visible = false;
                    panelSurtir.Visible = false;

                    actualizarPrima();
                    cerrar_ventanas();
                    surtirPrima.Visible = false;
                    nuevaPrima.Value = 0;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ayuda dios mio: " + ex);
                }
            }
            else
            {
                veri.Visible = true;
                
            }
        }

        private void AgregarProductos_Paint(object sender, PaintEventArgs e)
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
        }

        private void BTNELIMINARSELECCION_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                textoError.Text = "seleccione un producto primero";
                panelErrores.Visible = true;
            }
            else if (dataGridView1.CurrentCell.Value == null)
            {
                textoError.Text = "seleccione un producto primero";
                panelErrores.Visible = true;
            }
            else
            {
                recuperarEleccion();
                if (proBien)
                {
                    panelBorrarProducto.Visible = true;
                    labelContra.Visible = false;
                }
                else
                {
                    MessageBox.Show("Recuerde seleccionar la primer columna o toda la fila para continuar ");
                }
                
            }
 
        }

        private void button29_Click(object sender, EventArgs e)
        {
            panelBorrarProducto.Visible = false;
            textConfirmarContraBorrar.Text = "";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentCell == null)
            {
                
                textoError.Text = "Ningun producto seleccionado";
                panelErrores.Visible = true;
                panelBorrarProducto.Visible = false;
            }
            else if(dataGridView1.CurrentCell.Value == null)
            {
                textoError.Text = "Ningun producto seleccionado";
                panelErrores.Visible = true;
                panelBorrarProducto.Visible = false;
            }
            else if (textConfirmarContraBorrar.Text.Equals(usuario.contraMov))
            {
                try
                {
                    recuperarEleccion();
                    if (proBien)
                    {
                        InfoProducto.Visible = true;
                        String sql = "delete from mahedu.producto WHERE idProducto=" + Productos[productoEditando].Id;
                        Console.WriteLine(sql);

                        SqlCommand command = new SqlCommand(sql, ManejadorBD.Conectar());
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        PanelAgregado.Visible = true;
                        dataGridView1.CurrentCell = null;
                        panelBorrarProducto.Visible = false;

                        actualizar();
                    }
                        
                    else
                        MessageBox.Show("recuerde seleccionar toda la fila o el espacio en la columna 'ID'");


                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ayuda dios mio: " + ex);
                }
            }
            else
            {
                labelContra.Visible = true;
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String qery = "select * from mahedu.producto where " + comboBox1.Text + " like '%" + textBox1.Text + "%';";

            cmd = new SqlCommand(qery, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            productosN = new DataTable();
            dataGridView1.Rows.Clear();
            Productos.Clear();



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
                    nuevoP.Precio = float.Parse(productosN.Rows[i][6].ToString());

                    dataGridView1[5, i].Value = productosN.Rows[i][4].ToString();
                    nuevoP.Costo = float.Parse(productosN.Rows[i][4].ToString());

                    dataGridView1[6, i].Value = productosN.Rows[i][5].ToString();
                    nuevoP.Cantidad = int.Parse(productosN.Rows[i][5].ToString());

                    nuevoP.CantidadMin = int.Parse(productosN.Rows[i][7].ToString());
                    nuevoP.CantidadMax = int.Parse(productosN.Rows[i][8].ToString());

                    Productos.Add(nuevoP);
                    

                }

                dataGridView1.CurrentCell = null;

            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
            


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            String consulta = "SELECT * FROM mahedu.materiaprima where " + comboBox2.Text + " like '%" + textBox2.Text + "%';";
            cmd = new SqlCommand(consulta, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable r = new DataTable();

            adapter.Fill(r);
            tablaPrima.Rows.Clear();
            materiasPrimasLista.Clear();

            try
            {
                int i;
                for (i = 0; i < r.Rows.Count; i++)
                {
                    materiaPrima materiaNueva = new materiaPrima();
                    tablaPrima.Rows.Add();
                    tablaPrima[0, i].Value = r.Rows[i][0].ToString();
                    materiaNueva.IdMateria = int.Parse(r.Rows[i][0].ToString());
                    tablaPrima[1, i].Value = r.Rows[i][1].ToString();
                    materiaNueva.SkuM = r.Rows[i][1].ToString();
                    tablaPrima[2, i].Value = r.Rows[i][2].ToString();
                    materiaNueva.NombreM = r.Rows[i][2].ToString();
                    tablaPrima[3, i].Value = r.Rows[i][3].ToString();
                    materiaNueva.DescripcionM = r.Rows[i][3].ToString();
                    tablaPrima[4, i].Value = r.Rows[i][4].ToString();
                    materiaNueva.Cantidad = float.Parse(r.Rows[i][4].ToString());

                    materiasPrimasLista.Add(materiaNueva);
                }

                tablaPrima.CurrentCell = null;

            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = false;
        }

        private void panelErrores_Paint(object sender, PaintEventArgs e)
        {
            // Área cliente del formulario.
            //
          //  Rectangle r = this.panelErrores;

            // Punto intermedio del área cliente.
            //
            int c = panelErrores.Width / 2;

            // Establecemos la nueva posición del control Label.
            //
            textoError.Location = new Point(c - textoError.Width / 2, textoError.Location.Y);
        }

        private void panelBorrarProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            panelErrores.Visible = false;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            PanelAgregado.Visible = false;

            cerrar_ventanas();
        }
    }
    }

                                                                                                                                                