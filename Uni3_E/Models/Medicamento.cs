using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uni3_E.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string CasaFarmaceutica { get; set; }
    }
}