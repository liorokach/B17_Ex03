using System;
using System.Collections.Generic;
using System.Text;

namespace OnElectricity
{
     using eFuelType;
     using Engine;

     public class OnElectricity : Engine
     {
          public OnElectricity(float i_RemainTime, float i_MaxTime) : base(i_RemainTime, i_MaxTime)
          {
          }

          public override List<string> GetEngineDetails()
          {
               List<string> details = new List<string>();
               details.Add("engine type: electric");
               details.AddRange(base.GetEngineDetails());
               return details;
          }

          public override void Refuel(float i_AmountToAdd, eFuelType i_TypeOfFuel)
          {
               throw new NotImplementedException();
          }

          public override eFuelType FuelType
          {
               get
               {
                    throw new NotImplementedException();
               }
          }

          public override eEngineType.eEngineType EngineType()
          {
               return eEngineType.eEngineType.OnElectric;
          }
     }
}
