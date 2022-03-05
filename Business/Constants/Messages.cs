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
        public static string CarDetailsListed = "Car Details Listed.";
        public static string CarsListedWhicHasSpecifiedBrandId = "Cars Listed Which Has Specified BrandId!";
        public static string CarsListedWhicHasSpecifiedColorId = "Cars Listed Which Has Specified ColorId!";
        public static string MaintenanceTime = "Maintenance Time!";

        public static string UserAdded = "User Added.";
        public static string UserDeleted = "User Deleted.";
        public static string UsersListed = "Users Listed.";
        public static string UserUpdated = "User Updated.";

        public static string CustomerAdded = "Customer Added.";
        public static string CustomerDeleted = "Customer Deleted.";
        public static string CustomersListed = "Customers Listed.";
        public static string CustomerUpdated = "Customer Updated.";

        public static string RentalAdded = "Rental Added.";
        public static string RentalDeleted = "Rental Deleted.";
        public static string RentalsListed = "Rental Listed.";
        public static string RentalUpdated = "Rental Updated.";
    }
}
