using BackendTestniZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Interfaces
{
    public interface IDeviceTypeRepository
    {
        Task<DeviceType> GetDeviceTypeById(int id);
        Task<List<DeviceType>> GetDeviceTypes();
        void CreateOrUpdateDeviceType(DeviceType model);
        Task DeleteDeviceType(int id);
    }
}
