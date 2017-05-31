using System;
using System.Collections.Generic;
using System.Text;

namespace OnFuel
{
     using enumFuelType;
     using Engine;
     public class OnFuel : Engine
     {
          eFuelType e_fuelType;

          public override List<string> GetEngineDetails()
          {
               List<string> details = new List<string>();
               details.Add("fuel");
               details.Add(e_fuelType.ToString());
               details.AddRange(base.GetEngineDetails());
               return details;
          }

          public OnFuel(float i_RemainTime, float i_MaxTime, string i_FuelType) : base(i_RemainTime, i_MaxTime)
          {
               try
               {
                    e_fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_FuelType, true);
               }
               catch (Exception NotValidFuel)
               {
                    //// let the user know about the problem
               }
          }

          public override void Refuel(float i_AddFuelQuantity, eFuelType i_fuelType)
          {
               if (i_fuelType == e_fuelType)
               {
                    Refuel(i_AddFuelQuantity);
               }
               else
               {
                    //// throw exception and what was the problem
               }
          }
     }
}
