using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace AutoWebService.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    [DataContract]
    public abstract class CarAdvertisement
    {
        #region Private Members
        private int id;
        private string title;
        private Fuel MyFuel;
        private int price;
        private bool newCar;

        #endregion

        #region Properties
        [DataMember(Name = "id", Order = 0)]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [DataMember(Name = "title", Order = 1)]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        [DataMember(Name = "carfuel", Order = 2)]
        public Fuel CarFuel
        {
            get
            {
                return this.MyFuel;
            }
            set
            {
                this.MyFuel = value;
            }
        }

        [DataMember(Name = "price", Order = 3)]
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        [DataMember(Name = "newcar", Order = 4)]
        public bool NewCar
        {
            get
            {
                return this.newCar;
            }
            set
            {
                this.newCar = value;
            }
        }
        #endregion

        #region Default Constructor
        // *** Needed only for Serialization.
        public CarAdvertisement()
        {

        }
        #endregion

        // Useful for having derived classes (NewCar, UsedCar) call the base Constructor 
        // and instantiate protected data.
        #region Protected Constructor
        protected CarAdvertisement(int newId, string newTitle, Fuel NewMyFuel, int newPrice, bool newCar)
        {
            this.id = newId;
            this.title = newTitle;
            this.MyFuel = NewMyFuel;
            this.price = newPrice;
            this.newCar = newCar;
        }
        #endregion
    }
}