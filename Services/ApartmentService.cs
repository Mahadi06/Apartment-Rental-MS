using Entity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Services
{
    public class ApartmentService
    {
        ApartmentRepository apRepo;
        public ApartmentService()
        {
            apRepo = new ApartmentRepository();
        }

        public List<Apartment> GetAllApartments()
        {
            return apRepo.GetAll();
        }
        public Apartment GetByBedroom(int id)
        {
            return apRepo.Get(id);
        }
        public Apartment GetByArea(string area)
        {
            return apRepo.Get(area);
        }

        public Apartment GetByRent(double rent)
        {
            return apRepo.Get(rent);
        }

        public int Insert(Apartment a)
        {
            return apRepo.Insert(a);
        }
        public int Update(Apartment a)
        {
            return apRepo.Update(a);
        }

        public int Update2(Apartment a)
        {
            return apRepo.Update(a);
        }
        public int Delete(int id)
        {
            return apRepo.Delete(id);
        }
    }
}
