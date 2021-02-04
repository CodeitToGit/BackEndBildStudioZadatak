using BackendTestniZadatak.Helpers;
using BackendTestniZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Interfaces
{
#pragma warning disable 1591
    public interface IDeviceRepository
    {
        Task<Device> GetDeviceById(int id);
        Task<List<Device>> GetAllDevices();
        void CreateDevice(Device model);
        void UpdateDevice(Device model);
        Task<List<Device>> DeviceSearch(DeviceSearchModel search);
        Task DeleteDevice(int id);
    }
}
