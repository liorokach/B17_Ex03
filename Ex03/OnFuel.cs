using System;
using System.Collections.Generic;

namespace OnFuel
{
     using eFuelType;
     using Engine;

     public class OnFuel : Engine
     {
          private eFuelType e_fuelType;

          public override List<string> GetEngineDetails()
          {
               List<string> details = new List<string>();
               details.Add("engine type: fuel");
               details.Add(string.Format("fuel type: {0}", e_fuelType.ToString()));
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
                    throw new ArgumentException();
               }
          }

          public override eFuelType FuelType
          {
               get
               {
                    return e_fuelType;
               }
          }

          public override eEngineType.eEngineType EngineType()
          {
               return eEngineType.eEngineType.OnFuel;
          }
     }
}
