using System;
using System.Collections.Generic;

namespace UserInterface
{

     using Garage;
     using Vehicle;
     using Truck;
     using Motorcycle;
     using Car;
     using eMenuChoise;
     using eNumOfWheels;
     using ValueOutOfRangeException;
     using eVehicleStatus;
     using eFuelType;
     using eVehicleType;
     using VehicleFactory;
     using eEngineType;
     using eCarColor;
     using eLicenceType;
     using eNumDoors;

     public class UserInterface
     {
          private Garage m_garage;

          public UserInterface()
          {
               m_garage = new Garage();
          }



          //Vehicel
          public void GetFromUserVehicleDetails()
          {
               Vehicle newVehicle;
               eVehicleType vehicleType;

               Dictionary<string, Type> questionAndType = new Dictionary<string, Type>();

               Console.WriteLine("Enter vehicle type");
               PrintInstructionByEnum<eVehicleType>();
               vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), Console.ReadLine());
               eEngineType engineType = eEngineType.OnFuel;
               switch (vehicleType)
               {
                    case eVehicleType.Car:
                         questionAndType = Car.GetDictionaryOfQuestionsAndTypes(engineType);
                         //questionAndType.Add("licence Id", typeof(eNumOfWheels));
                         //questionAndType = Car.GetDictionaryOfQuestionsAndTypes();
                         //newVehicle = VehicleFactory.CreateNewCar(BuildArrPairsAndCheckParse(questionAndType));
                         break;
                    case eVehicleType.Motorcycle:
                         questionAndType = Motorcycle.GetDictionaryOfQuestionsAndTypes(engineType);
                         //newVehicle = VehicleFactory.CreateNewMotorcycle(BuildArrPairsAndCheckParse(questionAndType));
                         break;
                    case eVehicleType.Truck:
                         questionAndType = Truck.GetDictionaryOfQuestionsAndTypes(engineType);
                         //newVehicle = VehicleFactory.CreateNewTruck(BuildArrPairsAndCheckParse(questionAndType));
                         break;
                    default:
                         Console.WriteLine("Invalid input , please try again");
                         //return GetFromUserVehicleDetails();
                         break;
               }

