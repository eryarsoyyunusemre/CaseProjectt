using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseProject.Entities.Base;

namespace CaseProject.Entities.Models;

public class Product : EntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [MaxLength(150)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Barkod numarası zorunludur.")]
    [MaxLength(50)]
    public string Barcode { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }

    [MaxLength(500)] public string Description { get; set; }

    [Required]
    [ForeignKey(nameof(Company))]
    public int CompanyId { get; set; }

    public Company Company { get; set; }
}