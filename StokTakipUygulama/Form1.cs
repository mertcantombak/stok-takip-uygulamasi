using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StokTakipUygulama
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ELHQJHB\SQLEXPRESS;Initial Catalog=StokTakipVTYS;
                                                     Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Places' table. You can move, or remove it, as needed.
            this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.SystemUsers' table. You can move, or remove it, as needed.
            this.systemUsersTableAdapter.Fill(this.stokTakipVTYSDataSet.SystemUsers);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Brands' table. You can move, or remove it, as needed.
            this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);

        }

        private void brandsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.brandsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stokTakipVTYSDataSet);

        }


        private void userLogInButton_Click(object sender, EventArgs e)
        {
            String userName, userPassword;
            userName = userNameTextBox.Text;
            userPassword = userPasswordTextBox.Text;
            try
            {
                String query ="SELECT * FROM SystemUsers WHERE UserName='" +
                    userNameTextBox.Text + "' AND UserPassword='" + userPasswordTextBox.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query,connection);

                DataTable dTableUsers = new DataTable();
                adapter.Fill(dTableUsers);

                if (dTableUsers.Rows.Count > 0)
                {
                    userName = userNameTextBox.Text;
                    userPassword = userPasswordTextBox.Text;

                    //next page
                    MainPage formMainPage = new MainPage();
                    formMainPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı girişi tespit edildi.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    userNameTextBox.Clear();
                    userPasswordTextBox.Clear();
                    userNameTextBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Hata");
            }
            finally
            {
                connection.Close();
            }
        }


        private void LogInPageExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void clearButtonLogIn_Click(object sender, EventArgs e)
        {
            userNameTextBox.Clear();
            userPasswordTextBox.Clear();
            userNameTextBox.Focus();
        }

        
    }
}
