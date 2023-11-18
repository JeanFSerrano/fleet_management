using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace fleet_management.Models
{

    [Table("Fleet")]
    public class Fleet
    {
        [Key]
        [NotNull]
        public Guid Id { get; set; }

        [NotNull]
        [MinLength(3)]
        [MaxLength(70)]
        public string? Name { get; set; }


        [NotNull]
        [MinLength(30)]
        [MaxLength(50)]
        public string? Cnpj { get; set; }
    }
}