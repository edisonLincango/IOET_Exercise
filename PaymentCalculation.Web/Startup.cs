using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentCalculation.ApplicationLayer.Employee;
using PaymentCalculation.DomainModelLayer.HourlyCosts;
using PaymentCalculation.DomainModelLayer.Services;
using PaymentCalculation.Helpers.Domain;
using PaymentCalculation.InfrastructureLayer;

namespace PaymentCalculation.Web
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
            services.AddSingleton<ICostPerHourRepository, CostPerHourRepository>(x =>
            {
                var memRepository = new MemoryRepository<CostPerHour>(); 
                return new CostPerHourRepository(memRepository);
            });

            services.AddSingleton<IDomainService, EmployeeDomainService>(x => {
                var costPerHourRepository = x.GetRequiredService<ICostPerHourRepository>();
                return new EmployeeDomainService(costPerHourRepository);

            });

            services.AddSingleton<IEmployeeService, EmployeeService>(x => {                
                var employeeDomainService = x.GetRequiredService<IDomainService>();
                return new EmployeeService(employeeDomainService);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
