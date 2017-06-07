using System;
using System.Collections.Generic;
using System.Text;

namespace Wheel
{
     public class Wheel
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

          public static Dictionary<string, Type> GetWheelQuestionsAndTypes()
          {
               Dictionary<string, Type> questionsAndTypes = new Dictionary<string, Type>();
               questionsAndTypes.Add("please enter wheels producer name:", typeof(string));
               questionsAndTypes.Add("please enter wheels current pressure:", typeof(float));
               questionsAndTypes.Add("please enter wheels maximum pressure:", typeof(float));
               return questionsAndTypes;
          }

          public void PumpPressure(float i_AddPressure)
          {
               if (i_AddPressure + m_currentPressure <= m_maxPressure)
               {
                    m_currentPressure += i_AddPressure;
               }
               else
               {
                    //// exception
               }
          }

          public List<string> GetWheelDetails()
          {
               List<string> details = new List<string>();
               details.Add(string.Format("wheel producer name: {0}", m_producerName));
               details.Add(string.Format("wheel current pressure: {0}", m_currentPressure.ToString()));
               details.Add(string.Format("wheel max pressure: {0}", m_maxPressure.ToString()));
               return details;
          }

          public float CurPressure
          {
               get
               {
                    return m_currentPressure;
               }
          }

          public float MaxPressure
          {
               get
               {
                    return m_maxPressure;
               }
          }
     }
}
