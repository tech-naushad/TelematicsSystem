using System;
using VehicleManagement.Application.DTOs;

namespace VehicleManagement.Application.Interfaces
{
    public interface IVehicleManagementService
    {
        Task<Guid> RegisterVehicleAsync(VehicleDto createVehicleDto, CancellationToken cancellationToken = default);
    }
}
