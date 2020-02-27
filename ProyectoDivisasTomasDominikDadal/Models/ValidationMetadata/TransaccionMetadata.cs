using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.Models.ValidationMetadata
{
    public class TransaccionMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        
        public string sku { get; set; }
        [Required]
        [DisplayName("Cantidad")]
        
        public int amount { get; set; }

        [Required]
        [DisplayName("Currency")]
        [DataType(DataType.Currency)]
        public string currency { get; set; }
        
    }
    [MetadataType(typeof(TransaccionMetadata))]
    public partial class Transaccion { }
}
    
