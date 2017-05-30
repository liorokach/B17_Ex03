using System;
using System.Collections.Generic;
using System.Text;

namespace GarageCustomerDetails
{
     using enumVehicleStatus;
     using Vehicle;
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

          public void UpdateStatus(eVehicleStatus i_NextStatus)
          {
               e_repairStatus = i_NextStatus;
          }

          public eVehicleStatus GetStatus()
          {
               return e_repairStatus;
          }

          public string GetLicence()
          {
               return m_myVehicle.GetLicenceNumber();
          }

          public void PumpToMax()
          {
               m_myVehicle.PumpWheelsToMax();
          }
     }
}
