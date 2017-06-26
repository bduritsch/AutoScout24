using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoWebService.Models;

namespace AutoWebService.Services
{
    public class CarRepository
    {
        private List<CarAdvertisement> UsedCarAdvertisements;

        #region Constructor
        public CarRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    this.UsedCarAdvertisements = new List<CarAdvertisement>();

                    Fuel GasFuel = new Fuel();
                    GasFuel.CurrentFuel = "Gasoline";
                    int id = 1;
                    string title = "BMW E89 Z4 Roadster";

                    int price = 23459;
                    bool newCar = false;
                    int newMileage = 33000;

                    string registeredDate = "01/08/2008";
                    DateTime NewFirstRegistration = new DateTime();
                    NewFirstRegistration = Convert.ToDateTime(registeredDate);

                    UsedCar TestCar1 = new UsedCar(id, title, GasFuel, price, newCar, newMileage, NewFirstRegistration);
                    this.UsedCarAdvertisements.Add(TestCar1);

                    /*
                    UsedCar MyCar = new UsedCar[]
                    {
                        new UsedCar
                        {
                            Id = 1, Name = "Glenn Block"
                        },
                        new UsedCar
                        {
                            Id = 2, Name = "Dan Roth"
                        }
                    };
                    */

                    ctx.Cache[CacheKey] = this.UsedCarAdvertisements.ToArray();
                }
            }
        }
        #endregion

        #region Private Members
        private const string CacheKey = "CarStore";
        #endregion

        public CarAdvertisement[] GetAllCarAdvertisements()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {

                return (CarAdvertisement[])ctx.Cache[CacheKey];
            }

            return this.UsedCarAdvertisements.ToArray();
            /*
            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
            */
        }
        public bool SaveCar(CarAdvertisement CarAdvert)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((CarAdvertisement[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(CarAdvert);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}