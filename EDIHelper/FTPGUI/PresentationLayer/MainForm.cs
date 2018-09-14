namespace FTPGui.PresentationLayer
{
    using System;
    using System.Windows.Forms;
    using DataAccessLayer;
    using BusinessLogicLayer;

    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Репозитой данных.
        /// </summary>
        private Repository repository;
        /// <summary>
        /// Логгер.
        /// </summary>
        private Logger logger;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            logger = new Logger(SettingsContainer.Settings.LogFileFullPath);
            repository = new Repository(logger);
        }

        /// <summary>
        /// Загрузка страницы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.UpdateTable();
        }

        /// <summary>
        /// Клик по пункту меню настроек.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm setForm = new SettingsForm();
            setForm.ShowDialog(this);
        }

        /// <summary>
        /// Клик по кнопке добавить новую запись.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewBtn_Click(object sender, EventArgs e)
        {
            repository.Add(new FTPAccessData(++Repository.LastID, ShopTxt.Text, GLNTxt.Text, LoginTxt.Text, PassTxt.Text, LocalFolderTxt.Text));
            this.UpdateTable();
        }

        /// <summary>
        /// Заполнить таблицу обновленными данными.
        /// </summary>
        private void UpdateTable()
        {
            this.repository.GetData();
            FTPDataAccessTbl.DataSource = this.repository.AccessDataList;
        }

        /// <summary>
        /// Клик по кнопке удалить запись.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if(FTPDataAccessTbl.SelectedRows.Count != 1)
            {
                return;
            }
            int id = (int)FTPDataAccessTbl.SelectedRows[0].Cells["ID"].Value;

            if(this.repository.Remove(id))
            {
                this.UpdateTable();
            }
            else
            {
                MessageBox.Show("Ошибка при удалении записи.");
            }
        }
    }
}
