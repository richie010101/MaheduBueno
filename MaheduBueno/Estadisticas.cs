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
using System.Windows.Forms.DataVisualization.Charting;

namespace MaheduBueno
{
    public partial class Estadisticas : Form
    {

        SqlCommand cmd;
        Dictionary<String, float> dic;
        public Estadisticas()
        {
            InitializeComponent();
            dic = new Dictionary<String, float>();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            recuperarUtilidades();
            masVendidos();
            cambiaDescripcion();
            cargar();

            label2.Text = usuario.username;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }

        public void recuperarUtilidades()
        {


            string sql = "select top 5 c.idProducto ,C.Nombre,  sum(C.Precio*B.Cantidad - C.[Costo/unidad]*B.Cantidad) as 'utilidad', sum(B.Cantidad) " +
                "as 'ventas por producto' from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                " inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                " inner join mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario group by C.idProducto,C.Nombre  order by 'utilidad' desc";

            DataTable productos = EjecutaQuery(sql);


            try
            {
                int i;
                for (i = 0; i < productos.Rows.Count; i++)
                {
                    utilidades.Rows.Add();
                    utilidades[0, i].Value = productos.Rows[i][1].ToString();
                    utilidades[1, i].Value = productos.Rows[i][2].ToString();
                }
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);
            }


        }

        public void masVendidos()
        {
            //Query a ejecutar, solicitan los 5 productos más vendidos
            string sql = "select top 5 C.Nombre, sum(B.Cantidad) as 'ventas por producto' from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta=B.Venta_idVenta " +
                "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario group by C.Nombre order by 'ventas por producto' desc";
            //Se crea una tabla para guardar los datos solicitados 
            DataTable productos = EjecutaQuery(sql);
            


            try
            {
                int i;
                for (i = 0; i < productos.Rows.Count; i++)
                {
                    vendidos.Rows.Add();
                    vendidos[0, i].Value = productos.Rows[i][0].ToString();
                    vendidos[1, i].Value = productos.Rows[i][1].ToString();
                }
            }
            catch (Exception R)
            {
                Console.WriteLine("error inesparado" + R);
            }
        }

        public void menosVendidos()
        {

        }

