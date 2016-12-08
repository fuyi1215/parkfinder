using Parkmania.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModel;

namespace Parkmania
{
    
    public partial class _Default : Page
    {
        IEnumerable<Place> Plist;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Plist == null)
            {
                Models.PlacesWebCollection pwc = new Models.PlacesWebCollection();
                pwc.load();
                Plist = pwc.placelist;
            }
            if (!IsPostBack)
            {
                Models.PlacesWebCollection pwc = new Models.PlacesWebCollection();
                pwc.load();
                Plist = pwc.placelist;
            }
            else
            {
                
            }
            


        }
        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string name = GridView1.DataKeys[index].Value.ToString();
                //where i.Field<String>("Code").Equals(code)
                var query = from i in Plist
                             where i.name == name
                             select i;
                List<DataModel.Park> park = new List<DataModel.Park>();
                List<DataModel.Beach> Beach = new List<DataModel.Beach>();
                foreach (var i in query)
                {
                    if (i is DataModel.Park)
                    {
                        park.Add((DataModel.Park)i);

                        DetailsView1.DataSource = park;
                    }
                    else
                    {
                        Beach.Add((DataModel.Beach)i);
                        DetailsView1.DataSource = Beach;

                    }
                   
                }
                 DetailsView1.DataBind();


                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#currentdetail').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                           "ModalScript", sb.ToString(), false);
                //Page.ClientScript.RegisterStartupScript(this.GetType(),
                //  "ModalScript", sb.ToString());
            }
        }

        protected void ListViewPark_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
        //        e.Row.ToolTip = "Click to select this row.";
        //    }
        //}
        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow row in GridView1.Rows)
        //    {
        //        if (row.RowIndex == GridView1.SelectedIndex)
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
        //            row.ToolTip = string.Empty;
                    
        //        }
        //        else
        //        {
        //            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        //            row.ToolTip = "Click to select this row.";
        //        }
        //    }
            
        //<asp:ContentPlaceHolder ID="MainContent" runat="server">
           // </asp:ContentPlaceHolder>}

        protected void DetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(TextBox1.Text))
            {
                var list = Collection.search(Plist,TextBox1.Text.ToLower(),DropDownListSearch.SelectedIndex);
                GridView1.DataSource = list.ToList();
                GridView1.DataBind();
            }
            else
            {
               
                GridView1.DataSource = Plist.ToList();
                GridView1.DataBind();
            }
            
        }


        protected void DropDownListSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}