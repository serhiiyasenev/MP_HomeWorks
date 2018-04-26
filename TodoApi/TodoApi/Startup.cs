using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Filters;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc(options =>
            {
                options.Filters.Add(
                new AddHeaderAttribute("GlobalAddHeader", "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(ActionFilter)); // by type
            });

            services.AddScoped<AddHeaderFilterWithDi>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}