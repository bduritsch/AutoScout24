using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoWebService.Models;
using AutoWebService.Services;


namespace AutoWebService.Controllers
{
    public class CarAdvertisementController : ApiController
    {
        #region Private Member Variables
        private CarRepository CarRepository;
        #endregion

        #region Constructor
        public CarAdvertisementController()
        {
            this.CarRepository = new CarRepository();
        }
        #endregion

        public CarAdvertisement[] Get()
        {
            return this.CarRepository.GetAllCarAdvertisements();
        }
    }
}
