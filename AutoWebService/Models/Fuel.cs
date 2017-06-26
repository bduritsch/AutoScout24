using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebService.Models
{
    public class Fuel
    {
        /** 
         * Extendable string constants for fuel-types. 
         * Insert additional types here in the future.
        */
        private const string gasoline = "Gasoline";
        private const string diesel = "Diesel";

        private string currentFuel;

        private List<string> FuelType = null;

        #region Properties
        public string CurrentFuel
        {
            get
            {
                return this.currentFuel;
            }
            set
            {
                // Check List of FuelType to be certain there exists a current fuel to be set.
                foreach (string fuelType in this.FuelType)
                {
                    switch (fuelType)
                    {
                        case "Gasoline":

                            if (value.Equals(fuelType))
                            {
                                this.currentFuel = value;
                            }
                            break;
                        case "Diesel":

                            if (value.Equals(fuelType))
                            {
                                this.currentFuel = value;
                            }
                            break;
                        default:

                            const string errorMsg = "Error: FuelType not currently available.";
                            value = errorMsg;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Default Constructor
        public Fuel()
        {
            this.currentFuel = null;

            // Encapsulate fuel-type strings and put them into a List for later retrieval.
            if (this.FuelType == null)
            {
                this.FuelType = new List<string>();

                this.FuelType.Add(gasoline);
                this.FuelType.Add(diesel);
            }
        }
        #endregion
    }
}