               // return newVehicle;
          }


          public List<KeyValuePair<string, Type>> BuildArrPairsAndCheckParse(Dictionary<string, Type> i_questionAndType)
          {
               List<KeyValuePair<string, Type>> pairsStrType = new List<KeyValuePair<string, Type>>();
               foreach (var item in i_questionAndType)
               {
                    object value;
                    Console.WriteLine(item.Key); // print the instruction/question
                    value = CheckParse(Console.ReadLine(), item.Value);
                    KeyValuePair<string, Type> newPair = new KeyValuePair<string, Type>(item.Key, item.Value);
                    pairsStrType.Add(newPair);
               }
               return pairsStrType;
          }

          public object CheckParse(string i_StrToCheck, Type i_TypeToCheck)
          {
               object returnValue = i_StrToCheck;
               float fReturnValue;
               int intReturnValue;
               Enum e; ;
               try
               {
                    if (i_TypeToCheck == typeof(eNumOfWheels))
                    {
                         e = CheckValidityByEnumType<eNumOfWheels>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(eFuelType))
                    {
                         e = CheckValidityByEnumType<eFuelType>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(eCarColor))
                    {
                         e = CheckValidityByEnumType<eCarColor>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(eEngineType))
                    {
                         e = CheckValidityByEnumType<eEngineType>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(eLicenceType))
                    {
                         e = CheckValidityByEnumType<eLicenceType>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(eNumDoors))
                    {
                         e = CheckValidityByEnumType<eNumDoors>(i_StrToCheck);
                         returnValue = e;
                    }
                    else if (i_TypeToCheck == typeof(float))
                    {
                         float.TryParse(i_StrToCheck, out fReturnValue);
                         returnValue = fReturnValue;
                    }
                    else if (i_TypeToCheck == typeof(int))
                    {
                         int.TryParse(i_StrToCheck, out intReturnValue);
                         returnValue = intReturnValue;
                    }
                    return returnValue;
               }
               catch
               {
                    throw new FormatException();
               }
          }


          public void GetFromUserVehicleDetailsAndInsertGarage()
          {
               eVehicleType vehicleType;
               eFuelType fuelType;
               Vehicle newVehicle;
               eNumOfWheels numWheels;
               eEngineType engineType;
               float maxPressure, currentPressure, maxEnergy;
               Console.WriteLine("Please enter licence ID:");
               string licenceID = Console.ReadLine();
               Console.WriteLine("Please enter model name:");
               string modelName = Console.ReadLine();
               Console.WriteLine("Please enter energy Percent Left:");
               float energyPercentLeft = float.Parse(Console.ReadLine());
               Console.WriteLine("Please enter wheel producer name:");
               string wheelProducer = Console.ReadLine();
               Console.WriteLine("Please enter number of wheels(between 2-5):");
               PrintInstructionByEnum<eNumOfWheels>();
               numWheels = CheckValidityByEnumType<eNumOfWheels>(Console.ReadLine());
               Console.WriteLine("please enter maximum pressure:");
               float.TryParse(Console.ReadLine(), out maxPressure);
               Console.WriteLine("Please enter current pressure:");
               ValidateCurrPressure(Console.ReadLine(), out currentPressure, maxPressure);
               Console.WriteLine("Please enter maximum energy:");
               float.TryParse(Console.ReadLine(), out maxEnergy);
               Console.WriteLine("please enter current energy:");
               float currentEnergy = float.Parse(Console.ReadLine());
               PrintInstructionByEnum<eFuelType>();
               ValidateEfuelType(Console.ReadLine(), out fuelType);
               Console.WriteLine("Please enter engine type");
               PrintInstructionByEnum<eEngineType>();
               ValidateEfuelType(Console.ReadLine(), out engineType);


               Console.WriteLine("Enter vehicle type");
               PrintInstructionByEnum<eVehicleType>();
               vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), Console.ReadLine());
               switch (vehicleType)
               {
                    case eVehicleType.Car:
                         //GetCarDetails();
                         break;
                    case eVehicleType.Motorcycle:
                         break;
                    case eVehicleType.Truck:
                         break;
                    default:
                         Console.WriteLine("Invalid insturction , please try again");
                         GetFromUserVehicleDetailsAndInsertGarage();
                         break;
               }
          }


          //public void GetFromUserVehicleDetailsAndInsertGarage()
          //{
          //    try
          //    {
          //        Vehicle newVehicle;
          //        float maxPressure, currentPressure, maxEnergy;
          //        Console.WriteLine("Please enter licence ID:");
          //        string licenceID = Console.ReadLine();

          //        Console.WriteLine("Please enter model name:");
          //        string modelName = Console.ReadLine();

          //        Console.WriteLine("Please enter energy Percent Left:");
          //        float energyPercentLeft = float.Parse(Console.ReadLine());

          //        Console.WriteLine("Please enter wheel producer name:");
          //        string wheelProducer = Console.ReadLine();

          //        Console.WriteLine("Please enter number of wheels(between 2-5):");
          //        eNumOfWheels numWheels;
          //        ValidateNumOfWheels(Console.ReadLine(), out numWheels);

          //        Console.WriteLine("please enter maximum pressure:");
          //        float.TryParse(Console.ReadLine(), out maxPressure);

          //        Console.WriteLine("Please enter current pressure:");
          //        ValidateCurrPressure(Console.ReadLine(), out currentPressure, maxPressure);

          //        Console.WriteLine("Please enter maximum energy:");
          //        float.TryParse(Console.ReadLine(), out maxEnergy);


          //        Console.WriteLine("please enter current energy:");
          //        float currentEnergy = float.Parse(Console.ReadLine());

          //        ////-----
          //        Console.WriteLine("is it a car , a motorcycle or a truck:");
          //        string vehicleType = Console.ReadLine();

          //        if (vehicleType == "car" || vehicleType == "motorcycle")
          //        {
          //            Console.WriteLine("is electric or fuel type(octan95,octan96,octan98,soler):");
          //            string energyType = Console.ReadLine();
          //        }
          //        Console.WriteLine("enter fuel type(octan95,octan96,octan98,soler):");
          //        string fuelType = Console.ReadLine();
          //        Console.WriteLine("has dangerous substance?(true or false)");
          //        bool isDanger = bool.Parse(Console.ReadLine());
          //        Console.WriteLine("enter maximum carry weight?");
          //        float weight = float.Parse(Console.ReadLine());
          //        newVehicle = new Truck(modelName, licenceID, wheelProducer, (int)numWheels, currentPressure, maxPressure, currentEnergy, maxEnergy,
          //              fuelType, isDanger, weight);
          //        Console.WriteLine("Please enter owner name");
          //        string ownerName = Console.ReadLine();
          //        Console.WriteLine("Please enter phone number");
          //        string phoneNumber = Console.ReadLine();
          //        m_garage.AddVehicleToGarage(newVehicle, ownerName, phoneNumber);
          //    }
          //    catch
          //    { 
          //    }
          //}

          public void MenuManager()
          {
               Vehicle vehicleNew;
               eMenuChoise menuChoise = Menu();
               string licenceNumStr;
               try
               {
                    switch (menuChoise)
                    {
                         case eMenuChoise.EnterNewVehicle:
                              //vehicleNew = GetFromUserVehicleDetailsAndInsertGarage();
                              //GetFromUserVehicleDetailsAndInsertGarage();
                              GetFromUserVehicleDetails();
                              break;
                         case eMenuChoise.ShowLicenceList:
                              ShowLicenceListByStatus();
                              break;
                         case eMenuChoise.ChangeVehicleStatus:
                              ChangeVehicleStatusById();
                              break;
                         case eMenuChoise.PumpPressureToMax:
                              licenceNumStr = Console.ReadLine();
                              Int32.Parse(licenceNumStr);                  //if fail throw format exception
                              m_garage.PumpWheelsToMax(licenceNumStr);
                              break;
                         case eMenuChoise.Refuel:
                              Refuel();
                              break;
                         case eMenuChoise.Recharge:
                              Recharge();
                              break;
                         case eMenuChoise.ShowFullVehicleDetails:
                              ShowAllVehicleDetails();
                              break;
                         case eMenuChoise.Exit:
                              Console.WriteLine("Good Bye!");
                              break;
                         default:
                              Console.WriteLine("Invalid insturction , please try again");
                              MenuManager();
                              break;
                    }
               }
               catch
               {
                    Console.WriteLine("Invalid insturction , please try again");
                    MenuManager();
               }
          }

          public static eMenuChoise Menu()
          {
               eMenuChoise menuChoise;
               PrintInstructionByEnum<eMenuChoise>();
               menuChoise = (eMenuChoise)Enum.Parse(typeof(eMenuChoise), Console.ReadLine());
               return menuChoise;
          }

          public void ShowAllVehicleDetails()
          {
               List<string> details;
               string licenceNumStr;
               try
               {
                    Console.WriteLine("enter licence number");
                    licenceNumStr = Console.ReadLine();
                    Int32.Parse(licenceNumStr);
                    details = m_garage.GetVehicleDetails(licenceNumStr);
                    foreach (var detail in details)
                    {
                         Console.WriteLine(detail);
                    }
               }
               catch (FormatException)
               {
                    Console.WriteLine("Invalid insturction , please try again");
                    ShowAllVehicleDetails();
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    MenuManager();
               }
          }

          public void Recharge()
          {
               string licenceNumStr;
               float addAmount;
               try
               {
                    Console.WriteLine("Enter licence number");
                    licenceNumStr = Console.ReadLine();
                    Int32.Parse(licenceNumStr);
                    Console.WriteLine("Enter amount");
                    if (!float.TryParse(Console.ReadLine(), out addAmount))  // casting did not succeded
                    {
                         throw new FormatException();
                    }

                    m_garage.ReCharge(licenceNumStr, addAmount);
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    MenuManager();
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    Recharge();
               }
          }

          public void Refuel()
          {
               string licenceNumStr;
               eFuelType eFType;
               float addAmount;
               try
               {
                    Console.WriteLine("Enter licence number");
                    licenceNumStr = Console.ReadLine();
                    Int32.Parse(licenceNumStr);
                    Console.WriteLine("Enter amount");
                    if (!float.TryParse(Console.ReadLine(), out addAmount))  // casting did not succeded
                    {
                         throw new FormatException();
                    }
                    Console.WriteLine("Enter fuel type");
                    PrintInstructionByEnum<eFuelType>();
                    eFType = (eFuelType)Enum.Parse(typeof(eFuelType), Console.ReadLine());
                    if (!eFuelType.IsDefined(typeof(eFuelType), eFType))
                    {
                         throw new FormatException();
                    }
                    m_garage.ReFuel(licenceNumStr, eFType, addAmount);
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    MenuManager();
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    Refuel();
               }
          }

          public void ShowLicenceListByStatus()
          {
               List<string> licenceList = new List<string>();

               Console.WriteLine(" Show List by status: InRepair, Repaired, Paid, all");
               PrintInstructionByEnum<eVehicleStatus>();

               eVehicleStatus vehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), Console.ReadLine());
               switch (vehicleStatus)
               {
                    case eVehicleStatus.InRepair:
                         licenceList = m_garage.GetLicenceNumberByStatus(eVehicleStatus.InRepair);
                         break;
                    case eVehicleStatus.Repaired:
                         licenceList = m_garage.GetLicenceNumberByStatus(eVehicleStatus.Repaired);
                         break;
                    case eVehicleStatus.Paid:
                         licenceList = m_garage.GetLicenceNumberByStatus(eVehicleStatus.Paid);
                         break;
                    case eVehicleStatus.All:
                         licenceList = m_garage.GetLicenceNumberByStatus(eVehicleStatus.All);
                         break;
                    default:
                         Console.WriteLine("Invalid insturction , please try again");
                         ShowLicenceListByStatus();
                         break;
               }
               /////-------------    check if working 
               foreach (var licenceNumber in licenceList)
               {
                    Console.WriteLine(licenceNumber.ToString());
               }
          }//// to check

          public static string createStringFromEnumStr(string enumStr)
          {
               string newStr = string.Empty;
               newStr += enumStr[0];
               for (int i = 1; i < enumStr.Length; i++)
               {
                    if (enumStr[i] > 'A' && enumStr[i] < 'Z')
                    {
                         newStr += " " + enumStr[i];
                    }
                    else
                    {
                         newStr += enumStr[i];
                    }
               }
               return newStr;
          }

          public static void PrintInstructionByEnum<Tenum>()
          {
               int indexItem = 0;
               Type enumType = typeof(Tenum);
               string[] eNumNames = Enum.GetNames(enumType);
               foreach (var eName in eNumNames)
               {
                    Console.WriteLine("{0}. {1}", indexItem + 1, createStringFromEnumStr(eNumNames[indexItem]));
                    indexItem++;
               }
          }

          public static Tenum CheckValidityByEnumType<Tenum>(string i_Input)
          {
               Tenum enumT;
               //Type enumType = typeof(Tenum);
               enumT = (Tenum)Enum.Parse(typeof(Tenum), i_Input);
               if (!Enum.IsDefined(typeof(Tenum), enumT))
               {
                    throw new ArgumentException();
               }
               return enumT;
          }

          public void ChangeVehicleStatusById()
          {
               string id;
               int idInt;
               eVehicleStatus vehicleStatus;
               try
               {
                    id = Console.ReadLine();
                    if (int.TryParse(id, out idInt)) // casting suceeded
                    {
                         vehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), Console.ReadLine());
                         if (!eVehicleStatus.IsDefined(typeof(eVehicleStatus), vehicleStatus))
                         {
                              throw new FormatException();
                         }
                    }
                    else throw new FormatException();
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    MenuManager();
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ChangeVehicleStatusById();

               }
          }


          //---------------------
          public void ValidateCurrPressure(string i_CurrPressureStr, out float i_CurrentPressure, float o_MaxPressure)
          {
               i_CurrentPressure = 0;
               try
               {

                    if (!float.TryParse(i_CurrPressureStr, out i_CurrentPressure))   // casting not succeded
                    {
                         throw new FormatException();
                    }
                    else                                                             //casting succeded
                    {
                         if (o_MaxPressure < i_CurrentPressure)
                         {
                              throw new ValueOutOfRangeException();
                         }
                    }
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ValidateCurrPressure(Console.ReadLine(), out i_CurrentPressure, o_MaxPressure);
               }
          }

          public void ValidateNumOfWheels(string i_numWheelsStr, out eNumOfWheels o_numWheels)
          {
               try
               {
                    o_numWheels = (eNumOfWheels)Enum.Parse(typeof(eNumOfWheels), i_numWheelsStr);
                    if (!eNumOfWheels.IsDefined(typeof(eNumOfWheels), o_numWheels))
                    {
                         throw new ArgumentException();
                    }
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ValidateNumOfWheels(Console.ReadLine(), out o_numWheels);
               }
          }

          public void ValidateEfuelType(string i_fuelTypeStr, out eFuelType o_FuelType)
          {
               try
               {
                    o_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_fuelTypeStr);
                    if (!eFuelType.IsDefined(typeof(eFuelType), o_FuelType))
                    {
                         throw new ArgumentException();
                    }

               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ValidateEfuelType(Console.ReadLine(), out o_FuelType);
               }
          }

          public void ValidateEfuelType(string i_EngineTypeStr, out eEngineType o_EngineType)
          {
               try
               {
                    o_EngineType = (eEngineType)Enum.Parse(typeof(eEngineType), i_EngineTypeStr);
                    if (!eEngineType.IsDefined(typeof(eEngineType), o_EngineType))
                    {
                         throw new ArgumentException();
                    }
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ValidateEfuelType(Console.ReadLine(), out o_EngineType);
               }
          }

     }
}
