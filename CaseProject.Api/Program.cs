using CaseProject.Bll.Abstract;
using CaseProject.Bll.Concrete;
using CaseProject.Bll.Mapper.AutoMapper;
using CaseProject.Dal.Abstract;
using CaseProject.Dal.Context;
using CaseProject.Dal.EntityFramework;
using CaseProject.Dal.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CaseProjectContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DbContext, CaseProjectContext>();

builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IProductDal), typeof(EfProductDal));
builder.Services.AddScoped(typeof(ICompanyDal), typeof(EfCompanyDal));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Swagger ayarları
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();