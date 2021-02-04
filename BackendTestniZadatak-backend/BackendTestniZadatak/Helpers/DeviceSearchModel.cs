using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Helpers
{
    public class DeviceSearchModel
    {
        public int PageNumber { get; set; } = 1;
        public int NumberOfDevicesPerPage { get; set; } = 5;
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
