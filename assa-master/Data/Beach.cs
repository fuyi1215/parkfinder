using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataModel
{
    public class Beach : Place
    {
        
        public int ID { get; set; }
        public int beachID {get; set;}
        public string phone { get; set; }

        public string County { get; set; } = string.Empty;

        public string EnteranceFee { get; set; } = string.Empty;

        public string PermitRequired { get; set; } = string.Empty;

        public string UnitDescription { get; set; } = string.Empty;

        public string TotalNumofSites { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Location_1 { get; set; } = string.Empty;


        public string longlatitude { get; set; } = string.Empty;
       
        public Beach() : base()
        {
            ID = id;
            base.name = "";
            base.thelocation = "";
            base.theType = "Beach";
            longlatitude = "";
        }
        public Beach(int Bid,string Name, string Location, string Phone, string Zip,string longlat,string description
            , Nullable<double> _EntraceFee
            , Nullable<double> _PermitRequired, string _UnitDescription
            , Nullable<double> _TotalNumofSites)
            :base(Name,Location,"Beach",Zip)
        {
            ID = id;
            beachID = Bid;
            base.name = Name;
            base.thelocation = Location;
            Description = description;
            EnteranceFee = EnteranceFee;
            PermitRequired = _PermitRequired.ToString();
            UnitDescription = _UnitDescription;
            TotalNumofSites = TotalNumofSites.ToString();
            //base.Type = "Beach";
            phone= Phone;
            base.zip_code = Zip;
            longlatitude = longlat;
            
        }
        public string phoneNumber
        {
            get { return phone; }
            set {
                string text = "(124) 652 9658";

                if (!Regex.Match(text, @"^[1-9]\d{2}-[1-9]\d{2}-\d{4}$").Success)
                {
                    Console.WriteLine("Invalid phone number");
                }
            }
        } 

        
        public static Beach FromCsv(string csvLine)
        {


            string[] values = Csvsplit(csvLine);


            //string[] values = csvLine.Split(',');
            
            if (values.Length < 9)
            {
                return null;
            }
            else
            {
                Beach beach = new Beach();
                beach.theType = "Beach";
                beach.beachID = string.IsNullOrEmpty(values[0]) ? 0 : Convert.ToInt32(values[0]);
                beach.name = values[1];
                beach.phone = values[2];
                beach.County = values[3];
                beach.EnteranceFee = values[4];
                beach.PermitRequired = values[5];
                beach.UnitDescription = values[6];
                beach.TotalNumofSites = values[7];
                beach.Description = values[8];
                beach.longlatitude = values[9];
                return beach;
            }
        }
        public override string ToString()
        {
            return  string.Format("ID:{0,3}  Name:{1,10}  Park Type: {2,5}  PhoneNumber:{3,10}  Location: {4}"
                                   ,ID, name, base.theType, phone, longlatitude.ToString());
        }

        
    }
}
