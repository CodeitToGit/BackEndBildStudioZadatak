using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Models
{
    public class DeviceFeature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
