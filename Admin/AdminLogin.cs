using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Uloc;

namespace Admin
{
    public partial class AdminLogin : Form
    {

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Uloc.Uloc.connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("SELECT * from adminuser WHERE user=@username AND password=@password", connection);
                    command.Parameters.AddWithValue("@username", this.textBox1.Text);
                    command.Parameters.AddWithValue("@password", this.textBox2.Text);
                    MySqlDataReader myReader;

                    connection.Open();
                    myReader = command.ExecuteReader();
                    int count = 0;

                    while (myReader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Connecté !");
                        AdminEditForm adminedit = new AdminEditForm();
                        adminedit.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Login ou mot de passe incorrect.");
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
