namespace FTPTransporter
{
    using System;
    using System.IO;
    using System.ComponentModel;
    using System.ServiceProcess;
    using System.Configuration.Install;
   // using DomainModel.Logic;
    using System.Reflection;

    [RunInstaller(true)]
    public partial class Installer1 : Installer
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
            //Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            serviceInstaller.ServiceName = "EDITransport";// SettingsContainer.GetSettings().ServiceName;
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
