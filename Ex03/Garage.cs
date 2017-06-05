using System.Collections.Generic;

namespace Garage
{
    using GarageCustomerDetails;
    using eVehicleStatus;
    using Vehicle;
    using eFuelType;
    public class Garage
    {
        private Dictionary<string, GarageCustomerDetails> m_garageDB;

        public Garage()
        {
            m_garageDB = new Dictionary<string, GarageCustomerDetails>();
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber)
        {
            if (!m_garageDB.ContainsKey(i_Vehicle.LicenceNumber))
            {
                m_garageDB.Add(i_Vehicle.LicenceNumber, new GarageCustomerDetails(i_Vehicle, i_OwnerName, i_PhoneNumber)); // add new car to the garage
            }
            else //// the vehicle exist
            {
                m_garageDB[i_Vehicle.LicenceNumber].Status = eVehicleStatus.InRepair;
                //// let the user know that the car exist
            }
        }

        public void ChangeStatus(string i_LicenceNumber, eVehicleStatus i_NextStatus)
        {
            if (m_garageDB.ContainsKey(i_LicenceNumber))
            {
                m_garageDB[i_LicenceNumber].Status = i_NextStatus;
            }
            else //// the vehicle doesn't exist
            {
                throw new KeyNotFoundException();
            }
        }

        public List<string> GetLicenceNumberByStatus(eVehicleStatus i_StatusFilter = eVehicleStatus.All)
        {
            List<string> licenceNumbers = new List<string>();
            foreach (var vehicle in m_garageDB)
            {
                if (vehicle.Value.Status == i_StatusFilter || i_StatusFilter == eVehicleStatus.All)
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
                vehicleDetails = m_garageDB[i_LicenceNum].GetAllDetails();
            }
            else
            {
                throw new KeyNotFoundException();
            }
            return vehicleDetails;
        }

        public bool PumpWheelsToMax(string i_LicenceNum)
        {
            bool exist = false;
            if (m_garageDB.ContainsKey(i_LicenceNum))
            {
                m_garageDB[i_LicenceNum].PumpToMax();
                exist = true;
            }
            return exist;
        }

        public void ReFuel(string i_LicenceNum, eFuelType i_FuelType, float i_AddAmount)
        {
            if (m_garageDB.ContainsKey(i_LicenceNum))
            {
                m_garageDB[i_LicenceNum].ReFuel(i_FuelType, i_AddAmount);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void ReCharge(string i_LicenceNum, float i_AddAmount)
        {
            if (m_garageDB.ContainsKey(i_LicenceNum))
            {
                m_garageDB[i_LicenceNum].ReCharge(i_AddAmount);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
