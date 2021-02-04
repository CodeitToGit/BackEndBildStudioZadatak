using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTestniZadatak.Models;
using BackendTestniZadatak.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendTestniZadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable 1591
    public class DeviceTypesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public DeviceTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get DeviceType by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Device type with features.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _unitOfWork.DeviceTypeRepository.GetDeviceTypeById(id);
            return Ok(result);
        }

        /// <summary>
        /// Get all device types from db.
        /// </summary>
        /// <returns>List of all device types.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.DeviceTypeRepository.GetDeviceTypes();
            return Ok(result);
        }


        /// <summary>
        /// Create new or update existing device type. Also use this to create or update features.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / DeviceType - Creating new
        ///     {
        ///        "name": "Racunar",
        ///        "features":[
        ///        {
        ///             "name": "Operativni sistem"       
        ///        }
        ///         ]
        ///     }
        ///     
        ///     PUT / DeviceType - Updating existing (make sure that device type exist in db)
        ///     {
        ///         "id":1,
        ///         "name": "Racunar2",
        ///         "features": [
        ///              {
        ///                "id":1,
        ///                "name":"OS"
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <param name="deviceType"></param>
        [HttpPost]
        public void CreateOrUpdate(DeviceType deviceType)
        {
            _unitOfWork.DeviceTypeRepository.CreateOrUpdateDeviceType(deviceType);
            _unitOfWork.Save();
        }


        /// <summary>
        /// Delete device type by id which will delete all features that have that type.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _unitOfWork.DeviceTypeRepository.DeleteDeviceType(id);
            _unitOfWork.Save();
        }
    }
}
