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
            int i = estadistica.Rows.Count-1;
            chart1.Series["Series1"].Points.Clear();

            while (i>=0)
            {
                /*if(i != estadistica.Rows.Count - 1)
                {
                    int com = int.Parse(estadistica.Rows[i][0].ToString()) - 1;
                    if (com != int.Parse(estadistica.Rows[i + 1][0].ToString()))
                    {
                        chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][1].ToString() + "/" + (int.Parse(estadistica.Rows[i-1][0].ToString())-1), 0);
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][1].ToString() + "/" + estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][2].ToString()));
                    }
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][1].ToString() + "/" + estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][2].ToString()));
                }*/
                chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][1].ToString()+"/"+estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][2].ToString()));       
                //chart1.Series["Series1"].Points.AddY(float.Parse(estadistica.Rows[i][2].ToString()));
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
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
            int cuenta = 5;
            while (i>=0)
            {
                if (cuenta == 5)
                {
                    chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][1].ToString() + "/" + estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][2].ToString()));
                    cuenta = -1;
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(" ",float.Parse(estadistica.Rows[i][2].ToString()));
                }
                cuenta++;
                i--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 3 MONTH(A.Fecha) as 'MES', sum(C.Precio*B.Cantidad) as 'total ventas por mes ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ,MONTH(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC,'MES' DESC;";

            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();

            while (i >= 0)
            {        
                chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][1].ToString()));
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

            while (i >= 0)
            {
                chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][1].ToString()));
                i--;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String sql = "select TOP 5 YEAR(A.Fecha) as 'AÑO', sum(C.Precio*B.Cantidad) as 'total ventas por año ' " +
                "from mahedu.venta as A inner join mahedu.producto_has_venta as B on " +
                "A.idVenta = B.Venta_idVenta inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join  mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario " +
                "GROUP BY  YEAR(A.Fecha) ORDER BY  YEAR(A.Fecha) DESC";

            DataTable estadistica = EjecutaQuery(sql);
            int i = estadistica.Rows.Count - 1;
            chart1.Series["Series1"].Points.Clear();
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
            int cuenta = 2;

            while (i >= 0)
            {
                if (cuenta == 2)
                {
                    chart1.Series["Series1"].Points.AddXY(estadistica.Rows[i][0].ToString(), float.Parse(estadistica.Rows[i][1].ToString()));
                    cuenta = -1;
                }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(" ", float.Parse(estadistica.Rows[i][1].ToString()));
                }
                cuenta++;
                i--;
            }

        }
    }
}
