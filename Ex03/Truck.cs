using System;
using System.Collections.Generic;

namespace Truck
{
     using Vehicle;
     using eEngineType;
     using eNumOfWheels;
     using Engine;

     public class Truck : Vehicle 
     {
          private bool m_hasDangerSubstance;
          private float m_maxCarryWeight;

          public Truck(string i_Model, string i_LicenceID, string i_WheelCompany, eNumOfWheels i_NumWheels, float i_CurrPressure, float i_MaxPressure, bool i_Dangerous, float i_MaxWeight, Engine i_Engine) 
               : base(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure, i_Engine)
          {
               m_hasDangerSubstance = i_Dangerous;
               m_maxCarryWeight = i_MaxWeight;
          }

          public static Dictionary<string, Type> GetDictionaryOfQuestionsAndTypes(eEngineType i_EngineType)
          {
               Dictionary<string, Type> questionsAndTypes = GetVehicleQuestionsAndTypes(i_EngineType);
               questionsAndTypes.Add("is the truck has dangerous substance?<True,False>", typeof(bool));
               questionsAndTypes.Add("please enter maximum carry weight of your truck:", typeof(float));
               return questionsAndTypes;
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.AddRange(base.GetVehicleDetails());
               details.Add(string.Format("truck has dangerous substance: {0}", m_hasDangerSubstance.ToString()));
               details.Add(string.Format("max carry weight: {0}", m_maxCarryWeight.ToString()));
               return details;
          }
     }
}
