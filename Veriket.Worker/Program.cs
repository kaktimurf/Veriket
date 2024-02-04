using Veriket.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(b =>
    {
        b.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
    })
    .ConfigureServices((hostContex, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .UseWindowsService(options =>
    {
        options.ServiceName = "Veriket Application Test";
    })
    .Build();

host.Run();
