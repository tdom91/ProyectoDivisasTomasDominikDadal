using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.Models.ValidationMetadata
{
    public class DivisaMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre Divisa")]
        public string from { get; set; }
        [Required]
        [DisplayName("Nombre divisa destino")]
        
        public string to { get; set; }
        [Required]
        [DisplayName("Rate")]
        
        public string rate { get; set; }
        
        
    }
    [MetadataType(typeof(DivisaMetadata))]
    public partial class Divisa { }
}
    
