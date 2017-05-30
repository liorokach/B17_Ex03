using System;
using System.Collections.Generic;
using System.Text;

namespace Truck
{
     using Vehicle;
     public class Truck : Vehicle //// only on fuel
     {
          private bool m_hasDangerSubstance;
          private float m_maxCarryWeight;

          public Truck(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure, float i_MaxPressure,
               float i_CurrEnergy, float i_MaxEnergy, string i_fuelType, bool i_Dangerous, float i_MaxWeight) :
               base(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure, i_CurrEnergy, i_MaxEnergy, i_fuelType)
          {
               m_hasDangerSubstance = i_Dangerous;
               m_maxCarryWeight = i_MaxWeight;
          }
     }
}
