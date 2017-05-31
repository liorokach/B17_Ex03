using System;
using System.Collections.Generic;
using System.Text;

namespace GarageCustomerDetails
{
     using enumVehicleStatus;
     using Vehicle;
     using enumFuelType;
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
               details.Add(m_ownerName);
               details.Add(m_phoneNumber);
               details.AddRange(m_myVehicle.GetVehicleDetails());
               details.Add(e_repairStatus.ToString());
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
     }
}
