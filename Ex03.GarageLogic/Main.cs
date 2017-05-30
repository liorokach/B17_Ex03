using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03
{
     using Car;
     using Garage;
     using Truck;
     class Ex03
     {
          
          public static void Main()
          {
               Car car = new Car("nissan", "1", (float)5.5, "rick", 4, (float)30.3, 32, 10, 34, "electric", "yellow", 4);
               Truck truck = new Truck("nissan", "2", "rick",6, 4, (float)30.3, 30, 30,"octan96",true,11);
               Garage garage = new Garage();
               garage.AddVehicleToGarage(car, "lior", "05222");
               garage.AddVehicleToGarage(truck, "aa", "05222");
               garage.GetVehicleDetails("1");
               garage.ChangeStatus(car.GetLicenceNumber(), enumVehicleStatus.eVehicleStatus.Repaired);
          }
     }
}
