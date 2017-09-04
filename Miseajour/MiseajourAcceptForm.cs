using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miseajour
{
    public partial class MiseajourAcceptForm : Form
    {
        private IMiseajour applicationInfo;

        private MiseajourXml updateInfo;

        private MiseajourForm updateInfoForm;

        internal MiseajourAcceptForm(IMiseajour applicationInfo, MiseajourXml updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Mise à jour disponible";

            // Assigns the icon if it isn't null
            if (this.applicationInfo.ApplicationIcon != null)
                this.Icon = this.applicationInfo.ApplicationIcon;

            // Adds the update version # to the form
            this.lblNewVersion.Text = String.Format("Nouvelle version: {0}", this.updateInfo.Version.ToString());
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
                this.updateInfoForm = new MiseajourForm(this.applicationInfo, this.updateInfo);

            // Shows the details form
            this.updateInfoForm.ShowDialog(this);
        }
    }
}
