using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PedidoServidor.Models
{
    [Table("Usuario")]
     public class Usuario
    {
        [Key]
        [StringLength(50)]
        [Required]
        public int Numero { get; set; }

        [StringLength(50)]
        [Required]
        public String Nombre { get; set; }

        [Required]
        public EmailAddressAttribute Mail { get; set; }

        [Required]
        public String Celular { get; set; }

        [Required]
        public String Nickname { get; set; }

        [Required]
        public String Password { get; set; }
        
    }
}