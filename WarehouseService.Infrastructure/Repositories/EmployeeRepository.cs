﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.Employees;
using WarehouseService.Application.Repositories;
using WarehouseService.Infrastructure.Common;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly DbSet<Employee> _employees;  
        public EmployeeRepository(IDbContext dbContext) : base(dbContext, "Employees")
        {
            _employees = _dbContext.Employees;
        }

        public async Task<EmployeePresentation> CreateEmployee(EmployeeInfo employee)
        {
            var res = await _employees.AddAsync(new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                WarehouseId = employee.WarehouseId,
            });
            return EmployeePresentation.FromEntity(res.Entity);
        }

        public async Task<EmployeeInfo?> GetById(int id)
        {
            var res = await _employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            if(res == null) 
                return null;
            return EmployeeInfo.FromEntity(res);
        }

        public async Task<IEnumerable<int>> GetByPosition(Position position)
        {
            return await _employees
                .AsNoTracking()
                .Where(e => e.Position == position)
                .Select(x => x.Id)
                .ToListAsync();
        }

        public async Task<int?> GetWarehouseOwner(int warehouseId)
        {
            var res = await GetWarehouseWorkersByPosition(warehouseId, Position.Owner);
            int cnt = res.Count();
            if (cnt > 1)
                throw new DatabaseException(Table, $"more than one owner for warehouse {warehouseId}");
            if (cnt == 0)
                return null;
            return res.First();
        }

        public async Task<IEnumerable<int>> GetWarehouseWorkers(int warehouseId)
        {
            return await _employees
                .AsNoTracking()
                .Where(e => e.WarehouseId == warehouseId)
                .Select(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> GetWarehouseWorkersByPosition(int warehouseId, Position position)
        {
            return await _employees
                .AsNoTracking()
                .Where(e => e.WarehouseId == warehouseId && e.Position == position)
                .Select(x => x.Id)
                .ToListAsync();
        }

        public async Task<bool> UpdateAttachedPosition(PositionUpdateInfo info)
        {
            var res = await _employees.FindAsync(info.EmployeeId);
            if (res == null) throw new NotFoundException(Table, $"No employee for the given id {info.EmployeeId}");
            if (res.Position == info.Position)
                return false;
            res.Position = info.Position;
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAttachedWarehouse(WarehouseWorkUpdateInfo info)
        {
            var res = await _employees.FindAsync(info.EmployeeId);
            if (res == null) throw new NotFoundException(Table, $"No employee for the given id {info.EmployeeId}");
            if(res.WarehouseId == info.WarehouseId)
                return false;
            res.WarehouseId = info.WarehouseId;
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}
