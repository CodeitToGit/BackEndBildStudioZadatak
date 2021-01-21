using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Models
{
    public class DeviceType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public DeviceType Parent { get; set; }
        public ICollection<DeviceFeature> Features { get; set; }

    }
}
