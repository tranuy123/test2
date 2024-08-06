using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using test2.Models.Entities;
using Newtonsoft.Json;
using test2.Models.FunctionDB;
using test2.Services.HangHoaServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/json" });
});
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<DemoNhaKhoaContext>(c =>
        c.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddDbContext<FunctionDBContext>(c =>
        c.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
// Add services to the container.
builder.Services.AddScoped<IHhDmHangHoaServices, HhDmHangHoaServices>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//T�nh Comment