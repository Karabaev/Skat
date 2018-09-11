using System;
using System.Runtime.InteropServices;

namespace DateComponent
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("541697FB-7E00-4A37-9E6E-D7206376F099")]
    public interface IDateTimePicker
    {
        void Show(string caption);
        string GetDateString();
    }

    [ClassInterface(ClassInterfaceType.None), Guid("8E116A3F-B69D-4437-87CB-0D72F33C6187"), ProgId("DateTimePicker.Main")]
    public class DateTimePicker : IDateTimePicker
    {
        public void Show(string caption)
        {
            MainForm form = new MainForm();
            form.CaptionLbl.Text = caption;
            form.ShowDialog();
        }

        public string GetDateString()
        {
            return Date.ToShortDateString();
        }

        public static DateTime Date { get; set; }
    }
}
