using System;
using System.Collections.Generic;
using System.Text;

namespace Motorcycle
{
     using enumLicenceType;
     using Vehicle;
     public class Motorcycle : Vehicle
     {
          private eLicenceType e_licence;
          private int m_engineCapacity;

          public Motorcycle(string i_Model, string i_LicenceID, string i_WheelCompany, int i_NumWheels, float i_CurrPressure, 
               float i_MaxPressure, float i_CurrEnergy, float i_MaxEnergy, string i_FuelType, string i_Licence, int i_Capacity) : base(i_Model, i_LicenceID, i_WheelCompany, i_NumWheels, i_CurrPressure, i_MaxPressure, i_CurrEnergy, i_MaxEnergy, i_FuelType)
          {
               m_engineCapacity = i_Capacity;
               e_licence = (eLicenceType)Enum.Parse(typeof(eLicenceType), i_Licence);
          }

          public override List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.Add(e_licence.ToString());
               details.Add(m_engineCapacity.ToString());
               details.AddRange(base.GetVehicleDetails());
               return details;
          }
     }
}
