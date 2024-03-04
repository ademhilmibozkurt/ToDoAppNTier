using Microsoft.Extensions.FileProviders;
using ToDoAppNTier.Business.DependencyResolver.Microsoft;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDependencies();

        var app = builder.Build();

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
            RequestPath = "/node_modules"
        });

        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}