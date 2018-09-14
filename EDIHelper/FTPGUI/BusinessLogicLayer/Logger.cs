namespace FTPGui.BusinessLogicLayer
{ 
    using System;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Типы логов.
    /// </summary>
    public enum LogTypes
    {
        INFO = 0,
        ERROR,
        WARNING
    }

    /// <summary>
    /// Логгер.
    /// </summary>
    public class Logger
    {
        public Logger(string logFileName)
        {
            this.LogFileName = logFileName;
        }
        /// <summary>
        /// Вывести сообщение на экран.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="caption">Текст шапки.</param>
        public void ShowMessage(string message, string caption = "")
        {
            MessageBox.Show(message, caption);
        }
       
        /// <summary>
        /// Записать лог в файл.
        /// </summary>
        /// <param name="log">Текст лога для записи.</param>
        public void WriteLog(string log, LogTypes type = LogTypes.INFO)
        {
            try
            {
                StringBuilder fullLog = new StringBuilder();
                fullLog.AppendFormat("{0}: {1} {2}.\n", DateTime.Now, type, log);
                Directory.CreateDirectory(Path.GetDirectoryName(this.LogFileName));
                File.AppendAllText(this.LogFileName, fullLog.ToString());
            }
            catch(UnauthorizedAccessException ex)
            {
                this.ShowMessage(string.Format("{0}: {1}", ex.StackTrace, ex.Message), "Access denied.");
            }
            catch (IOException ex)
            {
                this.ShowMessage(string.Format("{0}: {1}", ex.StackTrace, ex.Message), "Error writing log to file.");
            }
        }

        /// <summary>
        /// Полное имя файла логов.
        /// </summary>
        public string LogFileName { get; private set; }
    }
}
