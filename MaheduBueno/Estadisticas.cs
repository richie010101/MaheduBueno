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
    public partial class Estadisticas : Form
    {

        SqlCommand cmd;
        public Estadisticas()
        {
            InitializeComponent();
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
            
            cmd = new SqlCommand(sql, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable productos = new DataTable();
            adapter.Fill(productos);


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
            string sql = "select top 5 C.Nombre, sum(B.Cantidad) as 'ventas por producto' from mahedu.venta as A inner join mahedu.producto_has_venta as B on A.idVenta=B.Venta_idVenta " +
                "inner join  mahedu.producto as C on B.Producto_idProducto = C.idProducto " +
                "inner join mahedu.usuario as D on D.idUsuario = A.Usuario_idUsuario group by C.Nombre order by 'ventas por producto' desc";

            cmd = new SqlCommand(sql, ManejadorBD.Conectar());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable productos = new DataTable();
            adapter.Fill(productos);


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
    }
}
