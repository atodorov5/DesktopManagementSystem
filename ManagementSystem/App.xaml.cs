using ManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Windows;

namespace ManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost host;

        public App()
        {
            host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    //Add business services as needed
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
                    });


                }).Build();

        }
    }

}
