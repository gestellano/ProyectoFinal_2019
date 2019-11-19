using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Vendedor")]
    public class Vendedor : Usuario
    {
        [Key]
        [Required]
        public Boolean TieneVehiculo{ get; set; }

        [StringLength(200)]
        [Required]
        public String ZonaTrabajo { get; set; }

    }
}