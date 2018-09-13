namespace FTPTransporter
{
    using System.ComponentModel;
    using System.ServiceProcess;
    using System.Configuration.Install;
    using FTPGui.BusinessLogicLayer;

    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public Installer1()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.User
            };
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = SettingsContainer.Settings.ServiceName;
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
