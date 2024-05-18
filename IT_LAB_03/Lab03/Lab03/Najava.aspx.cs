using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab03
{
    public partial class Najava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClick(object sender, EventArgs e)
        {
            var name = _name.Text;
            var password = _password.Text;
            var emailAddress = _adress.Text;

            if(name.Length == 0)
            {
                labelName.Text = "Внесете име";
                labelName.ForeColor = Color.Red;
            }
            else
            {
                labelName.Text = "";
            }
            if(password.Length == 0)
            {
                labelPassword.Text = "Внесете лозинка";
                labelPassword.ForeColor = Color.Red;
            }
            else
            {
                labelPassword.Text = "";
            }
            if(emailAddress.Length == 0)
            {
                labelAddress.Text = "Невалиден формат";
                labelAddress.ForeColor = Color.Red;
            }
            else
            {
                labelAddress.Text = "";
            }

            if(name != null && password != null && emailAddress.Contains("@") && emailAddress.Contains(".com"))
            {
                Session["Email"] = emailAddress;
                Response.Redirect("Glasaj.aspx");
            }
        }
    }
}