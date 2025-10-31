using System.ComponentModel.DataAnnotations;
using CaseProject.Entities.IBase;

namespace CaseProject.Entities.Dto;

public class DtoProduct : IDtoBase
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Barcode { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public int CompanyId { get; set; }
}