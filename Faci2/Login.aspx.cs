using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Faci2
{
    public partial class Login : System.Web.UI.Page
    {
        private void SuccessRedirect(string aUsername = null)
        {
            if (aUsername == null) aUsername = User.Identity.Name;
            FormsAuthentication.RedirectFromLoginPage(aUsername, true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                SuccessRedirect();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtUsername.Text, txtPassword.Text))
            {
                SuccessRedirect(txtUsername.Text);
            }
            else
            {
                Response.Write("Invalid username");
            }
        }
    }
}