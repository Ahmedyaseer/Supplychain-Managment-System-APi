﻿namespace Supplychain_Data.Models
{
    public  class WarehouseItem
    {
        public int WarehouseId { get; set; }

        public int ItemId { get; set; }
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }  

        public int Quantity { get; set; }   
    }
}
