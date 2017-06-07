using System;
using System.Collections.Generic;

namespace Car
{
     using eCarColor;
     using eNumDoors;
     using Vehicle;
     using Engine;
     using EnumStatic;
     using eNumOfWheels;

     public class Car : Vehicle
     {
          private eCarColor e_color;
          private eNumDoors e_numOfDoors;

          public Car(string i_Model, string i_LicenceID, string i_WheelProducer, eNumOfWheels i_NumWheels, float i_CurPressure, float i_MaxPressure, eCarColor i_CarColor, eNumDoors i_NumDoors, Engine i_Engine)
                : base(i_Model, i_LicenceID, i_WheelProducer, i_NumWheels, i_CurPressure, i_MaxPressure, i_Engine)
          {
               e_color = i_CarColor;
               e_numOfDoors = i_NumDoors;
          }

          public static Dictionary<string, Type> GetDictionaryOfQuestionsAndTypes(eEngineType.eEngineType i_EngineType)
          {
               Dictionary<string, Type> questionsAndTypes = GetVehicleQuestionsAndTypes(i_EngineType);
               string carColor = string.Format("please enter car color:\n{0}", EnumStatic.GetInstructionByEnum<eCarColor>());
               questionsAndTypes.Add(carColor, typeof(eCarColor));
               string numDoors = string.Format("please enter num of doors:\n{0}", EnumStatic.GetInstructionByEnum<eNumDoors>());
               questionsAndTypes.Add(numDoors, typeof(eNumDoors));
               return questionsAndTypes;
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.AddRange(base.GetVehicleDetails());
               details.Add(string.Format("car color: {0}", e_color.ToString()));
               details.Add(string.Format("num of doors: {0}", e_numOfDoors.ToString()));
               return details;
          }
     }
}