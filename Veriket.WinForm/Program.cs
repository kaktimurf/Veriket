using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Veriket.WinForm
{
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            RunExistingBat();
            Application.Run(new Form1());
        }

        static void RunExistingBat()
        {
            string ConfigFileName = "RunFlag.txt";
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
            if (File.Exists(configFilePath))
            { 

            }
            else
            {
                //File.Create(configFilePath);
                var workerProjectPathRelative = AppDomain.CurrentDomain.BaseDirectory.Split("\\Veriket.WinForm\\");
                string workerProjectPath = Path.GetFullPath(Path.Combine(workerProjectPathRelative[0], "Veriket.Worker\\bin\\Debug\\net7.0"));

                string batFilePath = Path.Combine(workerProjectPath,"InstallService.bat");
                batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InstallService.bat");
                if (!File.Exists(batFilePath))
                {
                    File.Create(batFilePath).Close();

                    File.AppendAllText(batFilePath, "sc create \"Veriket App Test\" binPath=\"Veriket.Worker.exe\" start=auto\n");
                    File.AppendAllText(batFilePath, "sc start \"Veriket App Test\"");
                                              
                    //File.WriteAllText(batFilePath, "sc create 'Veriket App Test' binPath='./Veriket.Worker.exe start=auto'",System.Text.Encoding.UTF8);
                    //File.WriteAllText(batFilePath, "sc start 'Veriket App Test'");
                }
                if (File.Exists(batFilePath))
                {

                    //File.Create(batFilePath).Close();
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
                    Console.WriteLine("Var olan bat dosyası bulunamadı.");
                }
            }
            
        }
    }
}