using System;
using System.Web.UI;


namespace PharmacyApplication
{
    public partial class SiteMaster : MasterPage
    {
        public string LoggedInUser { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoggedInUser = Session["username"].ToString();

                    if (!string.IsNullOrEmpty(LoggedInUser))
                    {
                        loggedInUser.Text = LoggedInUser;
                    }
                    else
                    {
                        Response.Redirect("~/Pages/Login.aspx");
                    }

                }
            }
            catch (Exception ex)
            {
                //throw ex;
                Response.Redirect("~/Pages/Login.aspx");
            }
        }

        protected void Unnamed_LoggingOut(object sender, EventArgs e)
        {
            LoggedInUser = string.Empty;
            Session["username"] = string.Empty;
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}