        private DataTable EjecutaQuery(String sql)
        {
            //Ejecución del query y posteriormente es adaptado en una tabla
            cmd = new SqlCommand(sql, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable datos = new DataTable();
            adapter.Fill(datos);
            //Regresa la tabla ya con los datos solicitados
            return datos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Query a ejecutar, solicita el total de ventas realizadas en los ultimos 7 dias
            String sql = "select TOP 7 DAY(A.Fecha) AS 'DIA', MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) , DAY(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC ,'DIA' DESC";

            //Se crea una tabla y se utiliza el metodo para ejecutar el query
            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();


            int[] dias = new int[7];
            float[] ventas = new float[7];
            int[] mes = new int[7];


            int dia = int.Parse(estadistica.Rows[0][0].ToString());
            dias[0] = int.Parse(estadistica.Rows[0][0].ToString());
            mes[0] = int.Parse(estadistica.Rows[0][1].ToString());
            ventas[0] = float.Parse(estadistica.Rows[0][2].ToString());
            int mesactual = int.Parse(estadistica.Rows[0][1].ToString());



            int j;
            int R = 1;
            for (j = 1; j < 7; j++)
            {
                dia--;

                if (dia == 0)
                {
                    if (mesactual == 2 || mesactual == 4 || mesactual == 6 || mesactual == 8 || mesactual == 9 || mesactual == 11 || mesactual == 1)
                    {
                        dia = 31;
                        if (mesactual != 1)
                        {
                            mesactual = mesactual - 1;
                        }
                        else
                        {
                            mesactual = 12;
                        }

                    }
                    else if (mesactual == 5 || mesactual == 7 || mesactual == 10 || mesactual == 12)
                    {
                        dia = 30;
                        mesactual--;
                    }
                    else
                    {
                        dia = 28;
                        mesactual--;
                    }


                }
                /*
                 *    Meses con 30 días: Abril, Junio, Septiembre y Noviembre.
                      Meses con 31 días: Enero, Marzo, Mayo, Julio, Agosto, Octubre y Diciembre.
                      Meses con 28 días: Febrero (Menos cuando es bisiesto que tiene 29 días).
                 * 
                 * */


                for (R = 1; R < 7; R++)
                {

                    Console.WriteLine("Dia del int: " + dia);
                    Console.WriteLine("dia a comparar " + estadistica.Rows[R][0].ToString());

                    if (int.Parse(estadistica.Rows[R][0].ToString()) == dia & int.Parse(estadistica.Rows[R][1].ToString()) == mesactual)
                    {
                        dias[j] = int.Parse(estadistica.Rows[R][0].ToString());
                        ventas[j] = float.Parse(estadistica.Rows[R][2].ToString());
                        mes[j] = mesactual;


                        break;
                    }
                    else if (R == 6)
                    {

                        dias[j] = dia;
                        ventas[j] = 0;
                        mes[j] = mesactual;
                        break;

                    }

                }
            }


            float total = 0;

            while (i >= 0)
            {
                total += ventas[i];
                chart1.Series["Series1"].Points.AddXY(mes[i] + "/" + dias[i], ventas[i]);
                chart2.Series["Series1"].Points.AddXY(mes[i] + "/" + dias[i], total);
                i--;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 30 DAY(A.Fecha) AS 'DIA', MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) , DAY(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC ,'DIA' DESC";

            DataTable estadistica = EjecutaQuery(sql);
            int i = 29;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();
            int cuenta = 5;

            int[] dias = new int[30];
            float[] ventas = new float[30];
            int[] mes = new int[30];


            int dia = int.Parse(estadistica.Rows[0][0].ToString());
            dias[0] = int.Parse(estadistica.Rows[0][0].ToString());
            mes[0] = int.Parse(estadistica.Rows[0][1].ToString());
            ventas[0] = float.Parse(estadistica.Rows[0][2].ToString());
            int mesactual = int.Parse(estadistica.Rows[0][1].ToString());



            int j;
            int R = 1;
            for (j = 1; j < 30; j++)
            {
                dia--;

                if (dia == 0)
                {
                    if (mesactual == 2 || mesactual == 4 || mesactual == 6 || mesactual == 8 || mesactual == 9 || mesactual == 11 || mesactual == 1)
                    {
                        dia = 31;
                        if (mesactual != 1)
                        {
                            mesactual = mesactual - 1;
                        }
                        else
                        {
                            mesactual = 12;
                        }

                    }
                    else if (mesactual == 5 || mesactual == 7 || mesactual == 10 || mesactual == 12)
                    {
                        dia = 30;
                        mesactual--;
                    }
                    else
                    {
                        dia = 28;
                        mesactual--;
                    }
                }
                /*
                 *    Meses con 30 días: Abril, Junio, Septiembre y Noviembre.
                      Meses con 31 días: Enero, Marzo, Mayo, Julio, Agosto, Octubre y Diciembre.
                      Meses con 28 días: Febrero (Menos cuando es bisiesto que tiene 29 días).
                 * 
                 * */
                for (R = 1; R < estadistica.Rows.Count; R++)
                {
                    if (int.Parse(estadistica.Rows[R][0].ToString()) == dia & int.Parse(estadistica.Rows[R][1].ToString()) == mesactual)
                    {
                        dias[j] = int.Parse(estadistica.Rows[R][0].ToString());
                        ventas[j] = float.Parse(estadistica.Rows[R][2].ToString());
                        mes[j] = mesactual;
                        break;
                    }
                    else if (R == estadistica.Rows.Count - 1)
                    {
                        dias[j] = dia;
                        ventas[j] = 0;
                        mes[j] = mesactual;
                        break;
                    }
                }
            }


            String fecha;
            float total = 0;
            while (i >= 0)
            {
                total = ventas[i] + total;
                if (cuenta == 5)
                {
                    fecha = (mes[i].ToString() + "/" + dias[i].ToString());
                    chart1.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), ventas[i]);
                    cuenta = 0;
                    Console.WriteLine(fecha);

                    chart2.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), total);
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), ventas[i]);

                    chart2.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), total);
                }
                cuenta++;
                i--;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 90 DAY(A.Fecha) AS 'DIA', MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
            "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
              "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
              "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
              "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) , DAY(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC ,'DIA' DESC";

            DataTable estadistica = EjecutaQuery(sql);
            int i = 100;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();


            int cuenta = 15;

            int[] dias = new int[i + 1];
            float[] ventas = new float[i + 1];
            int[] mes = new int[i + 1];


            int dia = int.Parse(estadistica.Rows[0][0].ToString());
            dias[0] = int.Parse(estadistica.Rows[0][0].ToString());
            mes[0] = int.Parse(estadistica.Rows[0][1].ToString());
            ventas[0] = float.Parse(estadistica.Rows[0][2].ToString());
            int mesactual = int.Parse(estadistica.Rows[0][1].ToString());



            int j;
            int R = 1;
            for (j = 1; j < i + 1; j++)
            {
                dia--;

                if (dia == 0)
                {
                    if (mesactual == 2 || mesactual == 4 || mesactual == 6 || mesactual == 8 || mesactual == 9 || mesactual == 11 || mesactual == 1)
                    {
                        dia = 31;
                        if (mesactual != 1)
                        {
                            mesactual = mesactual - 1;
                        }
                        else
                        {
                            mesactual = 12;
                        }

                    }
                    else if (mesactual == 5 || mesactual == 7 || mesactual == 10 || mesactual == 12)
                    {
                        dia = 30;
                        mesactual--;
                    }
                    else
                    {
                        dia = 28;
                        mesactual--;
                    }
                }
                /*
                 *    Meses con 30 días: Abril, Junio, Septiembre y Noviembre.
                      Meses con 31 días: Enero, Marzo, Mayo, Julio, Agosto, Octubre y Diciembre.
                      Meses con 28 días: Febrero (Menos cuando es bisiesto que tiene 29 días).
                 * 
                 * */
                for (R = 1; R < estadistica.Rows.Count; R++)
                {
                    if (int.Parse(estadistica.Rows[R][0].ToString()) == dia & int.Parse(estadistica.Rows[R][1].ToString()) == mesactual)
                    {
                        dias[j] = int.Parse(estadistica.Rows[R][0].ToString());
                        ventas[j] = float.Parse(estadistica.Rows[R][2].ToString());

                        mes[j] = mesactual;
                        break;
                    }
                    else if (R == estadistica.Rows.Count - 1)
                    {
                        dias[j] = dia;
                        ventas[j] = 0;
                        mes[j] = mesactual;
                        break;
                    }
                }
            }


            float total = 0;
            while (i >= 0)
            {
                total += ventas[i];
                if (cuenta == 15)
                {
                    chart1.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), ventas[i]);
                    chart2.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), total);
                    cuenta = 0;
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), ventas[i]);
                    chart2.Series["Series1"].Points.AddXY(mes[i].ToString() + "/" + dias[i].ToString(), total);
                }
                cuenta++;
                i--;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 6 MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por mes ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC;";

            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();

            float total = 0;

            while (i >= 0)
            {
                total += float.Parse(estadistica.Rows[i][1].ToString());
                chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][1].ToString()));
                chart2.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), total);
                i--;
            }
        }
 
        private void button5_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 12 MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por mes ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC;";

            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();
            int cuenta = 2;

            float total = 0;
            while (i >= 0)
            {
                total += float.Parse(estadistica.Rows[i][1].ToString());
                if (cuenta == 2)
                {
                    chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][1].ToString()));
                    chart2.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), total);
                    cuenta = -1;
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(" ", float.Parse(estadistica.Rows[i][1].ToString()));
                    chart2.Series["Series1"].Points.AddXY(" ", total);
                }
                cuenta++;
                i--;
            }

        }

        private void Estadisticas_Paint(object sender, PaintEventArgs e)
        {
            // Área cliente del formulario
            Rectangle r = this.ClientRectangle;
            // Punto intermedio del área
            int c = r.Width / 2;
            // Establecemos la nueva posición del control Label.
            label2.Location = new Point(c - label2.Width / 2, label2.Location.Y);
            label1.Location = new Point(c - label1.Width / 2, label1.Location.Y);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiaDescripcion();
        }

        private void cambiaDescripcion()
        {
            if (comboBox1.Text == "Mensual")
            {
                String sql = "select MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE MONTH(A.Fecha) = "+ DateTime.Now.ToString("MM")+ 
                    " GROUP BY  MONTH(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                DataTable estadistica = EjecutaQuery(sql);
                textDescripcion.Text = "Total de ventas -------------------- " + estadistica.Rows[0][1].ToString() + "\n";

                sql = "select MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad - C.[Costo/unidad]*B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE MONTH(A.Fecha) = " + DateTime.Now.ToString("MM") +
                    " GROUP BY  MONTH(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                estadistica = EjecutaQuery(sql); 
                textDescripcion.Text += "Utilidad total ---------------------- " + estadistica.Rows[0][1].ToString() + "\n";

                sql = "select MONTH(A.Fecha) as 'MES', sum(B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE MONTH(A.Fecha) = " + DateTime.Now.ToString("MM") +
                    " GROUP BY  MONTH(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                estadistica = EjecutaQuery(sql);
                textDescripcion.Text += "Cantidad de productos vendidos -------" + estadistica.Rows[0][1].ToString() + "\n";
            }
            else if(comboBox1.Text == "Anual")
            {
                String sql = "select YEAR(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE YEAR(A.Fecha) = " + DateTime.Now.ToString("yyyy") +
                    " GROUP BY  YEAR(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                DataTable estadistica = EjecutaQuery(sql);
                textDescripcion.Text = "Total de ventas -------------------- " + estadistica.Rows[0][1].ToString() + "\n";

                sql = "select YEAR(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad - C.[Costo/unidad]*B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE YEAR(A.Fecha) = " + DateTime.Now.ToString("yyyy") +
                    " GROUP BY  YEAR(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                estadistica = EjecutaQuery(sql);
                textDescripcion.Text += "Utilidad total ---------------------- " + estadistica.Rows[0][1].ToString() + "\n";

                sql = "select YEAR(A.Fecha) as 'MES', sum(B.Cantidad) as 'total ventas por dia ' " +
                    "from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta = B.Venta_idVenta " +
                    "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                    "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario WHERE YEAR(A.Fecha) = " + DateTime.Now.ToString("yyyy") +
                    " GROUP BY  YEAR(A.Fecha) " +
                    "ORDER BY  'MES' DESC; ";

                estadistica = EjecutaQuery(sql);
                textDescripcion.Text += "Cantidad de productos vendidos -------" + estadistica.Rows[0][1].ToString() + "\n";

            }
        }

        public void cargar()
        {
            //Query a ejecutar, solicita el total de ventas realizadas en los ultimos 7 dias
            String sql = "select TOP 7 DAY(A.Fecha) AS 'DIA', MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por dia ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) , DAY(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC ,'DIA' DESC";

            //Se crea una tabla y se utiliza el metodo para ejecutar el query
            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
            chart2.Series["Series1"].Points.Clear();


            int[] dias = new int[7];
            float[] ventas = new float[7];
            int[] mes = new int[7];


            int dia = int.Parse(estadistica.Rows[0][0].ToString());
            dias[0] = int.Parse(estadistica.Rows[0][0].ToString());
            mes[0] = int.Parse(estadistica.Rows[0][1].ToString());
            ventas[0] = float.Parse(estadistica.Rows[0][2].ToString());
            int mesactual = int.Parse(estadistica.Rows[0][1].ToString());



            int j;
            int R = 1;
            for (j = 1; j < 7; j++)
            {
                dia--;

                if (dia == 0)
                {
                    if (mesactual == 2 || mesactual == 4 || mesactual == 6 || mesactual == 8 || mesactual == 9 || mesactual == 11 || mesactual == 1)
                    {
                        dia = 31;
                        if (mesactual != 1)
                        {
                            mesactual = mesactual - 1;
                        }
                        else
                        {
                            mesactual = 12;
                        }

                    }
                    else if (mesactual == 5 || mesactual == 7 || mesactual == 10 || mesactual == 12)
                    {
                        dia = 30;
                        mesactual--;
                    }
                    else
                    {
                        dia = 28;
                        mesactual--;
                    }


                }
                /*
                 *    Meses con 30 días: Abril, Junio, Septiembre y Noviembre.
                      Meses con 31 días: Enero, Marzo, Mayo, Julio, Agosto, Octubre y Diciembre.
                      Meses con 28 días: Febrero (Menos cuando es bisiesto que tiene 29 días).
                 * 
                 * */


                for (R = 1; R < 7; R++)
                {

                    Console.WriteLine("Dia del int: " + dia);
                    Console.WriteLine("dia a comparar " + estadistica.Rows[R][0].ToString());

                    if (int.Parse(estadistica.Rows[R][0].ToString()) == dia & int.Parse(estadistica.Rows[R][1].ToString()) == mesactual)
                    {
                        dias[j] = int.Parse(estadistica.Rows[R][0].ToString());
                        ventas[j] = float.Parse(estadistica.Rows[R][2].ToString());
                        mes[j] = mesactual;


                        break;
                    }
                    else if (R == 6)
                    {

                        dias[j] = dia;
                        ventas[j] = 0;
                        mes[j] = mesactual;
                        break;

                    }

                }
            }


            float total = 0;

            while (i >= 0)
            {
                total += ventas[i];
                chart1.Series["Series1"].Points.AddXY(mes[i] + "/" + dias[i], ventas[i]);
                chart2.Series["Series1"].Points.AddXY(mes[i] + "/" + dias[i], total);
                i--;
            }
        }
    }
}
