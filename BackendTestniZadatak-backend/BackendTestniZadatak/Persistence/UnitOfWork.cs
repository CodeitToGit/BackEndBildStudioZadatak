using BackendTestniZadatak.Models;
using BackendTestniZadatak.Persistence.Interfaces;
using BackendTestniZadatak.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Persistence
{
#pragma warning disable 1591
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDeviceRepository _deviceRepository;
        private IDeviceTypeRepository _deviceTypeRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IDeviceRepository DeviceRepository
        {
            get { return _deviceRepository = _deviceRepository ?? new DeviceRepository(_context); }
        }
        public IDeviceTypeRepository DeviceTypeRepository
        {
            get { return _deviceTypeRepository = _deviceTypeRepository ?? new DeviceTypeRepository(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
