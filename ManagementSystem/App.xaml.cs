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
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configure Logging
            services.AddLogging();

            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            });

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ICommentService, CommentService>();

            // Register ViewModels
            services.AddScoped<ICreateTaskViewModel, CreateTaskViewModel>();
            services.AddScoped<IMainViewModel, MainViewModel>();
            services.AddScoped<IAddCommentViewModel, AddCommentViewModel>();

            // Register Views
            services.AddScoped<MainWindow>();
        }
    }
}
