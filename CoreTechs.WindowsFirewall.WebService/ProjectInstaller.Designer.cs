namespace CoreTechs.WindowsFirewall.WebService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirewallServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.FirewallServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // FirewallServiceProcessInstaller
            // 
            this.FirewallServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.FirewallServiceProcessInstaller.Password = null;
            this.FirewallServiceProcessInstaller.Username = null;
            // 
            // FirewallServiceInstaller
            // 
            this.FirewallServiceInstaller.Description = "CoreTechs Firewall Service";
            this.FirewallServiceInstaller.DisplayName = "CoreTechs Firewall Service";
            this.FirewallServiceInstaller.ServiceName = "CoreTechs.FirewallService";
            this.FirewallServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.FirewallServiceProcessInstaller,
            this.FirewallServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller FirewallServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller FirewallServiceInstaller;
    }
}