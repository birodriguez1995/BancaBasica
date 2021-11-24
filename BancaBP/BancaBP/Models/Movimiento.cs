using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace BancaBP.Models
{
    public partial class Movimiento
    {
        [DisplayName("Código Movimiento")]
        public int IntMovicodigo { get; set; }
        [DisplayName("Código Cuenta")]
        public int IntCuencodigo { get; set; }
        [DisplayName("Movimiento Fecha")]
        public DateTime? DttMovifecha { get; set; }
        [DisplayName("Tipo Movimiento")]
        public string VchMovitipo { get; set; }
        [DisplayName("Valor Movimiento")]
        public decimal? DecMovivalor { get; set; }
        [DisplayName("Movimiento Saldo Final")]
        public decimal? DecMovisaldofinal { get; set; }
        [DisplayName("Cuenta Origen")]
        public string VchMovicuentorig { get; set; }
        [DisplayName("Cuenta Destino")]
        public string VchMovicuentdest { get; set; }

        public virtual Cuenta IntCuencodigoNavigation { get; set; }
    }
}
