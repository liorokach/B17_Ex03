using System;
using System.Collections.Generic;

using Engine;

namespace Truck
{
     using Vehicle;
     public class Truck : Vehicle //// only on fuel
     {
        
          private bool m_hasDangerSubstance;
          private float m_maxCarryWeight;

          public Truck(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure, float i_MaxPressure,
               bool i_Dangerous, float i_MaxWeight,Engine.Engine i_Engine) :
               base(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure, i_Engine)
          {
               m_hasDangerSubstance = i_Dangerous;
               m_maxCarryWeight = i_MaxWeight;
          }

          public static Dictionary<string, Type> GetDictionaryOfQuestionsAndTypes(eEngineType.eEngineType i_EngineType)
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
               details.Add(m_hasDangerSubstance.ToString());
               details.Add(m_maxCarryWeight.ToString());
               return details;
          }
     }
}
