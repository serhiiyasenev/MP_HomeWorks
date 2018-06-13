using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Filters;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TodoContext")));
            services.AddMvc(options =>
            {
                options.Filters.Add(
                    new AddHeaderAttribute("GlobalAddHeader", "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(ActionFilter)); // by type
            });

            //services.AddDbContext<TodoContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("TodoContext")));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}