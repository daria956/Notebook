using Microsoft.EntityFrameworkCore;
using Notebook.Data;
using Notebook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NoteContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("NoteContext")), ServiceLifetime.Singleton);
//builder.Services.AddSingleton<INoteBookService, NoteBookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using(var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<NoteContext>();
    if (context.Database.EnsureCreated())
    {
        DbInitializer.Initialize(context);
    }
}
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
