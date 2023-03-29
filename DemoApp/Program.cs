using Avalonia;
using Avalonia.ReactiveUI;
using Baksteen.Avalonia.Blazor;
using Baksteen.Blazor;
using DemoApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoApp;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var appBuilder = Host.CreateApplicationBuilder(args);
        appBuilder.Logging.AddDebug();
        appBuilder.Services.AddBSAvaloniaBlazorWebView();                 // this wraps: appBuilder.Services.AddWindowsFormsBlazorWebView();
        appBuilder.Services.AddBSAvaloniaBlazorWebViewDeveloperTools();   // this wraps: appBuilder.Services.AddBlazorWebViewDeveloperTools();
        appBuilder.Services.AddSingleton<WeatherForecastService>();
        using var myApp = appBuilder.Build();

        myApp.Start();
        BuildAvaloniaApp(myApp.Services)
            .StartWithClassicDesktopLifetime(args);

        Task.Run(async () => await myApp.StopAsync()).Wait();
    }

    private static AppBuilder BuildAvaloniaApp(IServiceProvider serviceProvider)
        => AppBuilder.Configure<App>(() => new App(serviceProvider))
            .UsePlatformDetect()
            .LogToTrace()
            //.UseManagedSystemDialogs()
            .UseReactiveUI();

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() => BuildAvaloniaApp(null!);
}
