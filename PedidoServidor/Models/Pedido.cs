using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string RutCliente{ get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int EstadoImpresion { get; set; }        

        [Required]
        public string Vendedor { get; set; }

        [StringLength(50)]
        [Required]
        public String TipoEnvio { get; set; }
        
    }
}