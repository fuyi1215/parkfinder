using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    enum PlaceType
    {
        Park,
        Beach
    }
    public class Collection 
    {
        private List<Place> Placelist;
        //private List<Park> Parklist;
        //private List<Beach> Beachlist;

        public Collection()
        {
            Placelist = new List<Place>();
        }
        public Collection(List<Place> placelist)
        {
            Placelist = placelist;
        }

        

        public  void load()
        {
            Placelist = new List<Place>();
            var Parkurl = "http://data.southbend.opendata.arcgis.com/datasets/7a50910bc067491b80c0b3d92a9a5598_0.csv";
             Placelist = load(Parkurl, PlaceType.Park).ToList();
            var Beachurl = "https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD";
             Placelist.AddRange(load(Beachurl, PlaceType.Beach));
        }

        public void add()
        {
            Console.WriteLine("Option 1) add a park");
            Console.WriteLine("Option 2) add a beach");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Name of the park:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Type of the park:");
                    var type = Console.ReadLine();
                    Console.WriteLine("Location of the park:");
                    var loc = Console.ReadLine();
                    Console.WriteLine("Zip of the park:");
                    var zip = Console.ReadLine();
                    var park = new Park(name, type, loc, zip);
                    Placelist.Add(park);
                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                    Console.WriteLine("\nResults: \n" + park.ToString());
                    break;
                case "2":
                    Console.WriteLine("Name of the Beach:");
                    var Bname = Console.ReadLine();
                    Console.WriteLine("Phone Number of the Beach:");
                    var Bphone = Console.ReadLine();
                    Console.WriteLine("Location of the Beach:");
                    var Bloc = Console.ReadLine();
                    Console.WriteLine("Zip of the Beach:");
                    var BZip = Console.ReadLine();
                    Console.WriteLine("longitude and latitude of the Beach:");
                    var Blonglat = Console.ReadLine();
                    //var beach = new Beach(Bname, Bloc, Bphone,BZip, Blonglat);
                    //Placelist.Add(beach);
                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                   // Console.WriteLine("\nResults: \n" + beach.ToString());
                    break;
                default:
                    break;
            }
        }

        public static List<Place> search(IEnumerable<Place> placelist, string search,int type)
        {
            var rlist = new List<Place>();
            
            int i;
            int o;
            if (type == 0)
            {

                return placelist.ToList<Place>().FindAll(
               (r => (r.name.ToLower().Contains(search))));
            }
            else if (type == 1)
            {
                var Parks = placelist.OfType<Park>().ToList<Park>().FindAll(
                    (r => r.zipcode.Contains(search)));

                foreach (var park in Parks)
                    rlist.Add(park);

                return rlist;
            }
            else if (type == 2)
            {

                return placelist.OfType<Place>().ToList<Place>().FindAll(r =>
                     r.thelocation.ToLower().Contains(search));

            }
            else if (type == 3)
            {
                return placelist.OfType<Place>().ToList<Place>().FindAll(
                    r => r.theType.ToLower().Contains(search));

            }
            else if (type == 4)
            {
                var Parksresults = placelist.OfType<Park>().ToList<Park>().FindAll(
                  (r => (int.TryParse(search, out i) && (r.Basketball == i))));

                foreach (var park in Parksresults)
                    rlist.Add(park);


                return rlist;
            }
            else if (type == 5)
            {

                var beachesreults = placelist.OfType<Beach>().ToList<Beach>().FindAll(
                    r => (int.TryParse(search, out i) && (int.TryParse(r.EnteranceFee, out o) &&
                    (o <= i))));

                foreach (var beach in beachesreults)
                    rlist.Add(beach);

                return rlist;
            }
            else if(type == 6)
            {
                var beachesreults = from item in placelist.OfType<Beach>()
                        where !string.IsNullOrEmpty(item.Description)
                        let words = item.Description.Split('.')
                        from word in words
                        where word.Contains("reserva")
                        select item;


                foreach (var beach in beachesreults)
                    rlist.Add(beach);

                return rlist;
            }
            else
                return null;

        }
        public void edit()
        {
            Console.WriteLine("Option 1) Edit a park");
            Console.WriteLine("Option 2) Edit a beach");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    Console.WriteLine("FID of park to edit:");
                    var fid = Console.ReadLine();
                    Console.WriteLine("Name of the park:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Type of the park:");
                    var type = Console.ReadLine();
                    Console.WriteLine("Location of the park:");
                    var loc = Console.ReadLine();
                    Console.WriteLine("Zip of the park:");
                    var zip = Console.ReadLine();
                    var park = Placelist.OfType<Park>().ToList<Park>().Find(p => p.FID == int.Parse(fid));
                    if (name.Length > 0) park.Park_Name = name;
                    if (type.Length > 0) park.Park_Type = type;
                    if (loc.Length > 0) park.Location_1 = loc;
                    if (zip.Length == 4) park.zip_code = zip;

                    Console.WriteLine("\nResults: \n" + park.ToString());
                    break;
                case "2":
                    Console.WriteLine("ID of Beach to edit:");
                    var Bid = Console.ReadLine();
                    Console.WriteLine("Name of the Beach:");
                    var Bname = Console.ReadLine();
                    Console.WriteLine("phone Number of the Beach:");
                    var Bphone = Console.ReadLine();
                    Console.WriteLine("Location of the Beach:");
                    var Bloc = Console.ReadLine();
                    //Console.WriteLine("Zip of the park:");
                    //var Bzip = Console.ReadLine();
                    var Beach = Placelist.OfType<Beach>().ToList<Beach>().Find(p => p.ID == int.Parse(Bid));
                    if (Bname.Length > 0) Beach.name = Bname;
                    if (Bphone.Length > 0)Beach.phoneNumber = Bphone;
                    if (Bloc.Length > 0) Beach.thelocation = Bloc;
                    

                    Console.WriteLine("\nResults: \n" + Beach.ToString());
                    break;
                default:
                    break;
            }
        }

      

        public void display()
        {
            Console.WriteLine( this.ToString());
        }


        // = Placelist.OfType<Park>

        




        private IEnumerable<Place> load(string urlstring, PlaceType Ptype)
        {
            string _content = string.Empty;
            using (var url = new WebClient())
            {
                try
                {
                    _content =
                        url.DownloadString(urlstring);

                }
                catch (WebException e)
                {
                    throw e;
                }
            }
            if (Ptype == PlaceType.Park)
            {
                
                var parkRow = Place.CsvRow(_content).Skip(1);
                
                 return parkRow.Select(v => Park.FromCsv(v))
                               .OfType<Park>().ToList();
                

            }
            else
            {
                var BeachRow  = Place.CsvRow(_content).Skip(1);

                //Beaches = new List<Beach>();
                return BeachRow.Select(v => Beach.FromCsv(v)).OfType<Beach>()
                                  .ToList();
            }

        }
        public void add(Place p)
        {
            if(p is Beach)
            {
                Placelist.Add((Beach)p);
            }
            else
            {
                Placelist.Add((Park)p);
            }
        }
        public IEnumerable<Place> FindBeachName(string value)
        {

            //if (P is Beach)
            //{
            //return Placelist.FindAll((r => (int.TryParse(value, out i) && ( r.Zip == i) || r.Park_Type.Contains(search) || r.Park_Name.Contains(search) || r.Location_1.Contains(search))));
            List<Beach> beachlist = new List<Beach>();
            foreach(var Beach in Placelist.OfType<Beach>())
            {
                if(Beach.name.Contains(value))
                {
                    beachlist.Add(Beach);
                }
            }

            return beachlist;

        }
        
            //foreach (var park in Parks)
            //{
            //    if (park != null)
            //        Console.WriteLine(park.ToString());
            //}
            //foreach (var beach in Beaches)
            //{
            //    if (beach != null)
            //        Console.WriteLine(beach.ToString());
            //}
        public override string ToString()
        {
            string result = "\nResults: \n";
            Beach beach;
            Park park;
            foreach (var p in Placelist)
            {
                if (p is Beach)
                {
                    beach = p as Beach;
                   result += beach.ToString()+"\n";
                }
                else
                {
                    park = p as Park;
                    if(park != null)
                        result += park.ToString() + "\n";                   
                }
            }
            return result;
            
        }

    }
}
