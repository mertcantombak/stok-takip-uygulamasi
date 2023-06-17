
namespace StokTakipUygulama
{
    partial class LoginPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label userPasswordLabel;
            this.stokTakipVTYSDataSet = new StokTakipUygulama.StokTakipVTYSDataSet();
            this.brandsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brandsTableAdapter = new StokTakipUygulama.StokTakipVTYSDataSetTableAdapters.BrandsTableAdapter();
            this.tableAdapterManager = new StokTakipUygulama.StokTakipVTYSDataSetTableAdapters.TableAdapterManager();
            this.placesTableAdapter = new StokTakipUygulama.StokTakipVTYSDataSetTableAdapters.PlacesTableAdapter();
            this.systemUsersTableAdapter = new StokTakipUygulama.StokTakipVTYSDataSetTableAdapters.SystemUsersTableAdapter();
            this.systemUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userLogInButton = new System.Windows.Forms.Button();
            this.placesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LogInPageExitButton = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userPasswordTextBox = new System.Windows.Forms.TextBox();
            this.clearButtonLogIn = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            userPasswordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stokTakipVTYSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(76, 142);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(88, 17);
            userNameLabel.TabIndex = 3;
            userNameLabel.Text = "Kullanıcı Adı:";
            // 
            // userPasswordLabel
            // 
            userPasswordLabel.AutoSize = true;
            userPasswordLabel.Location = new System.Drawing.Point(76, 185);
            userPasswordLabel.Name = "userPasswordLabel";
            userPasswordLabel.Size = new System.Drawing.Size(107, 17);
            userPasswordLabel.TabIndex = 5;
            userPasswordLabel.Text = "Kullanıcı Şifresi:";
            // 
            // stokTakipVTYSDataSet
            // 
            this.stokTakipVTYSDataSet.DataSetName = "StokTakipVTYSDataSet";
            this.stokTakipVTYSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // brandsBindingSource
            // 
            this.brandsBindingSource.DataMember = "Brands";
            this.brandsBindingSource.DataSource = this.stokTakipVTYSDataSet;
            // 
            // brandsTableAdapter
            // 
            this.brandsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BrandsTableAdapter = this.brandsTableAdapter;
            this.tableAdapterManager.PlacesTableAdapter = this.placesTableAdapter;
            this.tableAdapterManager.ProductsTableAdapter = null;
            this.tableAdapterManager.StocksTableAdapter = null;
            this.tableAdapterManager.SystemUsersTableAdapter = this.systemUsersTableAdapter;
            this.tableAdapterManager.UpdateOrder = StokTakipUygulama.StokTakipVTYSDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // placesTableAdapter
            // 
            this.placesTableAdapter.ClearBeforeFill = true;
            // 
            // systemUsersTableAdapter
            // 
            this.systemUsersTableAdapter.ClearBeforeFill = true;
            // 
            // systemUsersBindingSource
            // 
            this.systemUsersBindingSource.DataMember = "SystemUsers";
            this.systemUsersBindingSource.DataSource = this.stokTakipVTYSDataSet;
            // 
            // userLogInButton
            // 
            this.userLogInButton.BackColor = System.Drawing.SystemColors.Control;
            this.userLogInButton.Location = new System.Drawing.Point(170, 231);
            this.userLogInButton.Name = "userLogInButton";
            this.userLogInButton.Size = new System.Drawing.Size(119, 35);
            this.userLogInButton.TabIndex = 7;
            this.userLogInButton.Text = "Oturum Aç";
            this.userLogInButton.UseVisualStyleBackColor = false;
            this.userLogInButton.Click += new System.EventHandler(this.userLogInButton_Click);
            // 
            // placesBindingSource
            // 
            this.placesBindingSource.DataMember = "Places";
            this.placesBindingSource.DataSource = this.stokTakipVTYSDataSet;
            // 
            // LogInPageExitButton
            // 
            this.LogInPageExitButton.BackColor = System.Drawing.SystemColors.Control;
            this.LogInPageExitButton.Location = new System.Drawing.Point(295, 306);
            this.LogInPageExitButton.Name = "LogInPageExitButton";
            this.LogInPageExitButton.Size = new System.Drawing.Size(75, 35);
            this.LogInPageExitButton.TabIndex = 8;
            this.LogInPageExitButton.Text = "Çıkış";
            this.LogInPageExitButton.UseVisualStyleBackColor = false;
            this.LogInPageExitButton.Click += new System.EventHandler(this.LogInPageExitButton_Click);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(189, 139);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.userNameTextBox.TabIndex = 9;
            // 
            // userPasswordTextBox
            // 
            this.userPasswordTextBox.Location = new System.Drawing.Point(189, 182);
            this.userPasswordTextBox.Name = "userPasswordTextBox";
            this.userPasswordTextBox.PasswordChar = '*';
            this.userPasswordTextBox.Size = new System.Drawing.Size(100, 22);
            this.userPasswordTextBox.TabIndex = 10;
            // 
            // clearButtonLogIn
            // 
            this.clearButtonLogIn.BackColor = System.Drawing.SystemColors.Control;
            this.clearButtonLogIn.Location = new System.Drawing.Point(79, 231);
            this.clearButtonLogIn.Name = "clearButtonLogIn";
            this.clearButtonLogIn.Size = new System.Drawing.Size(85, 35);
            this.clearButtonLogIn.TabIndex = 11;
            this.clearButtonLogIn.Text = "Temizle";
            this.clearButtonLogIn.UseVisualStyleBackColor = false;
            this.clearButtonLogIn.Click += new System.EventHandler(this.clearButtonLogIn_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginLabel.Location = new System.Drawing.Point(87, 29);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(212, 35);
            this.loginLabel.TabIndex = 12;
            this.loginLabel.Text = "Stok Takip Sistemi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(113, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 35);
            this.label1.TabIndex = 13;
            this.label1.Text = "Giriş Ekranı";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.clearButtonLogIn);
            this.Controls.Add(this.userPasswordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.LogInPageExitButton);
            this.Controls.Add(this.userLogInButton);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(userPasswordLabel);
            this.Name = "LoginPage";
            this.Text = "Sistem Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stokTakipVTYSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemUsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StokTakipVTYSDataSet stokTakipVTYSDataSet;
        private System.Windows.Forms.BindingSource brandsBindingSource;
        private StokTakipVTYSDataSetTableAdapters.BrandsTableAdapter brandsTableAdapter;
        private StokTakipVTYSDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private StokTakipVTYSDataSetTableAdapters.SystemUsersTableAdapter systemUsersTableAdapter;
        private System.Windows.Forms.BindingSource systemUsersBindingSource;
        private System.Windows.Forms.Button userLogInButton;
        private StokTakipVTYSDataSetTableAdapters.PlacesTableAdapter placesTableAdapter;
        private System.Windows.Forms.BindingSource placesBindingSource;
        private System.Windows.Forms.Button LogInPageExitButton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox userPasswordTextBox;
        private System.Windows.Forms.Button clearButtonLogIn;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
    }
}

