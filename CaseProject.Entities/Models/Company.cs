using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseProject.Entities.Base;
using CaseProject.Entities.IBase;

namespace CaseProject.Entities.Models;

public class Company : EntityBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Firma adı zorunludur.")]
    [MaxLength(150)]
    public string Name { get; set; }

    [MaxLength(250)] public string Address { get; set; }

    [MaxLength(50)] public string Phone { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}