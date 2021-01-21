using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }

    }
}
