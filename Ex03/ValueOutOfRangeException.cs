using System;

namespace ValueOutOfRangeException
{
     public class ValueOutOfRangeException : Exception
     {
          private float m_maxValue;
          private float m_minValue;

          public ValueOutOfRangeException(float i_MaxVal, float i_MinVal)
          {
               m_maxValue = i_MaxVal;
               m_minValue = i_MinVal;
          }

          public ValueOutOfRangeException(string msg) : base(msg)
          {
          }

          public ValueOutOfRangeException(float i_maxVal, string msg) : this(msg)
          {
               m_maxValue = i_maxVal;
          }

          public ValueOutOfRangeException(float i_maxVal, float i_minVal, string msg) : this(i_maxVal, msg)
          {
               m_minValue = i_minVal;
          }

          public float MaxValue
          {
               get
               {
                    return m_maxValue;
               }
          }

          public float MinValue
          {
               get
               {
                    return m_minValue;
               }
          }
     }
}
