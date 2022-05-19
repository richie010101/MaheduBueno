﻿using System;
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
        public AgregarProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
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
            // TODO: esta línea de código carga datos en la tabla 'maheduDataSet7.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter1.Fill(this.maheduDataSet7.producto);

            addPanel3.Visible = false;
            addPanel2.Visible = false;
            agregarPanel.Visible = false;
            addPrima.Visible = false;

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
            addPanel2.Visible = true;
            Addpanel.Visible = false;


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
            addPanel3.Visible = true;
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
    }
    }

