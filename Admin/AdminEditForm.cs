using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class AdminEditForm : Form
    {
        public AdminEditForm()
        {
            InitializeComponent();
            using (MySqlConnection connection = new MySqlConnection(Uloc.Uloc.connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM adminuser WHERE id = '1'", connection);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    MySqlDataReader reader = command.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        this.textBox1.Text = reader["version"].ToString();
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Uloc.Uloc.connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE adminuser SET version=@version WHERE id = '1'", connection);
                    command.Parameters.AddWithValue("@version", this.textBox1.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Version mise à jour !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }
    }
}
