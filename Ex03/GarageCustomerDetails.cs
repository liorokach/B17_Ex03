using System;
using System.Collections.Generic;
using System.Text;

namespace GarageCustomerDetails
{
     using eVehicleStatus;
     using Vehicle;
     using eFuelType;
     using eEngineType;

     public class GarageCustomerDetails
     {
          private string m_ownerName;
          private Vehicle m_myVehicle;
          private string m_phoneNumber;
          private eVehicleStatus e_repairStatus = eVehicleStatus.InRepair;

          public GarageCustomerDetails(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNum)
          {
               m_myVehicle = i_Vehicle;
               m_ownerName = i_OwnerName;
               m_phoneNumber = i_PhoneNum;
          }

          public string GetLicence()
          {
               return m_myVehicle.LicenceNumber;
          }

          public void PumpToMax()
          {
               m_myVehicle.PumpWheelsToMax();
          }

          public List<string> GetAllDetails()
          {
               List<string> details = new List<string>();
               details.Add(string.Format("vehicle owner name: {0}", m_ownerName));
               details.Add(string.Format("owner phone number: {0}", m_phoneNumber));
               details.AddRange(m_myVehicle.GetVehicleDetails());
               details.Add(string.Format("vehicle status in garage: {0}", e_repairStatus.ToString()));
               return details;
          }

          public void ReFuel(eFuelType i_FuelType, float i_AddAmount)
          {
               m_myVehicle.AddFuel(i_FuelType, i_AddAmount);
          }

          public void ReCharge(float i_AddAmount)
          {
               m_myVehicle.ChargeBattery(i_AddAmount);
          }

          public eVehicleStatus Status
          {
               get
               {
                    return e_repairStatus;
               }

               set
               {
                    e_repairStatus = value;
               }
          }

          public eFuelType GetFuelType()
          {
               return m_myVehicle.GetFuelType();
          }

          public eEngineType GetEngineType()
          {
               return m_myVehicle.EngineType;
          }
     }
}
