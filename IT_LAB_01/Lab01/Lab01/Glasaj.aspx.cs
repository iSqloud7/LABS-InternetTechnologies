using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01
{
    public partial class Glasaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProfessors.Text = lbSubjects.SelectedItem.Value.ToString();

            foreach (ListItem item in  lbCredits.Items)
            {
                item.Selected = false;
            }

            lbCredits.Items[lbSubjects.SelectedIndex].Selected = true;

            // lblProfessors.Text = lbSubjects.SelectedItem.Value.ToString() + lbSubjects.SelectedIndex;
            // lbCredits.Items[creditIndex].Selected = true;

            /*
            var creditIndex = lbSubjects.SelectedIndex;

            if(creditIndex == 0)
            {
                lbCredits.Items[0].Selected = true;
            }
            else
            {
                lbCredits.Items[0].Selected = false;
            }
            if (creditIndex == 1)
            {
                lbCredits.Items[1].Selected = true;
            }
            else
            {
                lbCredits.Items[1].Selected = false;
            }
            */
        }

        protected void VoteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UspeshnoGlasanje.aspx");
        }
    }
}