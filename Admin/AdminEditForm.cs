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
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM adminuser WHERE id = '1'", connection);

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
    }
}
