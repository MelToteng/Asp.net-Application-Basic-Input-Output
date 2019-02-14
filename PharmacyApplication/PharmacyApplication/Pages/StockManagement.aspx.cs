using PharmacyApplication.Business;
using PharmacyApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyApplication.Pages
{
    public partial class StockManagement : System.Web.UI.Page
    {
        DrugsRepository drugsRepository;
        StockRepository stockRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            drugsRepository = new DrugsRepository();
            stockRepository = new StockRepository();

            if (!IsPostBack)
                GetAllProducts();
        }

        public void GetAllProducts()
        {
            var list = new List<string>();

            foreach (var item in drugsRepository.GetAllList())
            {
                ProductList.Items.Add(new ListItem() { Value = item.BR_ID, Text = item.BR_ID + " : " + item.DRUG_NAME });
            }

            ProductList.DataSource = list;
        }

        public void ClearTextBoxes()
        {
            qty.Text = "";
            supplier.Text = "";
            notes.Text = "";
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ProductList.SelectedItem.Value;

            var drug = stockRepository.Find(x => x.BR_ID == item).FirstOrDefault();

            if (drug != null)
            {
                qty.Text = drug.Quantity;
                supplier.Text = drug.Supplier;
                notes.Text = drug.SupplierNotes;
            }
            else { ClearTextBoxes(); }
        }
        protected void add_stock(object sender, EventArgs e)
        {
            try
            {
                string user = Session["username"].ToString();

                var itemCode = ProductList.SelectedItem.Value;

                if (!string.IsNullOrEmpty(user))
                {
                    var stockItem = stockRepository.Find(x => x.BR_ID == itemCode).FirstOrDefault();

                    if (stockItem == null)
                    {
                        stockRepository.Add(new STOCK()
                        {
                            BR_ID = itemCode,
                            Quantity = qtyUpdate.Text,
                            Supplier = supplier.Text,
                            SupplierNotes = notes.Text,
                            UserID = user
                        });
                    }
                    else
                    {
                        int stockCount = 0;
                        int.TryParse(stockItem.Quantity, out stockCount);

                        int newQty = 0;
                        int.TryParse(qtyUpdate.Text, out newQty);

                        stockItem.Quantity = (newQty + stockCount).ToString();
                        stockItem.Supplier = supplier.Text;
                        stockItem.SupplierNotes = notes.Text;
                        stockItem.UserID = user;

                        stockRepository.SetState(stockItem);
                    }

                    stockRepository.SaveChanges();

                    ProductList.Items.Clear();

                    GetAllProducts();

                    ProductList.SelectedValue = itemCode;
                    qty.Text = stockItem.Quantity;

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Stock Added');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error:" + ex.Message + "');", true);
                throw;
            }
        }

        protected void remove_stock(object sender, EventArgs e)
        {
            try
            {
                string user = Session["username"].ToString();

                var itemCode = ProductList.SelectedItem.Value;

                int _qty = 0;
                int.TryParse(qty.Text, out _qty);

                if (!string.IsNullOrEmpty(user))
                {
                    var stockItem = stockRepository.Find(x => x.BR_ID == itemCode).FirstOrDefault();

                    int stockUpdate = 0;
                    int.TryParse(qtyUpdate.Text, out stockUpdate);

                    int currentStock = 0;
                    int.TryParse(qty.Text, out currentStock);

                    if (currentStock < stockUpdate)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Can not remove items more than in stock');", true);
                    }
                    else
                    {
                        stockItem.Quantity = (currentStock - stockUpdate).ToString();
                        stockItem.Supplier = supplier.Text;
                        stockItem.SupplierNotes = notes.Text;
                        stockItem.UserID = user;

                        stockRepository.SetState(stockItem);

                        stockRepository.SaveChanges();

                        qty.Text = stockItem.Quantity;

                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Stock Reduced');", true);
                    }
                }

                ProductList.Items.Clear();

                GetAllProducts();

                ProductList.SelectedValue = itemCode;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}