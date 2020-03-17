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

       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }        

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        [Key]
        public string Nickname { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(200)]
        [Required]
        public string ZonaTrabajo { get; set; }

        [Required]
        public bool TieneVehiculo { get; set; }

    }
}