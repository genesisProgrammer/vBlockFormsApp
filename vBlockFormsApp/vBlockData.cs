using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vBlockFormsApp
{
    class vBlockData
    {
        //Maybe not needed?? Additional forms are all using something of the same name, but just as a placeholder for 
        //adding/editing the csv. Do these need to be defined as global-ish variables that all the forms can access?


        public vBlockData()
        {

        }

        public string machineName { get; set; }
        public string vBlock { get; set; }
        public string URL { get; set; }
        public string folder { get; set; }
        public string subFolder { get; set; }
        private static string _csvLocation = @"C:\Users\achapman\Desktop\vBlock.csv";

       



        public static string csvLocation
        {
            get { return _csvLocation; }
            set { _csvLocation = value; }
        }
    }
}
