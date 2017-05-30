using System;
using System.Collections.Generic;
using System.Text;

namespace OnElectricity
{
     using Engine;
     using enumFuelType;

     public class OnElectricity : Engine
     {
          public OnElectricity(float i_RemainTime, float i_MaxTime) : base(i_RemainTime, i_MaxTime) { }

          public override void Refuel(float i_AddFuelQuantity, eFuelType i_fuelType)
          {
               throw new NotImplementedException();
          }

          public override List<string> GetEngineDetails()
          {
               List<string> details = new List<string>();
               details.Add("electric");
               details.AddRange(base.GetEngineDetails());
               return details;
          }
     }
}
