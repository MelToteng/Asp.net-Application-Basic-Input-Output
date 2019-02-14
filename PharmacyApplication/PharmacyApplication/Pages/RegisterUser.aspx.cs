using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PharmacyApplication.Business;
using System;
using System.Linq;

namespace PharmacyApplication.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserRepository userRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            userRepository = new UserRepository();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = UserName.Text };
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                    userRepository.Add(new DAL.USER() { FirstName = firstname.Text, LastName = lastname.Text, User_Name = UserName.Text, CellNumber = cell.Text, UserId=user.Id, PASSWORD=user.PasswordHash });

                    userRepository.SaveChanges();

                    StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                }
                else
                {
                    StatusMessage.Text = result.Errors.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void back_click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("UserManager.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}