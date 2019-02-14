using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PharmacyApplication.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyApplication.Pages
{
    public partial class UserManagement : System.Web.UI.Page
    {
        UserRepository userRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            userRepository = new UserRepository();

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            try
            {
                var users = userRepository.GetAllList();

                foreach (var item in users)
                {
                    UsersList.Items.Add(new ListItem() { Value=item.UserId, Text = item.User_Name + " | " + item.FirstName + " " + item.LastName });
                }
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUser.aspx");
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            string value = UsersList.Items[UsersList.SelectedIndex].Value;

            var user = manager.FindById(value);

            var result=manager.Delete(user);

            if (result.Succeeded)
            {
                var userDetails = userRepository.Find(x => x.UserId == user.Id).FirstOrDefault();

                userRepository.Remove(userDetails);

                userRepository.SaveChanges();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted Successfully');", true);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);

            }
        }
    }
}