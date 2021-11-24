using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace BancaBP.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }
        [DisplayName("Código Cuenta")]
        public int IntCuencodigo { get; set; }
        [DisplayName("Código Cliente")]
        public int IntCliecodigo { get; set; }
        [DisplayName("Número Cuenta")]
        public string VchCuennumero { get; set; }
        [DisplayName("Tipo Cuenta")]
        public string VchCuentipo { get; set; }
        [DisplayName("Saldo Cuenta")]
        public decimal? DecCuensaldo { get; set; }
        [DisplayName("Fecha Creación")]
        public DateTime? DttCuenfechacreacion { get; set; }

        public enum TipoCuenta
        {
            AHORROS,
            CORRIENTE
        }

        public virtual Cliente IntCliecodigoNavigation { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
