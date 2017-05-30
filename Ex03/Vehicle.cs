using System;
using System.Collections.Generic;
using System.Reflection;
namespace Vehicle
{
     using Wheel;
     using Engine;
     using OnElectricity;
     using OnFuel;
     using enumFuelType;

     public abstract class Vehicle
     {
          private string m_modelName;
          private string m_licenceNumber;
          private List<Wheel> m_wheels = new List<Wheel>();
          Engine m_myEngine;

          public Vehicle(string i_Model,string i_LicenceID,string i_WheelCompany, int i_NumWheels, float i_CurrPressure,float i_MaxPressure,
               float i_CurrEnergy,float i_MaxEnergy,string i_FuelType)
          {
               m_licenceNumber = i_LicenceID;
               m_modelName = i_Model;
               for (int i = 0; i < i_NumWheels; i++) 
               {
                    m_wheels.Add(new Wheel(i_WheelCompany, i_CurrPressure, i_MaxPressure));
               }
               if (i_FuelType == "electric")
               {
                    m_myEngine = new OnElectricity(i_CurrEnergy, i_MaxEnergy);
               }
               else
               {
                    eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_FuelType, true);
                    if (Enum.IsDefined(typeof(eFuelType), fuelType))
                    {
                         m_myEngine = new OnFuel(i_CurrEnergy, i_MaxEnergy, i_FuelType);
                    }
               }
          }

          public virtual List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.Add(m_modelName);
               details.Add(m_licenceNumber);
               details.AddRange(m_wheels[0].GetWheelDetails());
               details.AddRange(m_myEngine.GetEngineDetails());
               return details; 
          }

          public string GetLicenceNumber()
          {
               return m_licenceNumber;
          }

          public void PumpWheels(float i_AddPressure)
          {
               foreach (Wheel wheel in m_wheels)
               {
                    wheel.PumpPressure(i_AddPressure);
               }
          }

          public void PumpWheelsToMax()
          {
               foreach (Wheel wheel in m_wheels)
               {
                    wheel.PumpToMax();
               }
          }

     }
}
