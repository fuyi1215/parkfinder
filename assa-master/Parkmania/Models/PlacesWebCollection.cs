using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkmania.Models
{
    enum PlaceType
    {
        Park,
        Beach
    }
    public class PlacesWebCollection
    {
        private List<Place> Placelist;
        //private List<Park> Parklist;
        //private List<Beach> Beachlist;
        
        public PlacesWebCollection()
        {
            Placelist = new List<Place>();
            
        }
        public PlacesWebCollection(List<Place> placelist)
        {
            Placelist = placelist;
        }
        public void load()
        {
            
            using (yf2_1583911Entities1 myTables = new yf2_1583911Entities1())
            {

                var Parks = from i in myTables.Parks
                            select i;

                foreach (var item in Parks)
                {
                    placelist.Add(copyTo(item));
                }
                var Beaches = from i in myTables.Beaches
                           select i;
    
                foreach (var item in Beaches)
                {
                    // DataModel.Beach beach = new DataModel.Beach();
                    //Placelist.Add(new DataModel.Beach(item.Bid, item.name, item.County, item.Phone, "", item.Location, item.Description, item.EntranceFee, item.PermitRequired, item.UnitDescription, item.TotalNumofSites)) ;
                    placelist.Add(copyTo(item));
                }
                
                
            }
        }

        public List<Place> placelist { get { return Placelist ; } }


        private DataModel.Park copyTo(Park _park)
        {
            var park = new DataModel.Park();
           
            park.Park_Name = _park.Park_Name;
            park.name = park.Park_Name;
            park.Park_Type = _park.Park_Type;
            park.theType = park.Park_Type;
            park.zipcode = _park.Zip_Code.ToString();
            park.zip_code = park.zipcode;
            park.Aqua_Feat__Pool = _park.Aqua_Feat__Pool != null ? Convert.ToInt32(_park.Aqua_Feat__Pool):0;
            park.Aqua_Feat__Spray = _park.Aqua_Feat__Spray != null ? Convert.ToInt32(_park.Aqua_Feat__Spray) : 0;
            park.Backstop__Practice = _park.Backstop__Practice;
            park.Ballfield = _park.Ballfield != null ? Convert.ToInt32(_park.Ballfield) : 0;
            park.Basketball = _park.Basketball != null ? Convert.ToDouble(_park.Basketball) : 0;
            park.Blueway = _park.Blueway != null ? Convert.ToInt32(_park.Blueway) : 0;
            park.Complex__Ballfield = _park.Complex__Ballfield;
            park.Complex__Tennis = _park.Complex__Tennis;
            park.Concessions = _park.Concessions;
            park.Disk_Golf = _park.Disk_Golf;
            park.Driving_Range = _park.Driving_Range;
            park.Educational_Experience = _park.Educational_Experience != null ? Convert.ToInt32(_park.Educational_Experience) : 0; ;
            park.Event_Space = _park.Event_Space != null ? Convert.ToInt32(_park.Event_Space) : 0;
            park.Fitness_Course = _park.Fitness_Course;
            park.Garden__Community = _park.Garden__Community != null ? Convert.ToInt32(_park.Garden__Community) : 0;
            park.Garden__Display = _park.Garden__Display != null ? Convert.ToInt32(_park.Garden__Display) : 0;
            park.Golf = _park.Golf;
            park.Hockey__Ice = _park.Hockey__Ice;
            park.Loop_Walk = _park.Loop_Walk != null ? Convert.ToInt32(_park.Loop_Walk) : 0;
            park.MP_Field__Large = _park.MP_Field__Large != null ? Convert.ToInt32(_park.MP_Field__Large) : 0;
            park.MP_Field__Multiple = _park.MP_Field__Multiple;
            park.MP_Field__Small = _park.MP_Field__Small != null ? Convert.ToInt32(_park.MP_Field__Small) : 0;
            park.Multiuse_Court = _park.Multiuse_Court;
            park.Natural_Area = _park.Natural_Area != null ? Convert.ToInt32(_park.Natural_Area) : 0;
            park.Open_Turf = _park.Open_Turf != null ? Convert.ToInt32(_park.Open_Turf) : 0;
            park.Open_Water = _park.Open_Water != null ? Convert.ToInt32(_park.Open_Water) : 0;
            park.Other___Active = _park.Other___Active;
            park.Other_Passive = _park.Other_Passive;
            park.Passive_Node = _park.Passive_Node != null ? Convert.ToInt32(_park.Passive_Node) : 0;
            park.Picnic_Grounds = _park.Picnic_Grounds != null ? Convert.ToInt32(_park.Picnic_Grounds) : 0;
            park.Playground__Destination = _park.Playground__Destination != null ? Convert.ToInt32(_park.Playground__Destination) : 0;
            park.Playground__local = _park.Playground__Local != null ? Convert.ToInt32(_park.Playground__Local) : 0; 
            park.Public_Art = _park.Public_Art != null ? Convert.ToInt32(_park.Public_Art) : 0;
            park.Shelter = _park.Shelter != null ? Convert.ToInt32(_park.Shelter) : 0;
            park.Shelter__Group = _park.Shelter__Group != null ? Convert.ToInt32(_park.Shelter__Group) : 0;
            park.Skate_Park = _park.Skate_Park != null ? Convert.ToInt32(_park.Skate_Park) : 0;
            park.Sledding_Hill = _park.Sledding_Hill;
            park.Structure = _park.Structure != null ? Convert.ToInt32(_park.Structure) : 0;
            park.Tennis = _park.Tennis;
            park.Trail__Primitive = _park.Trail__Primitive;
            park.Volleyball = _park.Volleyball;
            park.Water_Access__Developed = _park.Water_Access__Developed != null ? Convert.ToInt32(_park.Water_Access__Developed) : 0;
            park.Water_Access__General = _park.Water_Access__General != null ? Convert.ToInt32(_park.Water_Access__General) : 0;
            park.Water_Feature = _park.Water_Feature != null ? Convert.ToInt32(_park.Water_Feature) : 0;
            park.Location_1 = _park.Location_1;
            park.thelocation = park.Location_1;
            park.FID = _park.FID != null ? Convert.ToInt32(_park.FID) : 0;
            return park;
        }

        private DataModel.Beach copyTo(Beach _beach)
        {
            DataModel.Beach beach = new DataModel.Beach();
            beach.theType = _beach.UnitDescription;
            beach.thelocation = _beach.County;
      
            beach.beachID = _beach.Bid;
            beach.name = _beach.name;
            beach.phone = _beach.Phone;
            beach.County = _beach.County;
            beach.EnteranceFee = _beach.EntranceFee.ToString();
            beach.PermitRequired = _beach.PermitRequired.ToString();
            beach.UnitDescription = _beach.UnitDescription;
            beach.TotalNumofSites = _beach.TotalNumofSites.ToString();
            beach.Description = _beach.Description;
            beach.longlatitude = _beach.Location;
            return beach;

        }
    }
}
