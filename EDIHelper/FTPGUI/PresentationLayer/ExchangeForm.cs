namespace FTPGui.PresentationLayer
{
    using System;
    using System.Windows.Forms;
    using DomainModel.Logic;
    using DomainModel.Model;
    using System.IO;

    public partial class ExchangeForm : Form
    {
        public ExchangeForm()
        {
            InitializeComponent();
        }

        private void ExchangeForm_Load(object sender, EventArgs e)
        {
            Settings settings = SettingsContainer.GetSettings();
            this.Logger = new Logger(string.Format("{0}.{1}", "Exchange", "log"), "Exchange");
            this.ExchangeManager = new ExchangeManager(settings.DownloadExchangeFileName, settings.UploadExchangeFileName, settings.ExchangeFolder, this.Logger);
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExchangeManager.LoadAll();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found.", "Error");
                return;
            }
            catch(Exception ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}, {3}", "Downloading error", ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                MessageBox.Show(string.Format("{0}: {1}. {2}", ex.Source, ex.Message, ex.StackTrace), "Error");
                return;
            }
            MessageBox.Show("Success!", "Success");
        }

        private Logger Logger { get; set; }
        private ExchangeManager ExchangeManager { get; set; }

    }
}
