using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Common
{
    public abstract class BaseRepository
    {
        protected IDbContext _context;
        protected BaseRepository(IDbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
