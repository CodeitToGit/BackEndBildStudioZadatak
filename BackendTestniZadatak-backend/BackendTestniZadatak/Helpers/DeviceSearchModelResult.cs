using BackendTestniZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Helpers
{
    public class DeviceSearchModelResult
    {
        public List<Device> Devices { get; set; }
        public List<DeviceType> Types { get; set; }
    }
}
