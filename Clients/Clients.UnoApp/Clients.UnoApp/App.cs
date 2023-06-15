using Clients.UnoApp.Presentation.Registration;

namespace Clients.UnoApp
{
    public class App : Application
    {
        private static Window? _window;
        public static IHost? Host { get; private set; }

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var builder = this.CreateBuilder(args)

                // Add navigation support for toolkit controls such as TabBar and NavigationView
                .UseToolkitNavigation()
                .Configure(host => host
#if DEBUG
				// Switch to Development environment when running in DEBUG
				.UseEnvironment(Environments.Development)
#endif
                    .UseLogging(configure: (context, logBuilder) =>
                    {
                        // Configure log levels for different categories of logging
                        logBuilder.SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning);
                    }, enableUnoLogging: true)
                    .UseConfiguration(configure: configBuilder =>
                        configBuilder
                            .EmbeddedSource<App>()
                            .Section<AppConfig>()
                    )
                    // Register Json serializers (ISerializer and ISerializer)
                    .UseSerialization((context, services) => services
                        .AddContentSerializer(context)
                        .AddJsonTypeInfo(WeatherForecastContext.Default.IImmutableListWeatherForecast))
                    .UseHttp((context, services) => services
                            // Register HttpClient
#if DEBUG
						// DelegatingHandler will be automatically injected into Refit Client
						.AddTransient<DelegatingHandler, DebugHttpHandler>()
#endif
                            .AddSingleton<IWeatherCache, WeatherCache>()
                            .AddRefitClient<IApiClient>(context))
                    .ConfigureServices((context, services) =>
                    {
                        // TODO: Register your services
                        //services.AddSingleton<IMyService, MyService>();
                    })
                    .UseNavigation(RegisterRoutes)
                );

            _window = builder.Window;
            _window.Title = "iBExpert";

            Host = await builder.NavigateAsync<Shell>();
        }

        private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
        {
            views.Register(
                new ViewMap(ViewModel: typeof(ShellViewModel)),
                new ViewMap<MainPage, MainViewModel>(),
                new ViewMap<AuthPage, AuthViewModel>(),
                new ViewMap<RegistrationPage, RegistrationViewModel>(),
                new ViewMap<Registration2Page, RegistrationViewModel2>(),
                new ViewMap<Registration3Page, RegistrationViewModel3>(),
                new ViewMap<Registration4Page, RegistrationViewModel4>(),
                new ViewMap<Registration5Page, RegistrationViewModel5>(),
                new ViewMap<Registration6Page, RegistrationViewModel6>(),
                new DataViewMap<SecondPage, SecondViewModel, Entity>()
            );

            routes.Register(
                new RouteMap("", View: views.FindByViewModel<ShellViewModel>(),
                    Nested: new RouteMap[]
                    {
                    new RouteMap("Main", View: views.FindByViewModel<MainViewModel>()),
                    new RouteMap("Second", View: views.FindByViewModel<SecondViewModel>()),
                    new RouteMap("Registration", View: views.FindByViewModel<RegistrationViewModel>()),
                    new RouteMap("Registration2", View: views.FindByViewModel<RegistrationViewModel2>()),
                    new RouteMap("Registration3", View: views.FindByViewModel<RegistrationViewModel3>()),
                    new RouteMap("Registration4", View: views.FindByViewModel<RegistrationViewModel4>()),
                    new RouteMap("Registration5", View: views.FindByViewModel<RegistrationViewModel5>()),
                    new RouteMap("Registration6", View: views.FindByViewModel<RegistrationViewModel6>()),
                    new RouteMap("Auth", View: views.FindByViewModel<AuthViewModel>()),
                    }
                )
            );
        }
    }
}