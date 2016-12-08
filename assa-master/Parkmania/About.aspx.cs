using Parkmania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parkmania
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                Validate();
                if (IsValid)
                    TextID.Text = " ";
            }
            

        }
       

        protected void filter(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (yf2_1583911Entities1 MyTables = new yf2_1583911Entities1())
            {
                var i = MyTables.Parks.First(d => d.ID == Convert.ToInt32 (TextID.Text));
               
                i.Park_Name = TextParkname.Text;
                i.Park_Type= TextParkTyp.Text;
                i.Location_1 = Textloc.Text;
                i.Zip_Code = Convert.ToInt32(TextZip.Text);
                MyTables.SaveChanges();

               
                GridView1.DataBind();
               
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (yf2_1583911Entities1 MyTables = new yf2_1583911Entities1())
            {
                var BeachID = Convert.ToInt32(TextID.Text);
                var f = MyTables.Beaches.First(a => a.id == BeachID);
                f.name = Textname.Text;
                f.Location = Textloc.Text;
                f.County = TextCo.Text;
                MyTables.SaveChanges();

                GridView2.DataBind();
            }
        }

        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}