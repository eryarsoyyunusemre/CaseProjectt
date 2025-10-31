using System.ComponentModel.DataAnnotations;
using CaseProject.Entities.IBase;

namespace CaseProject.Entities.Dto;

public class DtoCompany : IDtoBase
{
    [Required] [MaxLength(150)] public string Name { get; set; }

    [MaxLength(250)] public string Address { get; set; }

    [MaxLength(50)] public string Phone { get; set; }
}