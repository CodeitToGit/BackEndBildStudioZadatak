using BackendTestniZadatak.Helpers;
using BackendTestniZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> GetDeviceById(int id);
        void CreateDevice(Device model);
        void UpdateDevice(Device model);
        Task<DeviceSearchModelResult> DeviceSearch(DeviceSearchModel search);
        Task DeleteDevice(int id);
    }
}
