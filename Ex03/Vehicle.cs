using System;
using System.Collections.Generic;

namespace Vehicle
{
     using Wheel;
     using Engine;
     using eFuelType;
     using eEngineType;
     using EnumStatic;
     using eNumOfWheels;

     public abstract class Vehicle
     {
          private string m_modelName;
          private string m_licenceNumber;
          private List<Wheel> m_wheels = new List<Wheel>();
          private Engine m_myEngine;

          public Vehicle(string i_Model, string i_LicenceID, string i_WheelCompany, eNumOfWheels i_NumWheels, float i_CurrPressure, float i_MaxPressure, Engine i_Engine)
          {
               m_licenceNumber = i_LicenceID;
               m_modelName = i_Model;
               int numWheels = (int)i_NumWheels;
               for (int i = 0; i < numWheels + 1; i++)  
               {
                    m_wheels.Add(new Wheel(i_WheelCompany, i_CurrPressure, i_MaxPressure));
               }

               m_myEngine = i_Engine;
          }

          public static Dictionary<string, Type> GetVehicleQuestionsAndTypes(eEngineType i_EngineType)
          {
               Dictionary<string, Type> questionsAndTypes = Wheel.GetWheelQuestionsAndTypes();
               questionsAndTypes.Add(string.Format("please enter num of wheels:\n{0}", EnumStatic.GetInstructionByEnum<eNumOfWheels>()), typeof(eNumOfWheels));
               questionsAndTypes.Add("please enter model name:", typeof(string));
               questionsAndTypes.Add("please enter Licence ID:", typeof(string));
               questionsAndTypes.Add("please enter current energy:", typeof(float));
               questionsAndTypes.Add("please enter maximum energy:", typeof(float));
               if (i_EngineType == eEngineType.OnFuel)
               {
                    questionsAndTypes.Add(string.Format("please enter fuel type:\n{0}", EnumStatic.GetInstructionByEnum<eFuelType>()), typeof(eFuelType));
               }

               return questionsAndTypes;
          }

          public virtual List<string> GetVehicleDetails()
          {
               List<string> details = new List<string>();
               details.Add(string.Format("model name: {0}", m_modelName));
               details.Add(string.Format("licence ID: {0}", m_licenceNumber));
               details.Add(string.Format("num of wheels: {0}", m_wheels.Count.ToString()));
               details.AddRange(m_wheels[0].GetWheelDetails());
               details.AddRange(m_myEngine.GetEngineDetails());
               return details;
          }

          public string LicenceNumber
          {
               get
               {
                    return m_licenceNumber;
               }
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
                    wheel.PumpPressure(wheel.MaxPressure - wheel.CurPressure);
               }
          }

          public void AddFuel(eFuelType i_TypeOfFuel, float i_AmountToAdd)
          {
               m_myEngine.Refuel(i_AmountToAdd, i_TypeOfFuel);
          }

          public void ChargeBattery(float i_AmountToAdd)
          {
               m_myEngine.Refuel(i_AmountToAdd);
          }

          public eFuelType GetFuelType()
          {
               return m_myEngine.FuelType;
          }

          public eEngineType EngineType
          {
               get
               {
                    return m_myEngine.EngineType();
               }
          }
     }
}
