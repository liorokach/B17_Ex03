using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
     using enumFuelType;

     public abstract class Engine
     {
          protected float m_engineRemainTime;
          protected float m_maxEngineTime;

          public Engine(float i_RemainTime, float i_MaxTime)
          {
               m_engineRemainTime = i_RemainTime;
               m_maxEngineTime = i_MaxTime;
          }

          public abstract void Refuel(float i_AddFuelQuantity, eFuelType i_fuelType);

          public void Refuel(float i_AddFuelQuantity) //// for electronic car
          {
               if (m_engineRemainTime + i_AddFuelQuantity <= m_maxEngineTime)
               {
                    m_engineRemainTime += i_AddFuelQuantity;
               }
          }
     }
}
