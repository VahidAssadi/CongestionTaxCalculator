using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.DomainModels
{
    public static class VehicleInfoService
    {
        private static readonly Dictionary<string, VehicleType> _licensePlateDatabase = new()
        {
            { "BSS", VehicleType.Busses },
            { "EMR", VehicleType.Emergency },
            { "DPL", VehicleType.Diplomat },
            { "MTR", VehicleType.Motorcycle },
            { "MIL", VehicleType.Military },
            { "FRN", VehicleType.Foreign },
            { "REG", VehicleType.RegularCar },
        };

        public static VehicleType GetVehicleType(string licensePlate)
        {
            return _licensePlateDatabase.TryGetValue(licensePlate[..3].ToUpperInvariant(), out var vehicleType)
                ? vehicleType
                : throw new Exception("Vehicle type not found for this license plate");
        }
    }
}