using System;
using System.Collections.Generic;
using System.Text;

namespace inventarioRM.WS
{
    public class Inventario
    {
        public int codigo {get;set;}
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public string fechaIngreso { get; set; }
        public string proveedor { get; set; }

    }
}
