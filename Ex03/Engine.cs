using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
     using eFuelType;
     using ValueOutOfRangeException;
     using eEngineType;

     public abstract class Engine
     {
          protected float m_engineRemainTime;
          protected float m_maxEngineTime;

          public Engine(float i_RemainTime, float i_MaxTime)
          {
               m_engineRemainTime = i_RemainTime;
               m_maxEngineTime = i_MaxTime;
          }

          public virtual List<string> GetEngineDetails()
          {
               List<string> details = new List<string>();
               details.Add(string.Format("remain engine energy: {0}", m_engineRemainTime.ToString()));
               details.Add(string.Format("max engine energy: {0}", m_maxEngineTime.ToString()));
               return details;
          }

          public void Refuel(float i_AddFuelQuantity)
          {
               if (m_engineRemainTime + i_AddFuelQuantity <= m_maxEngineTime)
               {
                    m_engineRemainTime += i_AddFuelQuantity;
               }
               else
               {
                    throw new ValueOutOfRangeException(m_maxEngineTime - m_engineRemainTime, 0, "trying to fill too much!\n");
               }
          }

          public abstract void Refuel(float i_AmountToAdd, eFuelType i_TypeOfFuel);

          public abstract eFuelType FuelType { get; }

          public abstract eEngineType EngineType();
     }
}
