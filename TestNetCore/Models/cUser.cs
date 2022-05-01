using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNetCore.Models
{
    public class cUser
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage ="Este campo es obligatorio")]
        [DisplayName("Usuario")]
        public string User { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [DisplayName("Contraseña")]
        public string Pass { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DisplayName("Fecha de nacimiento")]
        public DateTime Created_at { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
    }
}
