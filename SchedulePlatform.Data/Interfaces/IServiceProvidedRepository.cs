﻿using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Interfaces
{
    public interface IServiceProvidedRepository
    {
        ServiceProvided Add(ServiceProvided serviceP);
        ServiceProvided[] GetAll();
        ServiceProvided? GetById(Guid id);
        ServiceProvided Update(ServiceProvided serviceP);
        ServiceProvided Delete(Guid id, ServiceProvided serviceP);

    }
}