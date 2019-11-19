using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PedidoServidor.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Required]
        public String Rut { get; set; }

        [StringLength(50)]
        [Required]
        public String NombreEmp { get; set; }

        [StringLength(50)]
        [Required]
        public String Direccion { get; set; }

        [StringLength(50)]
        public String Telefono { get; set; }

        [StringLength(50)]
        [Required]
        public String Ciudad { get; set; }
        
    }
}