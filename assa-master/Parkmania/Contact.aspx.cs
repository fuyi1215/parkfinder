using Parkmania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parkmania
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (yf2_1583911Entities1 MyTables = new yf2_1583911Entities1())
            {
                Park MyItem = new Park { Park_Name = TextBox1.Text, Location_1 = TextBox2.Text, Zip_Code = Convert.ToInt32(TextBox3.Text) };
                MyTables.Parks.Add(MyItem);
                MyTables.SaveChanges();

                GridView1.DataBind();

                LblStatus.Text = "Inserted";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (yf2_1583911Entities1 MyTables = new yf2_1583911Entities1())
            {
                Beach MyItem = new Beach { name = TextBox1.Text, Location = TextBox2.Text, County = TextBox4.Text };
                MyTables.Beaches.Add(MyItem);
                MyTables.SaveChanges();
                
                GridView2.DataBind();

                LblStatus.Text = "Inserted";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (yf2_1583911Entities1 MyTables = new yf2_1583911Entities1())
            {
                MyTables.Parks.RemoveRange(MyTables.Parks);
                MyTables.SaveChanges();
                LblStatus.Text = "Deleted";

                GridView1.DataBind();
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}