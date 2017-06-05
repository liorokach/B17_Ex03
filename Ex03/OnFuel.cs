using System;
using System.Collections.Generic;
using System.Text;
using eFuelType;
namespace OnFuel
{
     using eFuelType;
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

        public OnFuel(float i_RemainTime, float i_MaxTime, eFuelType i_FuelType) : base(i_RemainTime, i_MaxTime)
        {
            {
                e_fuelType = i_FuelType;
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
