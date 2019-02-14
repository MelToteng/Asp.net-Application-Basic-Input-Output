using PharmacyApplication.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyApplication.Pages
{
    public partial class Dispensary : System.Web.UI.Page
    {
        DrugsRepository drugsRepository;
        StockRepository stockRepository;
        TansactionRepository tansactionRepository;

        List<PriceViewModel> prices = new List<PriceViewModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            stockRepository = new StockRepository();
            drugsRepository = new DrugsRepository();
            tansactionRepository = new TansactionRepository();
            //if (!IsPostBack)

        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ProductList.SelectedIndex;

            string code = ProductList.SelectedValue;

            ProductList.Items.RemoveAt(index);

            int total = 0;

            int.TryParse(totalCost.Text, out total);

            var price = prices.Find(x => x.Code.ToLower() == code.ToLower());

            if (price != null)
                total = total - price.Price;

            totalCost.Text = total.ToString();

            totalItems.Text = ProductList.Items.Count.ToString();
        }

        protected void CancelPayClick(object sender, EventArgs e)
        {

        }

        protected void PayServerClick(object sender, EventArgs e)
        {
            try
            {
                string itemCode = code.Text;

                double _amount = 0.0;

                double.TryParse(amountPaid.Text, out _amount);

                string user = Session["username"].ToString();

                tansactionRepository.Add(new DAL.TRANSACTION()
                {
                    BR_ID = itemCode,
                    No_Item = totalItems.Text,
                    TotalPrice = totalCost.Text,
                    Selling_Price = (decimal)_amount,
                    Sale_Date = DateTime.Now,
                    UserID = Session["username"].ToString()
                });

                tansactionRepository.SaveChanges();

                var stockItem = stockRepository.Find(x => x.BR_ID == itemCode).FirstOrDefault();

                int curentStock = 0;
                int totalStock = 0;

                int.TryParse(stockItem.Quantity, out curentStock);

                int.TryParse(totalItems.Text, out totalStock);

                stockItem.Quantity = (curentStock - totalStock).ToString();

                stockRepository.SetState(stockItem);

                stockRepository.SaveChanges();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Transaction Successful');", true);

                ClearFields();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        private void ClearFields()
        {
            code.Text = "";
            totalCost.Text = "";
            amountPaid.Text = "";
            totalItems.Text = "";
            ProductList.Items.Clear();
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            var drug = drugsRepository.Find(x => x.BR_ID.ToLower() == code.Text.ToLower()).FirstOrDefault();

            if (drug != null)
            {
                if (ProductList.Items.Count == 0 || ProductList.Items.FindByValue(drug.BR_ID) != null)
                {
                    var drugStock = stockRepository.Find(x => x.BR_ID == drug.BR_ID).FirstOrDefault();

                    int stockQuntity = 0;
                    int.TryParse(drugStock.Quantity, out stockQuntity);

                    int totalRequested = 0;

                    int.TryParse(totalItems.Text, out totalRequested);

                    if (drugStock != null && (stockQuntity - totalRequested) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Out of Stock');", true);
                    }
                    else
                    {
                        if (drug.ExpireDate <= DateTime.Now)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Drug has Expired');", true);
                        }
                        else
                        {
                            if (UntPrc.Checked)
                            {
                                ProductList.Items.Add(new ListItem()
                                {
                                    Value = drug.BR_ID,
                                    Text = drug.BR_ID + " : " + drug.DRUG_NAME + " : " + drug.UNITARY_PRICE
                                });

                                prices.Add(new PriceViewModel() { Code = drug.BR_ID, Price = drug.UNITARY_PRICE });

                                int total = 0;

                                int.TryParse(totalCost.Text, out total);

                                total = total + drug.UNITARY_PRICE;

                                totalCost.Text = total.ToString();

                                totalItems.Text = ProductList.Items.Count.ToString();
                            }

                            if (BlkPrc.Checked)
                            {
                                ProductList.Items.Add(new ListItem()
                                {
                                    Value = drug.BR_ID,
                                    Text = drug.BR_ID + " : " + drug.DRUG_NAME + " : " + drug.BulkPrice
                                });

                                int bulkCost = 0;
                                int.TryParse(drug.BulkPrice, out bulkCost);

                                prices.Add(new PriceViewModel() { Code = drug.BR_ID, Price = bulkCost });

                                int total = 0;

                                int.TryParse(totalCost.Text, out total);

                                total = total + bulkCost;

                                totalCost.Text = total.ToString();

                                totalItems.Text = ProductList.Items.Count.ToString();

                            }

                            if (!BlkPrc.Checked && !UntPrc.Checked)
                            {
                                code.Text = "";

                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Price Type');", true);
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only one drug can be processed at a time');", true);
                }
            }

        }
    }

    public class PriceViewModel
    {
        public string Code { get; set; }

        public int Price { get; set; }
    }
}