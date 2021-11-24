using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BancaBP.Models
{
    public partial class Usuario
    {
        [DisplayName("Código")]
        public int IntUsucodigo { get; set; }
        [DisplayName("Nombre")]
        public string VchUsunombre { get; set; }
        [DisplayName("Apellido")]
        public string VchUsuapellido { get; set; }
        [DisplayName("Cédula")]
        public string VchUsucedula { get; set; }
        [DisplayName("Dirección")]
        public string VchUsudireccion { get; set; }
        [DisplayName("Teléfono")]
        public string VchUsutelefono { get; set; }
        [DisplayName("Email")]
        public string VchUsuemail { get; set; }
        [DisplayName("Usuario")]
        public string VchUsuusuario { get; set; }
        [DisplayName("Password")]
        public string VchUsupassword { get ;set; }
        [DisplayName("Rol")]
        public string VchRol { get; set; }
    }
}
