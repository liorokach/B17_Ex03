using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleFactory
{
    using Vehicle;
    using Car;
    using Motorcycle;
    using Truck;

    public class VehicleFactory
    {
        private List<string> vehicleTypes;

        public VehicleFactory()
        {
            vehicleTypes = new List<string>(3);
            vehicleTypes.Add("car");
            vehicleTypes.Add("motorcycle");
            vehicleTypes.Add("truck");            
        }

        public static Vehicle CreateNewCar(string i_Model, string i_LicenceID, string i_WheelProducer, int i_NumWheels, float i_CurPressure,
               float i_MaxPressure, float i_CurEnergy, float i_MaxEnergy, string i_EngineType, string i_CarColor, int i_NumDoors)
        {
            Car newCar = new Car(i_Model, i_LicenceID, i_WheelProducer, i_NumWheels, i_CurPressure,
                i_MaxPressure, i_CurEnergy, i_MaxEnergy, i_EngineType, i_CarColor, i_NumDoors);
            return newCar;
        }

        public static Vehicle CreateNewMotorcycle(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure,
               float i_MaxPressure, float i_CurrEnergy, float i_MaxEnergy, string i_FuelType, string i_Licence, int i_Capacity)
        {
            Motorcycle newMotorcycle = new Motorcycle(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure,
                i_MaxPressure, i_CurrEnergy, i_MaxEnergy, i_FuelType, i_Licence, i_Capacity);
            return newMotorcycle;
        }

        public static Vehicle CreateNewTrack(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure, float i_MaxPressure,
               float i_CurrEnergy, float i_MaxEnergy, string i_fuelType, bool i_Dangerous, float i_MaxWeight)
        {
            Truck newTrack = new Truck(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure,
                i_CurrEnergy, i_MaxEnergy, i_fuelType, i_Dangerous, i_MaxWeight);
            return newTrack;
        }

        public void AddVehicleTypeToSystem(string i_NewType)
        {
            vehicleTypes.Add(i_NewType);
        }
    }
}
