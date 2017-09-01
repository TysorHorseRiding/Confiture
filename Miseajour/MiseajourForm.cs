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
    public partial class MiseajourForm : Form
    {
        internal MiseajourForm(IMiseajour applicationInfo, MiseajourXml updateInfo)
        {
            InitializeComponent();

            if (applicationInfo.ApplicationIcon != null)
                this.Icon = applicationInfo.ApplicationIcon;

            this.Text = applicationInfo.ApplicationName + " - Informations de la mise à jour";
            this.lblVersions.Text = String.Format("Version actuelle: {0}\nNouvelle version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(),
                updateInfo.Version.ToString());
            this.txtDescription.Text = updateInfo.Description;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
        }
    }
}
