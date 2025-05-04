using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Infrastructure.Context;

namespace WarehouseService.Infrastructure.Common
{
    public abstract class BaseRepository
    {
        protected IDbContext _dbContext;
        public readonly string Table;
        protected BaseRepository(IDbContext dbContext, string table)
        {
            _dbContext = dbContext;
            Table = table;
        }
    }
}
