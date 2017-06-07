using System;
using System.Collections.Generic;

namespace UserInterface
{
     using Ex02.ConsoleUtils;
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
     using EnumStatic;

     public class UserInterface
     {
          private Garage m_garage;

          public UserInterface()
          {
               m_garage = new Garage();
          }

          public static eMenuChoise Menu()
          {
               eMenuChoise menuChoise;
               PrintInstructionByEnum<eMenuChoise>();
               menuChoise = (eMenuChoise)Enum.Parse(typeof(eMenuChoise), Console.ReadLine());
               return menuChoise;
          }

          public static void PrintInstructionByEnum<Tenum>()
          {
               int indexItem = 0;
               Type enumType = typeof(Tenum);
               string[] eNumNames = Enum.GetNames(enumType);
               foreach (var eName in eNumNames)
               {
                    Console.WriteLine("{0}. {1}", indexItem + 1, EnumStatic.CreateStringFromEnumStr(eNumNames[indexItem]));
                    indexItem++;
               }
          }

          public static Tenum CheckValidityByEnumType<Tenum>(string i_Input)
          {
               Tenum enumT;
               enumT = (Tenum)Enum.Parse(typeof(Tenum), i_Input);
               if (!Enum.IsDefined(typeof(Tenum), enumT))
               {
                    throw new ArgumentException();
               }

               return enumT;
          }

          public Vehicle GetFromUserVehicleDetails()
          {
               Vehicle newVehicle;
               eVehicleType vehicleType;
               eEngineType engineType;
               Dictionary<string, Type> questionAndType = new Dictionary<string, Type>();
               Console.WriteLine("Enter vehicle type");
               PrintInstructionByEnum<eVehicleType>();
               try
               {
                    vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), Console.ReadLine());
                    switch (vehicleType)
                    {
                         case eVehicleType.Car:
                              Console.WriteLine("Enter engine type");
                              PrintInstructionByEnum<eEngineType>();
                              engineType = (eEngineType)Enum.Parse(typeof(eEngineType), Console.ReadLine());
                              questionAndType = Car.GetDictionaryOfQuestionsAndTypes(engineType);
                              newVehicle = VehicleFactory.CreateNewCar(BuildListValuesAndCheckParse(questionAndType), engineType);
                              break;
                         case eVehicleType.Motorcycle:
                              Console.WriteLine("Enter engine type");
                              PrintInstructionByEnum<eEngineType>();
                              engineType = (eEngineType)Enum.Parse(typeof(eEngineType), Console.ReadLine());
                              questionAndType = Motorcycle.GetDictionaryOfQuestionsAndTypes(engineType);
                              newVehicle = VehicleFactory.CreateNewMotorcycle(BuildListValuesAndCheckParse(questionAndType), engineType);
                              break;
                         case eVehicleType.Truck:
                              questionAndType = Truck.GetDictionaryOfQuestionsAndTypes(eEngineType.OnFuel);
                              newVehicle = VehicleFactory.CreateNewTruck(BuildListValuesAndCheckParse(questionAndType), eEngineType.OnFuel);
                              break;
                         default:
                              Console.WriteLine("Invalid input , please try again");
                              newVehicle = GetFromUserVehicleDetails();
                              break;
                    }
               }
               catch
               {
                    Console.WriteLine("Invalid format , please try again");
                    newVehicle = GetFromUserVehicleDetails();
               }

