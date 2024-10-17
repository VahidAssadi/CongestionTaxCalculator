using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.DomainModels
{
    // In my Design model I consider that in the context of tax calculation the vehicle type identifying by it's license plate number 
    public record Vehicle
    {
        private Vehicle()
        {

        }
        public string LicencePlate { get; private set; }
        public Vehicle(string licensePlate)
        {
            LicencePlate = licensePlate;
        }
        private VehicleType GetVehicleType()
        {
            return VehicleInfoService.GetVehicleType(LicencePlate);
        }

        public bool IsTollFreeVehicle()
        {
            if (this == null) return false;
            var vehicleType = GetVehicleType();
            return vehicleType.Equals(VehicleType.Motorcycle) ||
                   vehicleType.Equals(VehicleType.Emergency) ||
                   vehicleType.Equals(VehicleType.Diplomat) ||
                   vehicleType.Equals(VehicleType.Foreign) ||
                   vehicleType.Equals(VehicleType.Military);
        }
    }
}