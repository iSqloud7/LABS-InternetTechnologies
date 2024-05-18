using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab02
{
    public partial class Glasaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] subjects = new string[]
                {
                    "Интернет технологии",
                    "Софтверско инженерство",
                    "Оперативни системи",
                    "Концепти на информатичко општество",
                    "Дигитално процерирање на слика"
                };
                foreach (string subject in subjects)
                {
                    lblSubjects.Items.Add(subject);
                }

                string[] credits = new string[]
                {
                    "6",
                    "6",
                    "6",
                    "5.5",
                    "5"
                };
                foreach (string credit in credits)
                {
                    lblCredits.Items.Add(credit);
                }
            }
        }

        string[] professors = new string[]
        {
            "Проф. д-р Гоце Арменски",
            "Проф. д-р Дејан Ѓорѓевиќ",
            "Проф. д-р Весна Димитрова",
            "Проф. д-р Горан Велинов",
            "Проф. д-р Ивица Димитровски"
        };

        protected void AddOnClick(object sender, EventArgs e)
        {
            var subjects = _subjects.Text;
            var credits = _credits.Text;

            if(subjects.Length == 0)
            {
                return;
            }
            else
            {
                _subjects.Text = "";
            }

            if(credits.Length == 0)
            {
                return;
            }
            else
            {
                _subjects.Text = "";
            }

            if(subjects != null && credits != null)
            {
                _subjects.Text = _credits.Text = "";

                lblSubjects.Items.Add(subjects);
                lblCredits.Items.Add(credits);
            }
        }

        protected void DeleteOnClick(object sender, EventArgs e)
        {
            lblSubjects.Items.Remove(lblSubjects.SelectedItem);
            lblCredits.Items.Remove(lblCredits.SelectedItem);
        }

        protected void lblSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblSubjects.SelectedIndex != -1 && lblSubjects.SelectedIndex < lblCredits.Items.Count)
            {
                if (lblSubjects.SelectedIndex >= professors.Length)
                {
                    lblProfessor.Text = "";
                }
                else
                {
                    lblProfessor.Text = professors[lblSubjects.SelectedIndex];
                }

                foreach (ListItem item in lblCredits.Items)
                {
                    item.Selected = false;
                }

                lblCredits.SelectedIndex = lblSubjects.SelectedIndex;

                //lblCredits.Items[lblSubjects.SelectedIndex].Selected = true;
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("UspeshnoGlasanje.aspx");
        }
    }
}