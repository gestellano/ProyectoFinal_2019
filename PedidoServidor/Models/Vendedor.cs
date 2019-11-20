using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {

        [Key]
        [Required]
        public int Numero { get; set; }        

        [StringLength(50)]
        [Required]
        public String Nombre { get; set; }

        [Required]
        public String Mail { get; set; }

        [Required]
        public String Celular { get; set; }

        [Required]
        public String Nickname { get; set; }

        [Required]
        public String Password { get; set; }

        [StringLength(200)]
        [Required]
        public String ZonaTrabajo { get; set; }

        [Required]
        public Boolean TieneVehiculo { get; set; }

    }
}