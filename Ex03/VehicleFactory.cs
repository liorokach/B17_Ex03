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
     using eEngineType;
     using eNumOfWheels;
     using eCarColor;
     using eNumDoors;
     using eLicenceType;
     using ValueOutOfRangeException;

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

          public static Engine CreateEngineElectricity(float i_RemainTime, float i_MaxTime)
          {
               OnElectricity electricEngine = new OnElectricity(i_RemainTime, i_MaxTime);
               return electricEngine;
          }

          public static void ValidateMaxNotSmallerThenCurrent(float i_CurValue, float i_MaxValue)
          {
               if (i_CurValue > i_MaxValue)
               {
                    throw new ValueOutOfRangeException(i_MaxValue - i_CurValue, 0);
               }
          }

          public static Vehicle CreateNewCar(List<object> i_ListValues, eEngineType i_EngineType)
          {
               Engine newEngine;
               Car newCar;
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[6], (float)i_ListValues[7]);
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[1], (float)i_ListValues[2]);
               if (i_EngineType == eEngineType.OnElectric)
               {
                    newEngine = CreateEngineElectricity((float)i_ListValues[6], (float)i_ListValues[7]);
                    newCar = new Car((string)i_ListValues[4], (string)i_ListValues[5], (string)i_ListValues[0], (eNumOfWheels)i_ListValues[3], (float)i_ListValues[1], (float)i_ListValues[2], (eCarColor)i_ListValues[8], (eNumDoors)i_ListValues[9], newEngine);
               }
               else
               {
                    newEngine = CreateEngineOnFuel((float)i_ListValues[6], (float)i_ListValues[7], (eFuelType)i_ListValues[8]);
                    newCar = new Car((string)i_ListValues[4], (string)i_ListValues[5], (string)i_ListValues[0], (eNumOfWheels)i_ListValues[3], (float)i_ListValues[1], (float)i_ListValues[2], (eCarColor)i_ListValues[9], (eNumDoors)i_ListValues[10], newEngine);
               }

               return newCar;
          }

          public static Vehicle CreateNewMotorcycle(List<object> i_ListValues, eEngineType i_EngineType)
          {
               Motorcycle newMotorcycle;
               Engine newEngine;
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[6], (float)i_ListValues[7]);
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[1], (float)i_ListValues[2]);
               if (i_EngineType == eEngineType.OnElectric)
               {
                    newEngine = CreateEngineElectricity((float)i_ListValues[6], (float)i_ListValues[7]);
                    newMotorcycle = new Motorcycle((string)i_ListValues[4], (string)i_ListValues[5], (string)i_ListValues[0], (eNumOfWheels)i_ListValues[3], (float)i_ListValues[1], (float)i_ListValues[2], (eLicenceType)i_ListValues[8], (int)i_ListValues[9], newEngine);
               }
               else
               {
                    newEngine = CreateEngineOnFuel((float)i_ListValues[6], (float)i_ListValues[7], (eFuelType)i_ListValues[8]);
                    newMotorcycle = new Motorcycle((string)i_ListValues[4], (string)i_ListValues[5], (string)i_ListValues[0], (eNumOfWheels)i_ListValues[3], (float)i_ListValues[1], (float)i_ListValues[2], (eLicenceType)i_ListValues[9], (int)i_ListValues[10], newEngine);
               }

               return newMotorcycle;
          }

          public static Vehicle CreateNewTruck(List<object> i_ListValues, eEngineType i_EngineType)
          {
               Truck newTruck;
               Engine newEngine;
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[6], (float)i_ListValues[7]);
               ValidateMaxNotSmallerThenCurrent((float)i_ListValues[1], (float)i_ListValues[2]);
               newEngine = CreateEngineOnFuel((float)i_ListValues[6], (float)i_ListValues[7], (eFuelType)i_ListValues[8]);
               newTruck = new Truck((string)i_ListValues[4], (string)i_ListValues[5], (string)i_ListValues[0], (eNumOfWheels)i_ListValues[3], (float)i_ListValues[1], (float)i_ListValues[2], (bool)i_ListValues[9], (float)i_ListValues[10], newEngine);
               return newTruck;
          }

          public void AddVehicleTypeToSystem(string i_NewType)
          {
               vehicleTypes.Add(i_NewType);
          }
     }
}
