﻿using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.RoleDTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetById()
        {
            throw new NotImplementedException();
        }

        public Task Insert()
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