               return newVehicle;  
          }

          public List<object> BuildListValuesAndCheckParse(Dictionary<string, Type> i_questionAndType)
          {
               List<object> listValues = new List<object>();
               foreach (var item in i_questionAndType)
               {
                    object value;
                    Console.WriteLine(item.Key); // print the instruction/question
                    value = CheckParse(Console.ReadLine(), item.Value);
                    listValues.Add(value);
               }

               return listValues;
          }

          public void GarageManager()
          {
               eMenuChoise menuChoise;
               do
               {
                    menuChoise = MenuManager();
               }
               while (menuChoise != eMenuChoise.Exit);
          }

          public eMenuChoise MenuManager()
          {
               Console.WriteLine("Menu:");
               Vehicle vehicleNew;
               eMenuChoise menuChoise = Menu();
               string licenceNumStr;
               string ownerName;
               bool carExist = false;
               string phoneNumber;
               try
               {
                    switch (menuChoise)
                    {
                         case eMenuChoise.EnterNewVehicle:
                              vehicleNew = GetFromUserVehicleDetails();
                              Console.WriteLine("Please insert owner name");
                              ownerName = Console.ReadLine();
                              Console.WriteLine("Please insert phone number");
                              phoneNumber = Console.ReadLine();
                              carExist = m_garage.AddVehicleToGarage(vehicleNew, ownerName, phoneNumber);
                              break;
                         case eMenuChoise.ShowLicenceList:
                              ShowLicenceListByStatus();
                              break;
                         case eMenuChoise.ChangeVehicleStatus:
                              ChangeVehicleStatusById();
                              break;
                         case eMenuChoise.PumpPressureToMax:
                              Console.WriteLine("Please enter licence ID");
                              licenceNumStr = Console.ReadLine();
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
                              menuChoise = MenuManager();
                              break;
                    }

                    if (carExist)
                    {
                         Console.WriteLine("vehicle already existed in garage data base, status changed to InRepair");
                    }
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    menuChoise = MenuManager();
               }
               catch (FormatException)
               {
                    Console.WriteLine("Incorrect format!");
                    menuChoise = MenuManager();
               }

               return menuChoise;
          }

          public void ShowAllVehicleDetails()
          {
               List<string> details;
               string licenceNumStr;
               try
               {
                    Console.WriteLine("enter licence ID");
                    licenceNumStr = Console.ReadLine();
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
               }
          }

          public void Recharge()
          {
               string licenceNumStr;
               float addAmount;
               try
               {
                    Console.WriteLine("Enter licence ID");
                    licenceNumStr = Console.ReadLine();
                    Console.WriteLine("Enter amount");
                    if (!float.TryParse(Console.ReadLine(), out addAmount))
                    {
                         throw new FormatException();
                    }

                    if (m_garage.GetEngineType(licenceNumStr) == eEngineType.OnElectric)
                    {
                         m_garage.ReCharge(licenceNumStr, addAmount);
                    }
                    else
                    {
                         throw new NotImplementedException();
                    }
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    GarageManager();
               }
               catch (NotImplementedException)
               {
                    Console.WriteLine("vehicle on fuel cant be recharged");
                    GarageManager();
               }
               catch (ValueOutOfRangeException range)
               {
                    Console.WriteLine("{2}range amount between:{0} and {1}\n", range.MinValue, range.MaxValue, range.Message); //// invalid amount! insert amount between:
                    Recharge();
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
                    Console.WriteLine("Enter licence ID");
                    licenceNumStr = Console.ReadLine();
                    Console.WriteLine("Enter amount");
                    if (!float.TryParse(Console.ReadLine(), out addAmount))
                    {
                         throw new FormatException();
                    }

                    Console.WriteLine("Enter fuel type");
                    PrintInstructionByEnum<eFuelType>();
                    eFType = (eFuelType)Enum.Parse(typeof(eFuelType), Console.ReadLine());
                    if (m_garage.GetEngineType(licenceNumStr) != eEngineType.OnFuel)
                    {
                         throw new NotImplementedException();
                    }

                    if (eFType == m_garage.GetFuelType(licenceNumStr))
                    {
                         m_garage.ReFuel(licenceNumStr, eFType, addAmount);
                    }
                    else
                    {
                         throw new ArgumentException();
                    }
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    GarageManager();
               }
               catch (ValueOutOfRangeException range)
               {
                    Console.WriteLine("{2}range amount between:{0} and {1}\n", range.MinValue, range.MaxValue, range.Message); //// invalid amount! insert amount between:
                    Refuel();
               }
               catch (NotImplementedException)
               {
                    Console.WriteLine("vehicle on electricity cant be refuel");
                    GarageManager();
               }
               catch (ArgumentException)
               {
                    Console.WriteLine("Invalid fuel type!");
                    Refuel();
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    GarageManager();
               }
          }

          public void ShowLicenceListByStatus()
          {
               List<string> licenceList = new List<string>();

               Console.WriteLine(" Show List by status: InRepair, Repaired, Paid, all");
               PrintInstructionByEnum<eVehicleStatus>();
               try
               {
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

                    foreach (var licenceNumber in licenceList)
                    {
                         Console.WriteLine(licenceNumber);
                    }
               }
               catch
               {
                    throw new FormatException();
               }
          }

          public void ChangeVehicleStatusById()
          {
               string id;
               eVehicleStatus vehicleStatus;
               try
               {
                    Console.WriteLine("please enter licence ID:");
                    id = Console.ReadLine();
                    Console.WriteLine(string.Format("please enter new status:\n1.{0}\n2.{1}\n3.{2}\n", eVehicleStatus.InRepair, eVehicleStatus.Repaired, eVehicleStatus.Paid));
                    vehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), Console.ReadLine());
                    if (!Enum.IsDefined(typeof(eVehicleStatus), vehicleStatus) || vehicleStatus == eVehicleStatus.All)
                    {
                         throw new FormatException();
                    }
                    else
                    {
                         m_garage.ChangeStatus(id, vehicleStatus);
                    }
               }
               catch (KeyNotFoundException)
               {
                    Console.WriteLine("Key did not found");
                    //// GarageManager();
               }
               catch
               {
                    Console.WriteLine("Invalid instruction, please try again");
                    ChangeVehicleStatusById();
               }
          }

          public object CheckParse(string i_StrToCheck, Type i_TypeToCheck)
          {
               object returnValue = i_StrToCheck;
               float fReturnValue;
               int intReturnValue;
               bool parseSucc = true;
               Enum e;
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
                         parseSucc = float.TryParse(i_StrToCheck, out fReturnValue);
                         returnValue = fReturnValue;
                    }
                    else if (i_TypeToCheck == typeof(bool))
                    {
                         parseSucc = bool.TryParse(i_StrToCheck, out parseSucc);
                         returnValue = parseSucc;
                    }
                    else if (i_TypeToCheck == typeof(int))
                    {
                         parseSucc = int.TryParse(i_StrToCheck, out intReturnValue);
                         returnValue = intReturnValue;
                    }

                    if (!parseSucc)
                    {
                         throw new FormatException();
                    }

                    return returnValue;
               }
               catch
               {
                    throw new FormatException();
               }
          }
     }
}