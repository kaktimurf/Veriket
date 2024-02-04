using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Veriket.WinForm
{
    public partial class Form1 : Form
    {
        private readonly LogFileOptions _logFileOptions;
        public Form1()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            _logFileOptions = configuration.GetSection("LogFileOptions").Get<LogFileOptions>();
            InitializeComponent();
            InitializeShowLogsButton();


        }
        

        private void btnCsv_Click(object sender, EventArgs e)
        {
            var logFileDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), _logFileOptions.DirectoryName);
            if (!Directory.Exists(logFileDirectory))
            {
                MessageBox.Show(Messages.DirectoryNotFoundText(logFileDirectory),Messages.DirectoryNotFoundHeader);
                return;
            }
            string logFilePath = Path.Combine(logFileDirectory,_logFileOptions.FileName);
            if (!File.Exists(logFilePath))
            {
                MessageBox.Show(Messages.FileNotFoundText(logFilePath), Messages.FileNotFoundHeader);
                return;
            }

            try
            {
                //using FileStream fs = new FileStream(logFilePath, FileMode.OpenOrCreate,FileAccess.Read);
                using StreamReader sr = new StreamReader(logFilePath);
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    var splitText = satir.Split(',');
                    dataGridView1.Rows.Add(splitText[0], splitText[1], splitText[2]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.AnErrorText(ex.Message),Messages.AnErrorHeader);
                return;
            }

        }


        #region ResizeButton
        private void InitializeShowLogsButton()
        {
            btnCsv.Size = new Size(118, 42);

            // Butonun konumunu ayarlıyoruz (formun üst orta kısmı)
            btnCsv.Location = new Point((this.ClientSize.Width - btnCsv.Width) / 2, 20);

            // Butonun boyutunu değiştirmek için Resize olayına subscribe oluyoruz
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Formun boyutu değiştiğinde butonun konumunu yeniden ayarlıyoruz
            btnCsv.Location = new Point((this.ClientSize.Width - btnCsv.Width) / 2, 20);
        }
        #endregion;
    }
}
