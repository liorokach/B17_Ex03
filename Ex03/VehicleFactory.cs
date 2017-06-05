using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleFactory
{
    using Vehicle;
    using Car;
    using Motorcycle;
    using Truck;
    using Engine;
    using OnElectricity;
    using OnFuel;
    using eFuelType;

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
        public static Engine CreateEngineOnFuel(float i_RemainTime, float i_MaxTime, eFuelType i_FuelType)
        {
            OnFuel fuelEngine = new OnFuel(i_RemainTime, i_MaxTime, i_FuelType);
            return fuelEngine;
        }
        public static Engine CreateEngineElectricity(float i_RemainTime,float i_MaxTime)
        {
            OnElectricity electricEngine = new OnElectricity(i_RemainTime, i_MaxTime);
            return electricEngine;
        }


        /*public static Vehicle CreateNewCar(List<KeyValuePair<string, Type>> i_PairsStrTypeArr)
        {
            Car newCar;
            return newCar;
        }

        public static Vehicle CreateNewMotorcycle(List<KeyValuePair<string, Type>> i_PairsStrTypeArr)
        {
            Motorcycle newMotorcycle;
            return newMotorcycle;
        }

        public static Vehicle CreateNewTruck(List<KeyValuePair<string, Type>> i_PairsStrTypeArr)
        {
            Truck newTruck;
            return newTruck;
        }
        */
        //public static Vehicle CreateNewCar(string i_Model, string i_LicenceID, string i_WheelProducer, int i_NumWheels, float i_CurPressure,
        //       float i_MaxPressure,string i_CarColor, int i_NumDoors,Engine i_Engine)
        //{
        //    Car newCar = new Car(i_Model, i_LicenceID, i_WheelProducer, i_NumWheels, i_CurPressure,
        //        i_MaxPressure, i_CarColor, i_NumDoors, i_Engine);
        //    return newCar;
        //}

        //public static Vehicle CreateNewMotorcycle(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure,
        //       float i_MaxPressure, string i_Licence, int i_Capacity,Engine i_Engine)
        //{
        //    Motorcycle newMotorcycle = new Motorcycle(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure,
        //        i_MaxPressure, i_Licence, i_Capacity,i_Engine);
        //    return newMotorcycle;
        //}

        //public static Vehicle CreateNewTruck(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure, float i_MaxPressure,
        //        bool i_Dangerous, float i_MaxWeight,Engine i_Engine)
        //{
        //    Truck newTrack = new Truck(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure,
        //        i_Dangerous, i_MaxWeight,i_Engine);
        //    return newTrack;
        //}

        public void AddVehicleTypeToSystem(string i_NewType)
        {
            vehicleTypes.Add(i_NewType);
        }
    }
}
