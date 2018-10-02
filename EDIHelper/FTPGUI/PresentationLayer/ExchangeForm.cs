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
            BeginDate.Value = DateTime.Now.AddDays(-1);
            EndDate.Value = DateTime.Now;
            FullUnloadChk.Checked = false;
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

        private void UnloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(FullUnloadChk.Checked)
                {
                    this.ExchangeManager.UnloadAll();
                }   
                else
                {
                    DateTime begin = this.GetDayBeginning(BeginDate.Value);
                    DateTime end = this.GetDayEnding(EndDate.Value);
                    this.ExchangeManager.UnloadToPeriod(begin, end);
                }
            }
            catch(Exception ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}, {3}", "Unloading error", ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                MessageBox.Show(string.Format("{0}: {1}. {2}", ex.Source, ex.Message, ex.StackTrace), "Error");
                return;
            }
            MessageBox.Show("Success!", "Success");
        }

        private DateTime GetDayBeginning(DateTime date)
        {
            return date.Date;
        }

        private DateTime GetDayEnding(DateTime date)
        {
            return this.GetDayBeginning(date).AddDays(1).AddTicks(-1);
        }

        private Logger Logger { get; set; }
        private ExchangeManager ExchangeManager { get; set; }

    }
}
