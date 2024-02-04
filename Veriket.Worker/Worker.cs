using Microsoft.Extensions.Options;

namespace Veriket.Worker
{
    public class Worker : BackgroundService
    {
        private string _logFilePath;
        IConfiguration _configuration;
        LogFileOptions _logFileOptions;
        public Worker(IConfiguration configuration)
        {
            _configuration = configuration;
            _logFileOptions = _configuration.GetSection("LogFileOptions").Get<LogFileOptions>();
            string logsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), _logFileOptions.DirectoryName);
            Directory.CreateDirectory(logsDirectory);
            _logFilePath = Path.Combine(logsDirectory, _logFileOptions.FileName);
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            string logsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), _logFileOptions.DirectoryName);
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
                _logFilePath = Path.Combine(logsDirectory, _logFileOptions.FileName);
                Directory.CreateDirectory(_logFilePath);
            }
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                try {
                    using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8))
                    {
                        string logEntry = $"{DateTime.Now},{Environment.MachineName},{Environment.UserName}";
                        writer.WriteLine(logEntry);
                    }
                }
                catch(Exception e) 
                {
                    await Console.Out.WriteLineAsync(e.Message);
                }
                
                await Task.Delay(_logFileOptions.LogPeriod, stoppingToken);
            }
        }
    }
}