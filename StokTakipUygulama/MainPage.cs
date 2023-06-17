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
    public partial class MainPage : Form
    {
        //MAIN PAGE GENERAL FUNCTIONS
        public MainPage()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ELHQJHB\SQLEXPRESS;Initial Catalog=StokTakipVTYS;
                                                     Integrated Security=True");

        private void updateComboBoxes()
        {
            //Stock Page Places ComboBox item adding
            this.placeNameComboBox.Items.Clear();
            String query1 = "SELECT PlaceName FROM Places";
            SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
            DataTable dtStockPagePlaceCombo = new DataTable();
            adapter1.Fill(dtStockPagePlaceCombo);
            for (int i = 0; i < dtStockPagePlaceCombo.Rows.Count; i++)
            {
                this.placeNameComboBox.Items.Add(dtStockPagePlaceCombo.Rows[i].Field<String>("PlaceName"));
            }

            //Product Add TabPage ComboBox item adding - Places
            this.productAddStockComboBox.Items.Clear();
            String query2 = "SELECT PlaceName FROM Places";
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
            DataTable dtProductAddPlacesCombo = new DataTable();
            adapter2.Fill(dtProductAddPlacesCombo);
            for (int i = 0; i < dtProductAddPlacesCombo.Rows.Count; i++)
            {
                this.productAddStockComboBox.Items.Add(dtProductAddPlacesCombo.Rows[i].Field<String>("PlaceName"));
            }

            //Product Add TabPage ComboBox item adding - Brands
            this.productAddBrandComboBox.Items.Clear();
            String query3 = "SELECT BrandName FROM Brands";
            SqlDataAdapter adapter3 = new SqlDataAdapter(query3, connection);
            DataTable dtProductAddBrandsCombo = new DataTable();
            adapter3.Fill(dtProductAddBrandsCombo);
            for (int i = 0; i < dtProductAddBrandsCombo.Rows.Count; i++)
            {
                this.productAddBrandComboBox.Items.Add(dtProductAddBrandsCombo.Rows[i].Field<String>("BrandName"));
            }

            //Product Update-Delete TabPage ComboBox item adding - Places
            this.productUpdateStockComboBox.Items.Clear();
            String query4 = "SELECT PlaceName FROM Places";
            SqlDataAdapter adapter4 = new SqlDataAdapter(query4, connection);
            DataTable dtProductUpdatePlacesCombo = new DataTable();
            adapter4.Fill(dtProductUpdatePlacesCombo);
            for (int i = 0; i < dtProductUpdatePlacesCombo.Rows.Count; i++)
            {
                this.productUpdateStockComboBox.Items.Add(dtProductUpdatePlacesCombo.Rows[i].Field<String>("PlaceName"));
            }

            //Product Update-Delete TabPage ComboBox item adding - Brands
            this.productUpdateBrandComboBox.Items.Clear();
            String query5 = "SELECT BrandName FROM Brands";
            SqlDataAdapter adapter5 = new SqlDataAdapter(query5, connection);
            DataTable dtProductUpdateBrandsCombo = new DataTable();
            adapter5.Fill(dtProductUpdateBrandsCombo);
            for (int i = 0; i < dtProductUpdateBrandsCombo.Rows.Count; i++)
            {
                this.productUpdateBrandComboBox.Items.Add(dtProductUpdateBrandsCombo.Rows[i].Field<String>("BrandName"));
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Stocks' table. You can move, or remove it, as needed.
            this.stocksTableAdapter.Fill(this.stokTakipVTYSDataSet.Stocks);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.StocksTab' table. You can move, or remove it, as needed.
            this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Brands' table. You can move, or remove it, as needed.
            this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.ProductsTab' table. You can move, or remove it, as needed.
            this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.stokTakipVTYSDataSet.Products);
            // TODO: This line of code loads data into the 'stokTakipVTYSDataSet.Places' table. You can move, or remove it, as needed.
            this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
            updateComboBoxes();
        }

        //PLACES PAGE BUTTON CLICKS
        private void ekleButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String placeName;
            int maxCapacity;
            try
            {
                if (placeNameTextBox.Text!="" && maxCapacityTextBox.Text != "")
                {
                    placeName = placeNameTextBox.Text;
                    maxCapacity = Int32.Parse(maxCapacityTextBox.Text);
                    String query = "INSERT INTO Places (PlaceName,MaxCapacity) VALUES('" + placeName + "'," + maxCapacity + ")";
                    SqlCommand command = new SqlCommand(query, connection);
                    
                    DialogResult result;
                    result = MessageBox.Show("Stok noktası: " + placeName + "\nMaksimum kapasite: " + maxCapacity + "\nEklemek istiyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ekleme işlemi başarılı bir şekilde gerçekleşti.","Başarılı",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
                        updateComboBoxes();
                    }                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                placeNameTextBox.Clear();
                maxCapacityTextBox.Clear();
                connection.Close();
            }
            

        }
        
        private void temizleButton_Click(object sender, EventArgs e)
        {
            placeNameTextBox.Clear();
            maxCapacityTextBox.Clear();
        }

        private void clearUpdatePlacesButton_Click(object sender, EventArgs e)
        {
            placeNameUpdateTextBox.Clear();
            maxCapacityUpdateTextBox.Clear();
            updatePlaceIDLabel.Text = "";
        }

        private void updatePlacesRowButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String updatePlaceName,updatePlaceID;
            int updateMaxCapacity;
            try
            {
                if (placeNameUpdateTextBox.Text != "" && maxCapacityUpdateTextBox.Text != "")
                {
                    updatePlaceID = updatePlaceIDLabel.Text;
                    updatePlaceName = placeNameUpdateTextBox.Text;
                    updateMaxCapacity = Int32.Parse(maxCapacityUpdateTextBox.Text);
                    String query = "UPDATE Places SET PlaceName='" + updatePlaceName + "',MaxCapacity="+ updateMaxCapacity + 
                        "WHERE PlaceID="+ updatePlaceID;
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Stok noktası: " + updatePlaceName + "\nMaksimum kapasite: " + updateMaxCapacity + "\nGüncellemek istiyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                        updateComboBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /*placeNameUpdateTextBox.Clear();
                maxCapacityUpdateTextBox.Clear();
                updatePlaceIDLabel.Text = "";*/
                connection.Close();
            }
        }

        private void deletePlacesRowButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String updatePlaceID;
            try
            {
                if (placeNameUpdateTextBox.Text != "" && maxCapacityUpdateTextBox.Text != "")
                {
                    updatePlaceID = updatePlaceIDLabel.Text;
                    String query = "DELETE from Places WHERE PlaceID=" + updatePlaceID;
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Stok noktası: " + placeNameUpdateTextBox.Text + "\nMaksimum kapasite: " + maxCapacityUpdateTextBox.Text + "\nİlgili veriyi silmek istiyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Silme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                        updateComboBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /*placeNameUpdateTextBox.Clear();
                maxCapacityUpdateTextBox.Clear();
                updatePlaceIDLabel.Text = "";*/
                connection.Close();
            }

        }

        //GENEL LOG OUT VE EXIT BUTTON CLICK
        private void logOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Oturumu kapatmak istediğinizden emin misiniz?",
                "Oturumu Kapatma", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                LoginPage loginPageLoad = new LoginPage();
                loginPageLoad.Show();
                this.Hide();
            }            
        }
        private void exitButton_Click(object sender, EventArgs e)
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

        //BRAND PAGE BUTTON CLICKS
        private void brandAddClearButton_Click(object sender, EventArgs e)
        {
            brandNameAddTextBox.Clear();
            brandPhoneAddTextBox.Clear();
            brandMailAddTextBox.Clear();
            brandAddressAddTextBox.Clear();
        }

        private void brandAddButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String brandName, brandPhone, brandMail, brandAddress;
            try
            {
                if (brandNameAddTextBox.Text != "" && brandPhoneAddTextBox.Text != "" &&
                    brandMailAddTextBox.Text != "" && brandAddressAddTextBox.Text != "")
                {
                    brandName = brandNameAddTextBox.Text;
                    brandPhone = brandPhoneAddTextBox.Text;
                    brandMail = brandMailAddTextBox.Text;
                    brandAddress = brandAddressAddTextBox.Text;
                    String query = "INSERT INTO Brands (BrandName, ContactAddress, ContactPhoneNum, ContactMailAddress) VALUES('"+
                    brandName + "','" + brandAddress + "','" + brandPhone + "','" + brandMail + "')";
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Marka adı:" + brandName + "\nTelefon no:" + brandPhone + "\nMail: " + brandMail +"\nAdres:" + brandAddress + "\nBilgileri bu şekilde eklemek istiyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ekleme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);
                        updateComboBoxes();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                brandNameAddTextBox.Clear();
                brandPhoneAddTextBox.Clear();
                brandMailAddTextBox.Clear();
                brandAddressAddTextBox.Clear();
                connection.Close();
            }
        }

        private void brandUpdateClearButton_Click(object sender, EventArgs e)
        {
            brandUpdateNameTextBox.Clear();
            brandUpdatePhoneTextBox.Clear();
            brandUpdateMailTextBox.Clear();
            brandUpdateAddressTextBox.Clear();
            brandUpdateIDLabel.Text = "";
        }

        private void brandUpdateButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String brandName, brandPhone, brandMail, brandAddress, brandID;
            try
            {
                if (brandUpdateNameTextBox.Text != "" && brandUpdatePhoneTextBox.Text != "" &&
                    brandUpdateMailTextBox.Text != "" && brandUpdateAddressTextBox.Text != "")
                {
                    brandID = brandUpdateIDLabel.Text;
                    brandName = brandUpdateNameTextBox.Text;
                    brandPhone = brandUpdatePhoneTextBox.Text;
                    brandMail = brandUpdateMailTextBox.Text;
                    brandAddress = brandUpdateAddressTextBox.Text;
                    String query = "UPDATE Brands SET BrandName='" + brandName + "',ContactAddress='" + brandAddress +
                        "',ContactPhoneNum='" + brandPhone + "',ContactMailAddress='" + brandMail +
                        "' WHERE BrandID=" + brandID;
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Marka adı: " + brandName + "\nTelefon no: " + brandPhone + "\nMail: " + brandMail +"\nAdres: " + brandAddress + "\nBilgileri bu şekilde eklemek istiyor musunuz ? ",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        updateComboBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /*brandUpdateNameTextBox.Clear();
                brandUpdatePhoneTextBox.Clear();
                brandUpdateMailTextBox.Clear();
                brandUpdateAddressTextBox.Clear();
                brandUpdateIDLabel.Text = "";*/
                connection.Close();
            }
        }

        private void brandDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String brandID, brandName, brandMail, brandAddress, brandPhone;
            try
            {
                if (brandUpdateNameTextBox.Text != "" && brandUpdatePhoneTextBox.Text != "" &&
                    brandUpdateMailTextBox.Text != "" && brandUpdateAddressTextBox.Text != "")
                {
                    brandID = brandUpdateIDLabel.Text;
                    brandName = brandUpdateNameTextBox.Text;
                    brandPhone = brandUpdatePhoneTextBox.Text;
                    brandMail = brandUpdateMailTextBox.Text;
                    brandAddress = brandUpdateAddressTextBox.Text;
                    String query = "DELETE from Brands WHERE BrandID=" + brandID;
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Marka adı: " + brandName + "\nTelefon no: " + brandPhone + "\nMail: " + brandMail + "\nAdres: " + brandAddress + "\n İlgili bilgilere ait kayıt tablodan silinsin mi? ",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Silme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        updateComboBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                /*brandUpdateNameTextBox.Clear();
                brandUpdatePhoneTextBox.Clear();
                brandUpdateMailTextBox.Clear();
                brandUpdateAddressTextBox.Clear();
                brandUpdateIDLabel.Text = "";*/
                connection.Close();
            }
        }

        //STOCK PAGE BUTTON CLICKS
        private void minStockUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            int minStock;
            String stockID;
            try
            {
                if (minStockUpdateIDLabel.Text != "")
                {
                    minStock = Int16.Parse(minStockUpdateTextBox.Text);
                    stockID = minStockUpdateIDLabel.Text;
                    String query = "UPDATE Stocks SET MinQuantity=" + minStock + " WHERE StockID=" + stockID;
                    SqlCommand command = new SqlCommand(query, connection);

                    DialogResult result;
                    result = MessageBox.Show("Yeni minimum stok değeri: "+ minStock + "\nDeğişikliği onaylıyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Değişiklik başarı ile gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void stockPlaceUpdateButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            int stockPlaceID, stockID;
            String stockPlaceName;
            try
            {
                if (minStockUpdateIDLabel.Text != "")
                {
                    stockID = Int16.Parse(placeUpdateStockIDLabel.Text);
                    stockPlaceName = placeNameComboBox.Text;

                    String query1 = "SELECT PlaceID FROM Places WHERE PlaceName= '" + stockPlaceName + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query1, connection);
                    DataTable dtStockID = new DataTable();
                    adapter.Fill(dtStockID);
                    stockPlaceID = dtStockID.Rows[0].Field<int>("PlaceID");

                    String query2 = "UPDATE Stocks SET StockPlaceID=" + stockPlaceID + " WHERE StockID=" + stockID;
                    SqlCommand command2 = new SqlCommand(query2, connection);

                    DialogResult result;
                    result = MessageBox.Show("Yeni stok konumu: " + stockPlaceName + "\nDeğişikliği onaylıyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Değişiklik başarı ile gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        //PRODUCT PAGE BUTTON CLICKS

        private void productAddClearButton_Click(object sender, EventArgs e)
        {
            productAddBrandComboBox.Text = "";
            productAddStockComboBox.Text = "";
            productAddNameTextBox.Clear();
            productAddCategoryTextBox.Clear();
            productAddUnitTextBox.Clear();
            productAddPurchaseTextBox.Clear();
            productAddSaleTextBox.Clear();
            productAddStockTextBox.Clear();
            productAddDescriptionTextBox.Clear();
        }

        private void productAddButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String productName, productCategory, productUnit, productDescription, productPlace, productBrand;
            int placeID, brandID, stockID, productStock;
            float productPurchase, productSale;
            try
            {
                if (productAddNameTextBox.Text != "" && productAddCategoryTextBox.Text != "" &&
                    productAddUnitTextBox.Text != "" && productAddPurchaseTextBox.Text != "" &&
                    productAddSaleTextBox.Text != "" && productAddStockTextBox.Text != "" &&
                    productAddDescriptionTextBox.Text != "" && productAddBrandComboBox.Text != "" &&
                    productAddStockComboBox.Text != "")
                {
                    productName = productAddNameTextBox.Text;
                    productCategory = productAddCategoryTextBox.Text;
                    productUnit = productAddUnitTextBox.Text;
                    productDescription = productAddDescriptionTextBox.Text;
                    productPlace = productAddStockComboBox.Text;
                    productBrand = productAddBrandComboBox.Text;
                    productPurchase =  float.Parse(productAddPurchaseTextBox.Text);
                    productSale = float.Parse(productAddSaleTextBox.Text);
                    productStock = Int32.Parse(productAddStockTextBox.Text);

                    //Selecting placeID from placeName
                    String query1 = "SELECT PlaceID FROM Places WHERE PlaceName= '" + productPlace + "'";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
                    DataTable dtStockID = new DataTable();
                    adapter1.Fill(dtStockID);
                    placeID = dtStockID.Rows[0].Field<int>("PlaceID");

                    //Selecting brandID from brandName
                    String query2 = "SELECT BrandID FROM Brands WHERE BrandName= '" + productBrand + "'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                    DataTable dtBrandID = new DataTable();
                    adapter2.Fill(dtBrandID);
                    brandID = dtBrandID.Rows[0].Field<int>("BrandID");

                    //Opening new stock for new product
                    String addStockQuery = "INSERT INTO Stocks (StockQuantity, MinQuantity, StockPlaceID)" +
                        "VALUES(" + productStock + "," + 0 + "," + placeID + ")";
                    SqlCommand addStockCommand = new SqlCommand(addStockQuery, connection);
                    DialogResult result1;
                    result1 = MessageBox.Show("Ürün adı: " + productName + "\nÜrün kategorisi: " + productCategory +
                            "\nÜrün markası: " + productBrand + "\nAlış fiyatı: " + productPurchase +
                            "\nSatış fiyatı: " + productSale + "\nStok miktarı: " + productStock + "\nKonum: " + productPlace +
                            "\nLütfen bilgileri teyit ediniz bu şekilde eklemek istiyor musunuz?",
                            "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result1 == DialogResult.Yes)
                    {
                        addStockCommand.ExecuteNonQuery();
                        MessageBox.Show("Stok oluşturuldu, ürün bilgileri ekleniyor...", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);

                        //Selecting stockID after opening new stock for new product
                        String selectStockQuery = "SELECT StockID FROM Stocks";
                        SqlDataAdapter selectStockAdapter = new SqlDataAdapter(selectStockQuery, connection);
                        DataTable dtSelectStockID = new DataTable();
                        selectStockAdapter.Fill(dtSelectStockID);
                        int stockIndex = dtSelectStockID.Rows.Count - 1;
                        stockID = dtSelectStockID.Rows[stockIndex].Field<int>("StockID");

                        //Product add section
                        String addProductQuery = "INSERT INTO Products (ProductName, BrandID, StockID, ProductCategory," +
                            "PurchasePrice, SalePrice, MeasurementUnit, ProductDescription) " +
                            "VALUES('" + productName + "'," + brandID + "," + stockID + ",'" + productCategory + "'," +
                            productPurchase + "," + productSale + ",'" + productUnit + "','" + productDescription + "')";
                        SqlCommand addProductCommand = new SqlCommand(addProductQuery, connection);
                        addProductCommand.ExecuteNonQuery();
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                    }                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                productAddBrandComboBox.Text = "";
                productAddStockComboBox.Text = "";
                productAddNameTextBox.Clear();
                productAddCategoryTextBox.Clear();
                productAddUnitTextBox.Clear();
                productAddPurchaseTextBox.Clear();
                productAddSaleTextBox.Clear();
                productAddStockTextBox.Clear();
                productAddDescriptionTextBox.Clear();
                connection.Close();
            }
        }

        private void productDeleteButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String productName;
            int productBarcode,stockID;
            try
            {
                if (productNameTextBox.Text != "" )
                {
                    productName = productNameTextBox.Text;
                    productBarcode = Int16.Parse(barcodeNumLabel3.Text);
                    stockID = Int16.Parse(stockIDLabel2.Text);
                    String delStockQuery = "DELETE from Stocks WHERE StockID=" + stockID;
                    SqlCommand delStockCommand = new SqlCommand(delStockQuery, connection);
                    String delProductQuery = "DELETE from Products WHERE BarcodeNum=" + productBarcode;
                    SqlCommand delProductCommand = new SqlCommand(delProductQuery, connection);

                    DialogResult result;
                    result = MessageBox.Show(productBarcode + " barkod numaralı, " + productName + " isimli ürünü stoklardan kaldırmak istiyor musunuz?",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (result == DialogResult.Yes)
                    {
                        delProductCommand.ExecuteNonQuery();
                        delStockCommand.ExecuteNonQuery();
                        MessageBox.Show("Silme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void productUpdateButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            String productName, productBrand, productCategory, productUnit,
                productPlace, productDescription;
            int stockID,barcodeNum,productStock,placeID,brandID;
            float salePrice, purchasePrice;
            try
            {
                if (productNameTextBox.Text != "" && productCategoryTextBox.Text != "" &&
                    purchasePriceTextBox.Text != "" && salePriceTextBox.Text != "" &&
                    productUpdateBrandComboBox.Text != "" && productUpdateStockComboBox.Text != ""
                    && stockQuantityTextBox.Text != "" && measurementUnitTextBox.Text != ""
                    && productDescriptionTextBox.Text != "")
                {
                    productName = productNameTextBox.Text;
                    productCategory = productCategoryTextBox.Text;
                    productUnit = measurementUnitTextBox.Text;
                    productDescription = productDescriptionTextBox.Text;
                    salePrice = float.Parse(salePriceTextBox.Text);
                    purchasePrice = float.Parse(purchasePriceTextBox.Text);
                    barcodeNum = Int16.Parse(barcodeNumLabel3.Text);
                    stockID = Int16.Parse(stockIDLabel2.Text);
                    productStock = Int32.Parse(stockQuantityTextBox.Text);

                    productPlace = productUpdateStockComboBox.Text;
                    productBrand = productUpdateBrandComboBox.Text;

                    //Selecting placeID from placeName
                    String query1 = "SELECT PlaceID FROM Places WHERE PlaceName= '" + productPlace + "'";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
                    DataTable dtStockID = new DataTable();
                    adapter1.Fill(dtStockID);
                    placeID = dtStockID.Rows[0].Field<int>("PlaceID");

                    //Selecting brandID from brandName
                    String query2 = "SELECT BrandID FROM Brands WHERE BrandName= '" + productBrand + "'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                    DataTable dtBrandID = new DataTable();
                    adapter2.Fill(dtBrandID);
                    brandID = dtBrandID.Rows[0].Field<int>("BrandID");

                    //updating stock table
                    String updateStockQuery = "UPDATE Stocks SET StockQuantity=" + productStock + ",StockPlaceID=" + placeID +
                        " WHERE StockID=" + stockID;
                    SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);

                    //updating product table
                    String updateProductQuery = "UPDATE Products SET ProductName='" + productName + "',BrandID=" + brandID +
                        ",StockID=" + stockID + ",ProductCategory='" + productCategory + "',PurchasePrice=" + purchasePrice +
                        ",SalePrice=" + salePrice + ",MeasurementUnit='" + productUnit + "',ProductDescription='" + productDescription +
                        "' WHERE BarcodeNum=" + barcodeNum;
                    SqlCommand updateProductCommand = new SqlCommand(updateProductQuery, connection);

                    DialogResult result;
                    result = MessageBox.Show("Ürün Adı: " + productName + "\nÜrünün Markası: " + productBrand +
                        "\nÜrünün Kategorisi: " + productCategory + "\nAlış Fiyatı: " + purchasePrice + "\nSatış Fiyatı: " + salePrice
                        + "\nBirim: " + productUnit + "\nStok Miktarı: " + productStock + "\nStok Konumu: " + productPlace
                        + "\nÜrün Açıklaması: " + productDescription
                        + "\nBilgileri bu şekilde güncellemek istiyor musunuz? ",
                        "Kontrol", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        updateStockCommand.ExecuteNonQuery();
                        updateProductCommand.ExecuteNonQuery();
                        MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
                        this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
                        updateComboBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        //TAB guncelleme islemleri
        // this.productsTabTableAdapter.Fill(this.stokTakipVTYSDataSet.ProductsTab);
        // this.stocksTabTableAdapter.Fill(this.stokTakipVTYSDataSet.StocksTab);
        // this.brandsTableAdapter.Fill(this.stokTakipVTYSDataSet.Brands);
        // this.placesTableAdapter.Fill(this.stokTakipVTYSDataSet.Places);
    }
}
