using CourseProject.Repositories;
using CourseProject.Repositories.Abstractions;
using CourseProject.Repositories.Implementations;
using CourseProject.Services.Abstractions;
using CourseProject.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<NoFakeShoesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IShoesRepository, ShoesRepository>();
builder.Services.AddScoped<IShoesService, ShoesService>();
builder.Services.AddScoped<IShoeSupplierRepository, ShoeSupplierRepository>();
builder.Services.AddScoped<IShoe_ShoeSupplierRepository, Shoe_ShoeSupplierRepository>();
builder.Services.AddScoped<IShoeSupplierService, ShoeSupplierService>();
builder.Services.AddScoped<IRatingsRepository, RatingsRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<NoFakeShoesDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shoes}/{action=AllShoes}");


app.Run();
