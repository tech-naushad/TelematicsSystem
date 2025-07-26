using System;
using VehicleManagement.Application.Dtos;

namespace VehicleManagement.Application.Interfaces
{
    public interface IVehicleManagementService
    {
        Task<Guid> RegisterVehicleAsync(CreateVehicleDto createVehicleDto, CancellationToken cancellationToken = default);
    }
}
