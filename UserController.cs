using ParkNGoFinal.Models;
using ParkNGoFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkNGoFinal.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public void Register(UserDetail userData)
        {
            using (var db = new ParkNGODBEntities())
            {
                if (userData != null)
                {
                    db.UserDetails.Add(userData);
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void AddVehicle(string number = "Gj18BB1231", int id=1)
        {
            using (var db = new ParkNGODBEntities())
            {
                if (number != null)
                {
                    VehicleDetail details = new VehicleDetail();
                    details.UserID = id;
                    details.VehicleNumber = number;
                    db.VehicleDetails.Add(details);
                    db.SaveChanges();
                }
            }
        }

        // GET api/user


        [HttpPost]
        public UserDetail Login(string userID= "asha.patel@gmail.com", string password="12345")
        {
            using (var db = new ParkNGODBEntities())
            {
                UserDetail data = db.UserDetails.Where(x => x.UserEmail == userID && x.UserPassword == password).FirstOrDefault();
                return data;
            }
        }

        public List<VehicleList> GetVehicleNumber(int id)
        {
            using (var db = new ParkNGODBEntities())
            {
                var vehicleList = db.VehicleDetails.Where(x => x.UserID == id).Select(z => new VehicleList()
                {
                    VehicleID = z.VehicleID,
                    VehicleNumber = z.VehicleNumber
                }).ToList();

                return vehicleList;
            }
        }


        public List<LocationList> ViewRecord(int id)
        {
            using (var db = new ParkNGODBEntities())
            {
                var LocationList = db.LocationDetails.Where(x => x.VehicleID == id).Select(z => new LocationList()
                {
                    LocationID = z.LocationID,
                    Location = z.Location,
                    CreatedDateTime = z.CreatedDateTime
                }).ToList();

                return LocationList;
            }
        }

        public LocationList GetLocation(int id)
        {
            using (var db = new ParkNGODBEntities())
            {
                var LocationList = db.LocationDetails.Where(x => x.VehicleID == id).OrderByDescending(y => y.CreatedDateTime).Select(z => new LocationList()
                {
                    LocationID = z.LocationID,
                    Location = z.Location,
                    CreatedDateTime = z.CreatedDateTime
                }).FirstOrDefault();

                return LocationList;
            }
        }

        public bool SetLocation(LocationDetail location)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ParkNGODBEntities())
                {
                    ////LocationDetail locationData = new LocationDetail();

                    ////locationData.CreatedDateTime = new DateTime();
                    ////locationData.VehicleID = location.VehicleID;
                    ////locationData.Location = location.Location;
                    var locationData = db.LocationDetails.Add(location);
                    db.SaveChanges();
                    if (locationData.LocationID > 0)
                    {
                        return true;
                    }
                    return false;

                }
            }
            else
            {
                return false;
            }
        }



    }
}
