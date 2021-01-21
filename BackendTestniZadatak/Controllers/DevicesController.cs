using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTestniZadatak.Helpers;
using BackendTestniZadatak.Models;
using BackendTestniZadatak.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendTestniZadatak.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;

        public DevicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets Device by device's Id.
        /// </summary>
        /// <param name="id"> 
        /// The Id of desired device.
        /// </param>
        /// <returns>
        /// One device.
        /// </returns>
        [HttpGet("api/devices/{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var result = await _unitOfWork.DeviceRepository.GetDeviceById(id);
            return Ok(result);
        }

        /// <summary>
        /// Creating new device.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST / Device - Creating new (make sure that deviceTypeId you are entering exists)
        ///     {
        ///         "name":"Device 1",
        ///         "deviceTypeId":1
        ///     }
        ///     
        /// </remarks>
        [HttpPost("api/devices")]
        public void Create(Device device)
        {
            _unitOfWork.DeviceRepository.CreateDevice(device);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Updating exsisting device.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT / Device - Updating existing
        ///     {
        ///         "id":1,
        ///         "name":"Device 342",
        ///         "deviceTypeId":1
        ///     }
        /// </remarks>
        /// <param name="device"></param>
        [HttpPut("api/devices")]
        public void Update(Device device)
        {
            _unitOfWork.DeviceRepository.UpdateDevice(device);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Search device by name/type/page number.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST / Device - Searching for devices
        ///     {
        ///         "pageNumber":1,
        ///         "numberOfDevicesPerPage": 1,
        ///         "name": "Device 342",
        ///         "type":"OS"
        ///     }
        /// </remarks>
        /// <param name="search"></param>
        /// <returns> List of devices.</returns>
        [HttpPost("api/devices/search")]
        public async Task<IActionResult> DeviceSearch(DeviceSearchModel search)
        {
            var result = await _unitOfWork.DeviceRepository.DeviceSearch(search);
            return Ok(result);
        }

        /// <summary>
        /// Deleting one device by Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("api/devices/{id}")]
        public async Task Delete(int id)
        {
            await _unitOfWork.DeviceRepository.DeleteDevice(id);
            _unitOfWork.Save();
        }

    }
}
