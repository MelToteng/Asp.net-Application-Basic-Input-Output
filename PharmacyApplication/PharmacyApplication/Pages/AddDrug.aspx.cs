using PharmacyApplication.Business;
using PharmacyApplication.DAL;
using System;
using System.Globalization;
using System.Web.UI;

namespace PharmacyApplication.Pages
{
    public partial class AddDrug : System.Web.UI.Page
    {
        DrugsRepository drugsRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            drugsRepository = new DrugsRepository();

            if (!IsPostBack)
            {                
                string value = Session["drugId"] as string;

                if (!string.IsNullOrEmpty(value))
                {
                    code.Enabled = false;
                    code.Text = value;

                    title.Text = "Edit Drug Information";

                    cancelButton.Visible = false;

                    var drug = drugsRepository.Get(code.Text);

                    if (drug != null)
                    {
                        code.Text = drug.BR_ID;
                        name.Text = drug.DRUG_NAME;
                        unitPrice.Text = drug.UNITARY_PRICE.ToString();
                        bulkPrice.Text = drug.BulkPrice;
                        expDate.Text = Convert.ToDateTime(drug.ExpireDate).ToString("dd-M-yyyy",CultureInfo.InvariantCulture);
                    }
                }
                else { backButton.Visible = false; }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                var untPrice = 0;

                if (!code.Enabled)
                {
                    var newDrug = drugsRepository.Get(code.Text);

                    string text = string.Empty;

                    text = unitPrice.Text;

                    int.TryParse(unitPrice.Text, out untPrice);

                    newDrug.DRUG_NAME = name.Text;
                    newDrug.UNITARY_PRICE = untPrice;
                    newDrug.BulkPrice = bulkPrice.Text;
                    newDrug.ExpireDate = Convert.ToDateTime(expDate.Text);

                    drugsRepository.SetState(newDrug);

                    drugsRepository.SaveChanges();

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated Successfully');", true);

                    //Response.Redirect("DrugManager.aspx");
                }
                else
                {
                    int.TryParse(unitPrice.Text, out untPrice);

                    drugsRepository.Add(new DRUG()
                    {
                        BR_ID = code.Text,
                        DRUG_NAME = name.Text,
                        UNITARY_PRICE = untPrice,
                        BulkPrice = bulkPrice.Text,
                        ExpireDate = Convert.ToDateTime(expDate.Text)
                    });

                    drugsRepository.SaveChanges();

                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Saved Successfully');", true);
                    clearFields();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void back_click(object sender, EventArgs e)
        {
            Response.Redirect("DrugManager.aspx");
        }
        protected void cancel_click(object sender, EventArgs e)
        {
            Response.Redirect("DrugManager.aspx");
        }

        private void clearFields()
        {
            code.Text = "";
            name.Text = "";
            unitPrice.Text = "";
            bulkPrice.Text = "";
            expDate.Text = "";
        }
    }
}