using BackendTestniZadatak.Helpers;
using BackendTestniZadatak.Models;
using BackendTestniZadatak.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }

        // Vraca jedan device po Id-u ukljucujuci tip i sve njegove osobine
        public async Task<Device> GetDeviceById(int id)
        {
            return await _context.Devices.Where(i => i.Id == id)
                .Include(dt => dt.DeviceType)
                .ThenInclude(f => f.Features)
                .OrderBy(d => d.DeviceType)
                .FirstAsync();
        }

        // Kreiranje novog devica
        public async void CreateDevice(Device model)
        {
            await _context.AddAsync(model);
        }

        // Updejtovanje postojeceg devica
        public void UpdateDevice(Device model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

        // Pretraga za devicove, 
        public async Task<DeviceSearchModelResult> DeviceSearch(DeviceSearchModel search)
        {
            var result = new DeviceSearchModelResult();

            var types = from b in _context.DeviceTypes
                        select b;

            var devices = from m in _context.Devices
                          select m;


            int skip = (search.PageNumber - 1) * 5;

            if (search != null)
            {
                // U slucaju da se ne posalje NumberOfDevicesPerPage dobicemo samo 5 devicova u rezultatu, default-na vrijednost je u DeviceSearchModel.cs

                if (!string.IsNullOrEmpty(search.Name))
                    result.Devices = await devices.Where(n => n.Name == search.Name)
                        .Include(dt => dt.DeviceType)
                        .ThenInclude(f => f.Features)
                        .Skip(skip)
                        .Take(search.NumberOfDevicesPerPage)
                        .ToListAsync();
                if (!string.IsNullOrEmpty(search.Type))
                    result.Types = await types.Where(t => t.Name == search.Type)
                        .Include(f => f.Features)
                        .Include(p => p.Parent)
                        .ToListAsync();
            }
            return result;
        }


        // Brisanje jednog devica po Id-u
        public async Task DeleteDevice(int id)
        {
            var device = await GetDeviceById(id);

            if (device != null)
            {
                try
                {
                    foreach (var feature in device.DeviceType.Features)
                    {
                        _context.DeviceFeatures.Remove(feature);
                    }
                    _context.Devices.Remove(device);
                }
                catch (Exception)
                {
                    throw new Exception($"Device with id: {id} doesn't exist!");
                }
            }

        }
    }
}
