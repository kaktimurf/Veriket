using System.Diagnostics;
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

/*
 RunExistingBat metodu worker projesini derlendikten sonra oluşan bir bat dosyasını bir defaya mahsus çalıştırarak 
 bu projeyi bir windows servisi olarak ayağa kaldırmaktadır.
 Bat dosyasının içeriği:
    sc create "Veriket Test App" binPath="..." start=auto
    sc start "Veriket Test App"
 */
RunExistingBat(); 
host.Run();

static void RunExistingBat()
{
    string ConfigFileName = "RunFlag.txt";
    string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
    if (File.Exists(configFilePath))
    {
        Console.WriteLine("Service zaten oluşturulmuş.");
    }
    else
    {
        File.Create(configFilePath);


        string batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InstallService.bat");
        if (File.Exists(batFilePath))
        {
            // Oluşturduğum bat dosyasını çalıştır bi nevi cmd 
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = batFilePath,
                UseShellExecute = true,
                CreateNoWindow = true,
                Verb = "runas" // Yönetici olarak çalıştır
            };

            Process.Start(psi);
        }
        else
        {
            Console.WriteLine("Bat dosyası bulunamadı.");
        }
    }

}