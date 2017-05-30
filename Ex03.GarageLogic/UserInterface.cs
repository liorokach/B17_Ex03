using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
     using Garage;
     using Vehicle;
     using Truck;
     using Motorcycle;
     using Car;
     class UserInterface
     {
          private Garage m_garage;
          
          public void GetFromUserCarDetails()
          {
               Vehicle newVehicle;
               try
               {
                    Console.WriteLine("please enter licence ID:");
                    string licenceID = Console.ReadLine();
                    Console.WriteLine("please enter model name:");
                    string modelName = Console.ReadLine();
                    Console.WriteLine("please enter energy Percent Left:");
                    float energyPercentLeft = float.Parse(Console.ReadLine());
                    Console.WriteLine("please enter wheel producer name:");
                    string wheelProducer = Console.ReadLine();
                    Console.WriteLine("please enter number of wheels(between 2-5):");
                    int numWheels = int.Parse(Console.ReadLine());
                    Console.WriteLine("please enter current pressure:");
                    float currentPressure = float.Parse(Console.ReadLine());
                    Console.WriteLine("please enter maximum pressure:");
                    float maxPressure = float.Parse(Console.ReadLine());
                    Console.WriteLine("please enter current energy:");
                    float currentEnergy = float.Parse(Console.ReadLine());
                    Console.WriteLine("please enter maximum energy:");
                    float maxEnergy = float.Parse(Console.ReadLine());
                    Console.WriteLine("is it a car , a motorcycle or a truck:");
                    string vehicleType = Console.ReadLine();

                    if (vehicleType == "car" || vehicleType == "motorcycle")
                    {
                         Console.WriteLine("is electric or fuel type(octan95,octan96,octan98,soler):");
                         string energyType = Console.ReadLine();
                    }
                    else if (vehicleType != "truck")
                    {
                         ///throw execption
                    }
                    else
                    {
                         Console.WriteLine("enter fuel type(octan95,octan96,octan98,soler):");
                         string fuelType = Console.ReadLine();
                         Console.WriteLine("has dangerous substance?(true or false)");
                         bool isDanger = bool.Parse(Console.ReadLine());
                         Console.WriteLine("enter maximum carry weight?");
                         float weight = float.Parse(Console.ReadLine());
                         newVehicle = new Truck(modelName, licenceID, wheelProducer, numWheels, currentPressure, maxPressure, currentEnergy, maxEnergy,
                               fuelType, isDanger, weight);
                         m_garage.AddVehicleToGarage(newVehicle, "lior", "052");
                    }
                    
               }
               catch(Exception ex)
               {
                    Console.WriteLine(ex.ToString());
               }
               
          } 
     }
}
