using PharmacyApplication.Business;
using PharmacyApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyApplication.Pages
{
    public partial class DrugManager : System.Web.UI.Page
    {
        DrugsRepository drugsRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            drugsRepository = new DrugsRepository();

            Session["drugId"] = string.Empty;

            GetAllProducts();
        }

        /// <summary>
        /// Get all products from the database and pass the to the listbox
        /// </summary>
        public void GetAllProducts()
        {
            var list = new List<string>();

            foreach (var item in drugsRepository.GetAllList())
            {
                ProductList.Items.Add(new ListItem() { Value=item.BR_ID, Text = item.BR_ID + " : " + item.DRUG_NAME });
            }

            ProductList.DataSource = list;
        }

        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDrug.aspx");
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string value = ProductList.Items[ProductList.SelectedIndex].Value;

            Session["drugId"] = value;

            Response.Redirect("AddDrug.aspx");
        }

        protected void delete_Click(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {

        }

        protected void cancel_click(object sender, EventArgs e)
        {

        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}