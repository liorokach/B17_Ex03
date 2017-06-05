using System;
using System.Collections.Generic;

namespace Car
{
     using eCarColor;
     using eNumDoors;
     using Vehicle;
     using Engine;
     using EnumStatic;
     public class Car : Vehicle
     {
          private eCarColor e_color;
          private eNumDoors e_numOfDoors;

          public Car(string i_Model, string i_LicenceID, string i_WheelProducer, int i_NumWheels, float i_CurPressure, 
               float i_MaxPressure, string i_CarColor, int i_NumDoors,Engine i_Engine)
                : base(i_Model, i_LicenceID, i_WheelProducer, i_NumWheels, i_CurPressure, i_MaxPressure,i_Engine)
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

          public static Dictionary<string, Type> GetDictionaryOfQuestionsAndTypes(eEngineType.eEngineType i_EngineType)
          {
               Dictionary<string, Type> questionsAndTypes = GetVehicleQuestionsAndTypes(i_EngineType);
               //questionsAndTypes.Add("please enter car color(Yellow, White, Black, Blue):", typeof(eCarColor));
               questionsAndTypes.Add(string.Format("please enter car color:\n{0}",EnumStatic.GetInstructionByEnum<eCarColor>()), typeof(eCarColor));
               questionsAndTypes.Add(string.Format("please enter num of doors:\n{0}", EnumStatic.GetInstructionByEnum<eNumDoors>()), typeof(eNumDoors));
               return questionsAndTypes;
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.AddRange(base.GetVehicleDetails());
               details.Add(e_color.ToString());
               details.Add(e_numOfDoors.ToString());
               return details;
          }

     }
}
