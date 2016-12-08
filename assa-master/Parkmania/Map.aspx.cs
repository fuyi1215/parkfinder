using DataModel;
using Parkmania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parkmania
{
    public partial class Detail : System.Web.UI.Page
    {
        Collection dataMode = new Collection();
        List<String> oGeocodeList = new List<String>();
        List<String> oMessageList = new List<String>();
        List<Place> placelist = new List<Place>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // oGeocodeList = new List<String>
            //{
            //    " '40.756012, -73.972614' ",
            //    " '40.456012, -73.796087' ",
            //    " '40.456012, -73.456807' "
            //  };

            conn_Test();
            var geocodevalues = string.Join(",", oGeocodeList.ToArray());
            //var geocodevalues = string.Join(",", .ToArray());
            //List<String> oMessageList = new List<String> {
            //" '<span class=formatText >Google Map 3 Awesome !!!</span>' ",
            //" '<span class=formatText>Made it very simple</span>' ",
            //" '<span class=formatText>Google Rocks</span>' "
            //};

            String message = string.Join(",", oMessageList.ToArray());

            ClientScript.RegisterArrayDeclaration("locationList", geocodevalues);

            ClientScript.RegisterArrayDeclaration("message", message);
        }
        
        protected void conn_Test()
        {
            Models.PlacesWebCollection pwc = new Models.PlacesWebCollection();
            pwc.load();
            placelist = pwc.placelist;

            
            List<string> loc = new List<string>();
            var Beaches = from i in placelist.OfType<DataModel.Beach>()
                          where !string.IsNullOrEmpty(i.longlatitude)
                          select new
                          {
                              lnglat = i.longlatitude.Replace("(", " '").Replace(")", "' "),
                              Name = i.name
                          };

            var Parks = from i in placelist.OfType<DataModel.Park>()
                        where !string.IsNullOrEmpty(i.Location_1)
                        select new
                        {
                            Name = i.Park_Name,
                            Location = i.Location_1
                            //Lnglat = i.Location_1.Substring(i.Location_1.IndexOf('('))
                        };
            //.Substring(0, i.Location_1.IndexOf('('))
            //

            foreach (var item in Beaches)
            {
                oGeocodeList.Add(item.lnglat);
                oMessageList.Add(string.Format("\" '<span class=formatText >{0}</span>' \"", item.Name));
            }

            foreach (var item in Parks)
            {
                if (item.Location.Contains("("))
                {
                    var Location = item.Location.Substring(0, item.Location.IndexOf('('));

                    var Lnglat = item.Location.Substring(item.Location.IndexOf('(')).Replace("(", " '").Replace(")", "' ");
                    oGeocodeList.Add(Lnglat);
                    oMessageList.Add(string.Format("\" '<span class=formatText >{0} </span>' \"", item.Name));
                }
            }

          
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            display_linq();
        }

        protected void display_linq()
        {


            string display;
            
                    var TN_B = placelist.OfType<DataModel.Beach>().ToList().FindAll(v => v.theType == "Zoo").Count();
                     display = "Total Number of Zoo:" + TN_B.ToString();
                   

                    var NumberTypequary = from p in placelist
                                          where !string.IsNullOrEmpty(p.theType)
                                          group p by p.theType into ty

                                          select new { TN = ty.Count(), P = ty.Key };
                    foreach (var item in NumberTypequary)
                           display +=string.Format( "{3} {0}:  {1}",item.P, item.TN, Environment.NewLine);
                 

                  

            Literal1.Text = display;
      
        }
    }
    
}