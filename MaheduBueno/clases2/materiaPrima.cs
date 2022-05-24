using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaheduBueno.clases2
{
    class materiaPrima
    {
        private int idMateria;
        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }



        private String skuM;
        public String SkuM
        {
            get { return skuM; }
            set
            {
                skuM = value;
            }
        }


        private String nombreM;
        public String NombreM
        {
            get { return nombreM; }
            set
            {
                nombreM = value;
            }
        }

        private String descripcionM;
        public String DescripcionM
        {
            get { return descripcionM; }
            set { descripcionM = value; }
        }

        private float cantidad;
        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

    }
}
