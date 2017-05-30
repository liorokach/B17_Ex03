using System;
using System.Collections.Generic;
using System.Text;

namespace Wheel
{
     struct Wheel
     {
          private string m_producerName;
          private float m_currentPressure;
          private float m_maxPressure;


          public Wheel(string i_Producer, float i_CurrPressure, float i_MaxPressure)
          {
               m_producerName = i_Producer;
               m_currentPressure = i_CurrPressure;
               m_maxPressure = i_MaxPressure;
          }

          public void PumpPressure(float i_AddPressure)
          {
               if (i_AddPressure + m_currentPressure <= m_maxPressure)
               {
                    m_currentPressure += i_AddPressure;
               }
               else
               {
                    ///exeption
               }
          }

          public void PumpToMax()
          {
               m_currentPressure = m_maxPressure;
          }

          public List<string> GetWheelDetails()
          {
               List<string> details = new List<string>();
               details.Add(m_producerName);
               details.Add(m_currentPressure.ToString());
               details.Add(m_maxPressure.ToString());
               return details;
          }
     }
}
