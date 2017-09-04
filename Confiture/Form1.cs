using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miseajour;

namespace Confiture
{
    public partial class Form1 : Form, IMiseajour
    {
        public double Nombre;
        public bool _ConvertToConfiture;
        public bool _ConvertToSucre;

        public string Erreur = "Conversion impossible";

        public string ApplicationName { get { return "Confiture"; } }

        public string ApplicationID { get { return "Confiture"; } }

        public Assembly ApplicationAssembly { get { return Assembly.GetExecutingAssembly(); } }

        public Icon ApplicationIcon { get { return this.Icon; } }

        public Uri UpdateXmlLocation { get { return new Uri("https://nesquiik3.000webhostapp.com/update.xml"); } }

        public Form Context { get { return this; } }

        private MiseajourUpdater updater;

        public Form1()
        {
            InitializeComponent();
            this.label3.Text = this.ApplicationAssembly.GetName().Version.ToString();
            updater = new MiseajourUpdater(this);
            updater.DoUpdate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(label2.Text != "0")
            {
                label2.Text = ConvertToConfiture(textBox1.Text).ToString();
            }
            _ConvertToConfiture = true;
            _ConvertToSucre = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label2.Text != "0")
            {
                label2.Text = ConvertToSucre(textBox1.Text).ToString();
            }
            _ConvertToSucre = true;
            _ConvertToConfiture = false;
        }

        public static double ConvertToConfiture(string kg)
        {
            if(Double.TryParse(kg, out double result))
            {
                return Math.Round(result * 7 / 10);
            }
            return 0;
        }

        public static double ConvertToSucre(string kg)
        {
            if (Double.TryParse(kg, out double result))
            {
                return Math.Round(result / 7 * 10);
            }
            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_ConvertToConfiture == true)
            {
                if(label2.Text == "0")
                    label2.Text = "Conversion impossible";
                else
                    label2.Text = ConvertToConfiture(textBox1.Text).ToString();
            }

            if (_ConvertToSucre == true)
            {
                if (label2.Text == "0")
                    label2.Text = "Conversion impossible";
                else
                    label2.Text = ConvertToSucre(textBox1.Text).ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (Char)Keys.Back)
            {
                if(Char.IsControl(e.KeyChar) || !Char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
                return;
            }
        }
    }
}
