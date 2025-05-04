using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Entities
{
    public struct ItemSize
    {
        public ItemSize(float length, float height, float width)
        {
            Length = length;
            Height = height;
            Width = width;
        }

        public float Length { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }
}
