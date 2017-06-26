using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace AutoWebService.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    [DataContract]
    public sealed class UsedCar : CarAdvertisement
    {
        // Constant int to set default mileage, and ensure is greater than 0 for "UsedCar".
        private const int baseMileage = 100;

        #region Private Members
        private int mileage;
        private DateTime firstRegistration;
        #endregion

        #region Properties
        [DataMember(Name = "mileage", Order = 5)]
        public int Mileage
        {
            get
            {
                return this.mileage;
            }
            set
            {
                this.mileage = value;
            }
        }

        [DataMember(Name = "firstregistration", Order = 6)]
        public DateTime FirstRegistration
        {
            get
            {
                return this.firstRegistration;
            }
            set
            {
                this.firstRegistration = value;
            }
        }
        #endregion

        #region Default Constrtuctor
        // *** Needed only for Serialization.
        public UsedCar()
        {

        }
        #endregion

        // Call base class' Constructor to access protected data members of "CarAdvertisement".
        #region Overloaded Constructor
        public UsedCar(int newId, string newTitle, Fuel NewMyFuel, int newPrice, bool newCar, int newMileage, DateTime NewFirstRegistration) :
                        base(newId, newTitle, NewMyFuel, newPrice, newCar)
        {
            this.Id = newId;
            this.Title = newTitle;
            this.CarFuel = NewMyFuel;
            this.Price = newPrice;
            this.NewCar = newCar;

            this.mileage = newMileage;
            this.FirstRegistration = NewFirstRegistration;
        }
        #endregion

        #region Factory Methods
        public static UsedCar CreateInstance(int newId, string newTitle, Fuel NewFuel, int newPrice,
                                            bool newCar, int newMileage, DateTime NewFirstRegistration)
        {
            DateTime CheckDate = new DateTime();
            CheckDate.AddDays(NewFirstRegistration.Day);
            CheckDate.AddMonths(NewFirstRegistration.Month);
            CheckDate.AddYears(NewFirstRegistration.Year);

            // Creates a CultureInfo for German in Germany.
            CultureInfo German = new CultureInfo("de-DE");
            // Displays dt, formatted using the ShortDatePattern
            // and the CultureInfo.
            string date = CheckDate.ToString("d", German);
            CheckDate = Convert.ToDateTime(date);

            /**** IMPORTANT: Check certain conditions are met before registering a "UsedCar" in the system. ****/
            if (newCar == false && newMileage > 0 && CheckDate.Date < System.DateTime.Now.Date)
            {
                return new UsedCar(newId, newTitle, NewFuel, newPrice, newCar, newMileage, NewFirstRegistration);
            }

            return null;
        }
        #endregion
    }
}