using GoodBooks.Data;
using GoodBooks.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoodBooks.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // Connection to database - SQLite3 in this case!
            services.AddDbContext<GoodBooksDbContext>(opts => {
                opts.EnableDetailedErrors();
                // DefaultConnection: appsettings.Development.json (overwriting appsettings.json)
                opts.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });

            // // Examples (add reference GoodBooks.Services):
            // services.AddSingleton<IBookService, BookService>();
            // services.AddScoped<IBookService, BookService>();
            services.AddTransient<IBookService, BookService>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                .WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
            );            

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
