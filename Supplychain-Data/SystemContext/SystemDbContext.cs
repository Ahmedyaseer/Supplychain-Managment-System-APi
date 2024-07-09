using Microsoft.EntityFrameworkCore;
using Supplychain_Data.Models;

namespace Supplychain_Data.SystemContext
{
    public class SystemDbContext :DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) :base(options)
        {}

        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Employee> Employees {  get; set; } 
        public DbSet<Item> Items { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }  
        public DbSet<Customer> Customers  { get; set; }  
        public DbSet<OrderSupply> OrderSupply { get; set; }
        public DbSet<OrderSupplyItems> OrderSupplyItems { get; set; }
        public DbSet<PickingList> PickingLists { get; set; }
        public DbSet<PickingListItems> pickingListItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .HasMany(i => i.Items)
                .WithMany(w => w.Warehouses)
                .UsingEntity<WarehouseItem>();

            modelBuilder.Entity<WarehouseItem>()
                .HasOne(e => e.Warehouse)
                .WithMany(wi => wi.WearhouseItems)
                .HasForeignKey(e => e.WarehouseId);

            modelBuilder.Entity<WarehouseItem>()
                .HasOne(i=>i.Item)
                .WithMany(wi=>wi.WarehouseItems)
                .HasForeignKey(i => i.ItemId);

            modelBuilder.Entity<WarehouseItem>()
                .HasKey(c=> new {c.WarehouseId, c.ItemId});
    


            modelBuilder.Entity<Warehouse>()
                .HasOne(e => e.Employee)
                .WithOne(w => w.Warehouse)
                .HasForeignKey<Employee>(f => f.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderSupply>()
                .HasOne(w => w.Warehouse)
                .WithMany(os => os.OrderSupplies)
                .HasForeignKey(x => x.WarehouseId);

            modelBuilder.Entity<OrderSupply>()
                .HasOne(s => s.Supplier)
                .WithMany(os => os.OrderSupplies)
                .HasForeignKey(f => f.SupplierId);

            modelBuilder.Entity<OrderSupply>()
                .HasMany(i=>i.Items)
                .WithMany(os=>os.orderSupplies)
                .UsingEntity<OrderSupplyItems>(
                j=>j
                .HasOne(i => i.Item)
                .WithMany(osi => osi.OrderSupplyItems)
                .HasForeignKey(f => f.ItemId),
                j=>j
                .HasOne(os=>os.OrderSupply)
                .WithMany(osi=>osi.OrderSupplyItems)
                .HasForeignKey(f=>f.OrderSupplyId),
                j=>j
                .HasKey(k=> new
                {
                    k.OrderSupplyId,
                    k.ItemId
                }));
            modelBuilder.Entity<OrderSupply>()
                .Property(x => x.OrderSupplyDate)
                .HasDefaultValue(DateTime.Now.ToString("g"));

            modelBuilder.Entity<OrderSupplyItems>()
                .Property(x => x.ProductionTime)
                .HasDefaultValue(DateTime.Now.ToString("g"));
            modelBuilder.Entity<OrderSupplyItems>()
                .Property(x=>x.ExpirationTime)
                .HasDefaultValue(DateTime.Now.AddYears(1).ToString("g"));

            #region Picking List Relations

            modelBuilder.Entity<PickingList>()
            .HasOne(c => c.Customer)
            .WithMany(pl => pl.PickingLists)
            .HasForeignKey(f => f.CustomerId);

            modelBuilder.Entity<PickingList>()
                .HasOne(w => w.Warehouse)
                .WithMany(pl => pl.PickingLists)
                .HasForeignKey(f => f.WarehouseId);

            modelBuilder.Entity<PickingList>()
                .HasMany(i => i.Items)
                .WithMany(pi => pi.pickingLists)
                .UsingEntity<PickingListItems>(
                j => j
                .HasOne(i => i.Item)
                .WithMany(pli => pli.PickingListItems)
                .HasForeignKey(f => f.ItemId),
                j => j
                .HasOne(pl => pl.PickingList)
                .WithMany(pli => pli.PickingListItems)
                .HasForeignKey(f => f.PickingListId),
                j => j
                .HasKey(k => new
                {
                    k.PickingListId,
                    k.ItemId
                }));

            modelBuilder.Entity<PickingList>()
                .Property(d => d.PickingListTime)
                .HasDefaultValue(DateTime.Now.ToString("g"));

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
