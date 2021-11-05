using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Section { get; set; }
        public string FlatNo { get; set; }
        public int RoadNo { get; set; }
        public int HouseNo { get; set; }
        public double Rent { get; set; }
        public int BedRoom { get; set; }
        public int WashRoom { get; set; }
        public int Balcony { get; set; }
        public int Status { get; set; }
        public int OwnerId { get; set; }
        public string OwnerEmail { get; set; }


        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
       
     

    }
}
