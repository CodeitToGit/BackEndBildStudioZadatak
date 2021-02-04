using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Interfaces
{
#pragma warning disable 1591
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; }
        IDeviceTypeRepository DeviceTypeRepository { get; }
        void Save();
        void Dispose();
    }
}
