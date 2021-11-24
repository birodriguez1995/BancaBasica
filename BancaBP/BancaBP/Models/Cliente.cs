using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace BancaBP.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }
        [DisplayName("Código")]
        public int IntCliecodigo { get; set; }
        [DisplayName("Nombre")]
        public string VchClienombre { get; set; }
        [DisplayName("Apellido")]
        public string VchClieapellido { get; set; }
        [DisplayName("Cédula")]
        public string VchCliecedula { get; set; }
        [DisplayName("Dirección")]
        public string VchCliedireccion { get; set; }
        [DisplayName("Teléfono")]
        public string VchClietelefono { get; set; }
        [DisplayName("Email")]
        public string VchClieemail { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
