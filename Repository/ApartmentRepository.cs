using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Repositories
{
    public class ApartmentRepository : IRepository<Apartment>, IDisposable
    {
         DataAccess dataAccess;
        public ApartmentRepository()
        {
            dataAccess = new DataAccess();
        }

        public List<Apartment> GetAll()
        {
            string sql = "SELECT * FROM Apartments";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Apartment> apartment = new List<Apartment>();
            while (reader.Read())
            {
                Apartment ap = new Apartment();
                ap.Id = (int)reader["Id"];
                ap.Area = reader["Area"].ToString();
                ap.Section = reader["Section"].ToString();
                ap.FlatNo = reader["Flat_no"].ToString();
                ap.RoadNo = (int)reader["Road_no"];
                ap.HouseNo = (int)reader["House_no"];
                ap.Rent = Convert.ToSingle(reader["Rent"]);
                ap.BedRoom = (int)reader["Bedroom"];
                ap.WashRoom = (int)reader["Washroom"];
                ap.Balcony = (int)reader["Bedroom"];
                ap.Status = (int)reader["Status"];
                ap.OwnerId = (int)reader["Owner_id"];
                ap.CustomerId = (int)reader["Customer_id"];
                
              apartment.Add(ap);
            }
            return apartment;
        }

        public Apartment Get(int bedroom)
        {
            string sql = "SELECT * FROM Apartments WHERE Bedroom=" + bedroom;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
          Apartment ap = new Apartment();
          ap.Id = (int)reader["Id"];
          ap.Area = reader["Area"].ToString();
          ap.Section = reader["Section"].ToString();
          ap.FlatNo = reader["Flat_no"].ToString();
          ap.RoadNo = (int)reader["Road_no"];
          ap.HouseNo = (int)reader["House_no"];
          ap.Rent = Convert.ToSingle(reader["Rent"]);
          ap.BedRoom = (int)reader["Bedroom"];
          ap.WashRoom = (int)reader["Washroom"];
          ap.Balcony = (int)reader["Balcony"];
          ap.Status = (int)reader["Status"];
          ap.OwnerId = (int)reader["Owner_id"];
          ap.CustomerId = (int)reader["Customer_id"];
          
           dataAccess.Dispose();
            return ap;
          }

        public Apartment Get(double rent)
        {
            string sql = "SELECT * FROM Apartments WHERE Rent <" + rent;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Apartment ap = new Apartment();
            ap.Id = (int)reader["Id"];
            ap.Area = reader["Area"].ToString();
            ap.Section = reader["Section"].ToString();
            ap.FlatNo = reader["Flat_no"].ToString();
            ap.RoadNo = (int)reader["Road_no"];
            ap.HouseNo = (int)reader["House_no"];
            ap.Rent = Convert.ToSingle(reader["Rent"]);
            ap.BedRoom = (int)reader["Bedroom"];
            ap.WashRoom = (int)reader["Washroom"];
            ap.Balcony = (int)reader["Balcony"];
            ap.Status = (int)reader["Status"];
            ap.OwnerId = (int)reader["Owner_id"];
            ap.CustomerId = (int)reader["Customer_id"];
           
            dataAccess.Dispose();
            return ap;
        }


        public Apartment Get(string area)
        {
            string sql = "SELECT * FROM Apartments WHERE Area=" + area;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Apartment ap = new Apartment();
            ap.Id = (int)reader["Id"];
            ap.Area = reader["Area"].ToString();
            ap.Section = reader["Section"].ToString();
            ap.FlatNo = reader["Flat_no"].ToString();
            ap.RoadNo = (int)reader["Road_no"];
            ap.HouseNo = (int)reader["House_no"];
            ap.Rent = Convert.ToSingle(reader["Rent"]);
            ap.BedRoom = (int)reader["Bedroom"];
            ap.WashRoom = (int)reader["Washroom"];
            ap.Balcony = (int)reader["Balcony"];
            ap.Status = (int)reader["Status"];
            ap.OwnerId = (int)reader["Owner_id"];
            ap.CustomerId = (int)reader["Customer_id"];
            
            dataAccess.Dispose();
            return ap;

        }

        public int Insert(Apartment entity)
        {
            string sql = "INSERT INTO Apartments(Area,Road_no,House_no,Section,Flat_no,Rent,Bedroom,Washroom,Balcony,Status,Owner_id,Customer_id) VALUES ('" + entity.Area + "'," + entity.RoadNo + "," + entity.HouseNo + ",'"+entity.Section+"','" +entity.FlatNo+"',"+ entity.Rent + "," + entity.BedRoom + "," + entity.WashRoom + "," + entity.Balcony + "," + entity.Status + "," + entity.OwnerId + "," + entity.CustomerId + ")";
           // sql+="Insert into Apartment_Status (Status) values ("+entity.Status+")";
            return dataAccess.ExecuteQuery(sql);
        }

        public int Update(Apartment entity)
        {
            dataAccess = new DataAccess();
            string sql = "UPDATE Apartments SET Status="+1+"where Id="+entity.Id;
            
            return dataAccess.ExecuteQuery(sql);
        }

        

        public int Delete(int id)
        {

            string sql = "DELETE FROM Apartments WHERE Id=" + id;
            return dataAccess.ExecuteQuery(sql);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}
