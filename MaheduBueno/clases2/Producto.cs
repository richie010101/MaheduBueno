using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaheduBueno.clases2
{
    class Producto
    {



        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }



        private String sku;
        public String Sku
        {
            get { return sku; }
            set
            {
                sku = value;
            }
        }
        //nombre, descripcion, costo, cantidad, precio, cantidad mas, cantidad min

        private int cantidadMin;
        public int CantidadMin
        {
            get { return cantidadMin; }
            set { cantidadMin = value; }
        }

        private int cantidadMax;
        public int CantidadMax
        {
            get { return cantidadMax; }
            set { cantidadMax = value; }
        }

        private float precio;
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private String nombre;
        public String Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
            }
        }

        private String descripcion;
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private float costo;
        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }
    }
}
