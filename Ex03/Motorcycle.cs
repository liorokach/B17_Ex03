using System;
using System.Collections.Generic;
using System.Text;

using Engine;

namespace Motorcycle
{
     using eLicenceType;
     using Vehicle;
     using EnumStatic;
     using eNumOfWheels;

     public class Motorcycle : Vehicle
     {
          private eLicenceType e_licence;
          private int m_engineCapacity;

          public Motorcycle(string i_Model, string i_LicenceID, string i_WheelCompany, eNumOfWheels i_NumWheels, float i_CurrPressure, float i_MaxPressure, eLicenceType i_Licence, int i_Capacity, Engine.Engine i_Engine) : base(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure, i_Engine)
          {
               m_engineCapacity = i_Capacity;
               e_licence = i_Licence;
          }

          public static Dictionary<string, Type> GetDictionaryOfQuestionsAndTypes(eEngineType.eEngineType i_EngineType)
          {
               Dictionary<string, Type> questionsAndTypes = GetVehicleQuestionsAndTypes(i_EngineType);
               questionsAndTypes.Add(string.Format("please enter motorcycle licence type:\n{0}", EnumStatic.GetInstructionByEnum<eLicenceType>()), typeof(eLicenceType));
               questionsAndTypes.Add("please enter engine capacity:", typeof(int));
               return questionsAndTypes;
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.AddRange(base.GetVehicleDetails());
               details.Add(string.Format("motorcycle licence type: {0}", e_licence.ToString()));
               details.Add(string.Format("motorcycle engine capacity: {0}", m_engineCapacity.ToString()));
               return details;
          }
     }
}
