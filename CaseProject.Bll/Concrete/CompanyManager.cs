using AutoMapper;
using CaseProject.Bll.Abstract;
using CaseProject.Dal.Abstract;
using CaseProject.Entities.Models;

namespace CaseProject.Bll.Concrete;

public class CompanyManager(IGenericDal<Company> genericDal, IMapper mapper)
    : GenericManager<Company>(genericDal, mapper), ICompanyService;