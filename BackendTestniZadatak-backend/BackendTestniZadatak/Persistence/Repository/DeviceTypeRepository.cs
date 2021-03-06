﻿using BackendTestniZadatak.Models;
using BackendTestniZadatak.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence.Repository
{
#pragma warning disable 1591
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly AppDbContext _context;

        public DeviceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Vraca tip devica za odredjeni Id
        public async Task<DeviceType> GetDeviceTypeById(int id)
        {
            return await _context.DeviceTypes.Where(i => i.Id == id)
                .Include(f => f.Features)
                .Include(p => p.Parent)
                .ThenInclude(pf => pf.Features)
                .OrderBy(d => d.Name)
                .FirstAsync();
        }


        // Vraca sve tipove devica ukljucujuci sve osobine i vratice i nadtip u slucaju da ga neki tip sadrzi (Parent)
        public async Task<List<DeviceType>> GetDeviceTypes()
        {
            return await _context.DeviceTypes.Include(f => f.Features).Include(p => p.Parent).ThenInclude(pf => pf.Features).ToListAsync();
        }

        // Kreiranje ili updejtovanje tipa, u tekstu zadatka pise "Za unos ili izmjenu postojećeg tipa", ja obicno pravim odvojeno ali ovo sam ovako rijesio. 
        public async void CreateOrUpdateDeviceType(DeviceType model)
        {
            if (model.Id != 0)
            {
                var existingType = _context.DeviceTypes
                                   .Where(i => i.Id == model.Id)
                                   .Include(f => f.Features)
                                   .SingleOrDefault();

                if (existingType != null)
                {
                    _context.Entry(existingType).CurrentValues.SetValues(model);

                    var deviceFeatures = existingType.Features;

                    var featuresToDelete = deviceFeatures.Where(f => !model.Features.Any(f1 => f1.Id == f.Id)).ToList();
                    var featuresToAdd = model.Features.Where(f => !deviceFeatures.Any(f1 => f1.Id == f.Id)).ToList();

                    _context.DeviceFeatures.RemoveRange(featuresToDelete);

                    foreach (var feature in featuresToAdd)
                    {
                        var newFeature = new DeviceFeature
                        {
                            Name = feature.Name,
                            DeviceTypeId = feature.DeviceTypeId
                        };
                        _context.DeviceFeatures.Add(newFeature);
                    }
                }
            }
            else
            {
                await _context.DeviceTypes.AddAsync(model);
            }
        }

        // Brise tip po Id-u. Takodje ako neki tip ima osobine obrisace i osobine za taj tip
        public async Task DeleteDeviceType(int id)
        {
            var deviceType = await GetDeviceTypeById(id);
            if (deviceType != null)
            {
                if (deviceType.Features != null)
                {
                    foreach (var feature in deviceType.Features)
                    {
                        _context.DeviceFeatures.Remove(feature);
                    }
                }
                try
                {
                    _context.DeviceTypes.Remove(deviceType);
                }
                catch (Exception e)
                {
                    throw new Exception("Exception in DeleteDeviceType: ", e);
                }
            }
        }
    }
}
