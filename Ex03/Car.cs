using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
     using enumCarColor;
     using enumNumDoors;
     using Vehicle;
     public class Car : Vehicle
     {
          private eCarColor e_color;
          private eNumDoors e_numOfDoors;

          public Car(string i_Model, string i_LicenceID, string i_WheelProducer, int i_NumWheels, float i_CurPressure, 
               float i_MaxPressure, float i_CurEnergy, float i_MaxEnergy, string i_EngineType, string i_CarColor, int i_NumDoors)
                : base(i_Model, i_LicenceID, i_WheelProducer, i_NumWheels, i_CurPressure, i_MaxPressure, i_CurEnergy, i_MaxEnergy, i_EngineType)
          {
               try
               {
                    e_color = (eCarColor)Enum.Parse(typeof(eCarColor), i_CarColor, true);
                    e_numOfDoors = (eNumDoors)(i_NumDoors);
               }
               catch(Exception CarException)
               {
                    //// let the user know what was the problem
               }
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.Add(e_color.ToString());
               details.Add(e_numOfDoors.ToString());
               details.AddRange(base.GetVehicleDetails());
               return details;
          }

     }
}
