using ManagementSystem.Data;
using ManagementSystem.Services;
using ManagementSystem.ViewModel;
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
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configure Logging
            services.AddLogging();

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ICommentService, CommentService>();

            // Register ViewModels
            services.AddSingleton<ICreateTaskViewModel, CreateTaskViewModel>();
            services.AddSingleton<IMainViewModel, MainViewModel>();
            services.AddSingleton<IAddCommentViewModel, AddCommentViewModel>();

            // Register Views
            services.AddSingleton<MainWindow>();

            //Add business services as needed
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            });
        }

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
