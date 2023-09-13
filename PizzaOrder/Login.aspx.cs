using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaOrder
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CompareUser(string username, string password)
        {
            if (username == ConfigurationManager.AppSettings["user"].ToString() && password == ConfigurationManager.AppSettings["password"].ToString())
            {
                FormsAuthentication.SetAuthCookie(UsernameBox.Text, true);
                Response.Redirect(FormsAuthentication.DefaultUrl);

            }
            else
            {


            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string Username = UsernameBox.Text;
            string Password = PasswordBox.Text;
            CompareUser(Username, Password);
        }
    }
}