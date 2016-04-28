namespace ODataSample
{
    using Microsoft.AspNetCore.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using ODataSample.Models;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOData<ISampleService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOData("odata");
            app.UseMvc();
        }
    }
}