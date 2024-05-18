using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01
{
    public partial class Najava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClick(object sender, EventArgs e)
        {
            var name = Name.Text;
            var password = Password.Text;
            var e_adress = EmailAddress.Text;

            if (name.Length == 0)
            {
                labelName.Text = "Внесете име";
                labelName.ForeColor = Color.Red;
            }
            else
            {
                labelName.Text = "";
            }

            if (password.Length == 0)
            {
                labelPassword.Text = "Внесете лозинка";
                labelPassword.ForeColor = Color.Red;
            }
            else
            {
                labelPassword.Text = "";
            }

            if (e_adress.Length == 0)
            {
                labelAddress.Text = "Невалиден формат";
                labelAddress.ForeColor = Color.Red;
            }
            else
            {
                labelAddress.Text = "";
            }

            if (name.Length > 0 && password.Length > 0 && e_adress.Contains("@") && e_adress.Contains("."))
            {
                Session["Email"] = e_adress;
                Response.Redirect("Glasaj.aspx");
            }

        }
    }
}