using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Dominio.Entidades
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        
        [StringLength(50)]
        public string Perfil { get; set; } = default!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(24)]
        public string Senha { get; set; } = default!;
    }
}