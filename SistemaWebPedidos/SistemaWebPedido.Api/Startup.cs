using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SistemaWebPedidos.Api.Configurations;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.Services;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using SistemaWebPedidos.Infrastructure.Persistence;
using SistemaWebPedidos.Infrastructure.Persistence.Repository;

namespace SistemaWebPedido.Api
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
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddIdentityConfiguration(Configuration);

            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }); 
            
        services.AddControllers();
            services.AddSwaggerGen(c =>
            {       
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaWebPedido.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaWebPedido.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
