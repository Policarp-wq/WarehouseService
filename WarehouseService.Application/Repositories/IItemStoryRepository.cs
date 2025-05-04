using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Repositories
{
    public interface IItemStoryRepository
    {
        Task<ItemStory> AddItemStory(ItemStory itemStory);
        Task<IEnumerable<ItemStory>> GetItemsStory(int itemId);
    }
}
