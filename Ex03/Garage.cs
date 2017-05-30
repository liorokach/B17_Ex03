using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
     using GarageCustomerDetails;
     using enumVehicleStatus;
     using Vehicle;
     public class Garage
     {
          private Dictionary<string, GarageCustomerDetails> m_garageDB;

          public Garage()
          {
               m_garageDB = new Dictionary<string, GarageCustomerDetails>();
          }

          public void AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber)
          {
               if (!m_garageDB.ContainsKey(i_Vehicle.GetLicenceNumber()))
               {
                    m_garageDB.Add(i_Vehicle.GetLicenceNumber(), new GarageCustomerDetails(i_Vehicle, i_OwnerName, i_PhoneNumber)); // add new car to the garage
               }
               else //// the vehicle exist
               {
                    m_garageDB[i_Vehicle.GetLicenceNumber()].UpdateStatus(eVehicleStatus.InRepair);
                    //// let the user know that the car exist
               }
          }

          public void ChangeStatus(string i_LicenceNumber,eVehicleStatus i_NextStatus)
          {
               if (m_garageDB.ContainsKey(i_LicenceNumber)) 
               {
                    m_garageDB[i_LicenceNumber].UpdateStatus(i_NextStatus);
               }
               else //// the vehicle doesn't exist
               {
                    //throw Exception
               }
          } 

          public List<string> GetLicenceNumberByStatus(string i_status)
          {
               eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_status, true);
               List<string> licenceNumbers = new List<string>();
               foreach(var vehicle in m_garageDB)
               {
                    if(vehicle.Value.GetStatus() == status)
                    {
                         licenceNumbers.Add(vehicle.Value.GetLicence());
                    }
               }
               return licenceNumbers;
          }

          public List<string> GetVehicleDetails(string i_LicenceNum)
          {
               List<string> vehicleDetails = new List<string>();
               if (m_garageDB.ContainsKey(i_LicenceNum))
               {
                    vehicleDetails.Add(m_garageDB[i_LicenceNum].ToString());
               }
               else
               {
                    ///// not exist - error
               }
               return vehicleDetails;
          }
     }
}
