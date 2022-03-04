using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Brand Added.";
        public static string BrandDeleted = "Brand Deleted.";
        public static string BrandsListed = "Brands Listed.";
        public static string BrandUpdated = "Brand Updated.";

        public static string ColorAdded = "Color Added.";
        public static string ColorDeleted = "Color Deleted.";
        public static string ColorsListed = "Colors Listed.";
        public static string ColorUpdated = "Color Updated.";

        public static string CarAdded = "Car Added.";
        public static string CarDeleted = "Car Deleted.";
        public static string CarsListed = "Cars Listed.";
        public static string CarUpdated = "Car Updated.";
        public static string CarNameCanNotBeLessThanTwoChar = "Description of the car can not be less than 2 character!";
        public static string PriceOfCarCanNotBeLessThanZero = "Daily price of the car can not be less than 0!";
        public static string CarDetailsListed = "Car Details Listed";
        public static string CarsListedWhicHasSpecifiedBrandId = "Cars Listed Whic Has Specified BrandId";
        public static string CarsListedWhicHasSpecifiedColorId = "Cars Listed Whic Has Specified ColorId";
        public static string MaintenanceTime = "Maintenance Time";
    }
}
