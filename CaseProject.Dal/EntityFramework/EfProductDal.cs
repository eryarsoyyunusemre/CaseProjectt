using CaseProject.Dal.Abstract;
using CaseProject.Dal.Context;
using CaseProject.Dal.Repository;
using CaseProject.Entities.Models;

namespace CaseProject.Dal.EntityFramework;

public class EfProductDal(CaseProjectContext context) : GenericRepository<Product>(context), IProductDal;