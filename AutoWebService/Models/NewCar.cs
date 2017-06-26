using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebService.Models
{
    public sealed class NewCar : CarAdvertisement
    {
        #region Private Members
        private DateTime NewYear;
        #endregion

        #region Constructor
        public NewCar(int newId, string newTitle, Fuel NewMyFuel, int newPrice, bool newCar) : 
                        base(newId, newTitle, NewMyFuel, newPrice, newCar)
        {
            this.NewYear = new DateTime();

            // Set the "Year" attribute of "NewCar" Object to this current year.
            this.NewYear = NewYear.AddYears(DateTime.Now.Year);
        }
        #endregion
    }
}