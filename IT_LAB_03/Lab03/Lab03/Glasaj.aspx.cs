using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab03
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
                    "Оперативни системи",
                    "Софтверско инженерство",
                    "Концепти на информатичко општество",
                    "Дигитално процесирање на слика"
                };

                foreach (string subject in subjects)
                {
                    lblSubjects.Items.Add(subject);
                }

                string[] credits = new string[]
                {
                    "2",
                    "3",
                    "4",
                    "5",
                    "6"
                };

                foreach (string credit in credits)
                {
                    lblCredits.Items.Add(credit);
                }
            }
        }


        string[] professors = new string[]
        {
                "Магдалена Костоска",
                "Игор Мишковски",
                "Ѓорѓи Маџаров",
                "Владимир Здравески",
                "Ивица Димитровски"
        };

        protected void OnClick(object sender, EventArgs e)
        {
            if(lblSubjects.SelectedItem != null)
            {
                Response.Redirect("UspeshnoGlasanje.aspx");

            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if(lblSubjects.SelectedIndex != -1 && lblSubjects.SelectedIndex < lblCredits.Items.Count)
            {
                if(lblSubjects.SelectedIndex >= professors.Length)
                {
                    lblProfessor.Text = "";
                }
                else
                {
                    lblProfessor.Text = professors[lblSubjects.SelectedIndex];
                }

                foreach(ListItem item in lblCredits.Items)
                {
                    item.Selected = false;
                }
                lblCredits.Items[lblSubjects.SelectedIndex].Selected = true;
            }
        }

        protected void addOnClick(object sender, EventArgs e)
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
                _credits.Text = "";
            }

            if(subjects != null && credits != null)
            {
                _subjects.Text = _credits.Text = "";
                lblSubjects.Items.Add(subjects);
                lblCredits.Items.Add(credits);
            }
        }

        protected void deleteOnClick(object sender, EventArgs e)
        {
            lblSubjects.Items.Remove(lblSubjects.SelectedItem);
            lblCredits.Items.Remove(lblCredits.SelectedItem);
        }
    }
}