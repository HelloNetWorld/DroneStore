using DroneStore.Core.Entities.Catalog;
using DroneStore.Core.Entities.Currency;
using DroneStore.Core.Entities.Discounts;
using DroneStore.Core.Entities.Media;
using DroneStore.Core.Entities.Orders;
using DroneStore.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DroneStore.Data
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
		{
		}

		public DbSet<CatalogItem> CatalogItems { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Discount> Discounts { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<CatalogItem>(ConfigureCatalogItem);

			builder.Entity<Image>(ConfigureImage);

			builder.Entity<Order>(ConfigureOrder);
			builder.Entity<OrderItem>(ConfigureOrderItem);

			builder.Entity<Discount>(ConfigureDiscount);

            builder.Entity<ExchangeRate>(ConfigureExchangeRate);
		}

		#region Orders

		public void ConfigureOrder(EntityTypeBuilder<Order> builder)
		{
			builder.Property(c => c.FirstName)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.LastName)
				.HasMaxLength(150)
				.IsRequired();

			builder.HasMany(o => o.OrderItems)
				.WithOne(o => o.Order)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(c => c.Address1)
				.HasMaxLength(250)
				.IsRequired();

			builder.Property(c => c.Address2)
				.HasMaxLength(250);

			builder.Property(c => c.CreationDate)
				.HasColumnType("datetime2")
				.IsRequired();

			builder.Property(c => c.CustomerEmail)
				.HasMaxLength(350)
				.IsRequired();

			builder.Property(c => c.OrderDiscount)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(c => c.OrderSubTotal)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(c => c.OrderTotal)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(c => c.CreationDate)
				.HasColumnType("datetime2")
				.IsRequired();

			builder.Property(c => c.PaymentMethod)
				.HasMaxLength(150);

			builder.Property(c => c.PaymentStatus)
				.HasMaxLength(150);

			builder.Property(c => c.PhoneNumber)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(c => c.PhoneNumber2)
				.HasMaxLength(50);

			builder.Property(c => c.ZipCode)
				.HasMaxLength(20)
				.IsRequired();
		}

		public void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
		{
			builder.Property(oi => oi.CreationDate)
				.HasColumnType("datetime2")
				.IsRequired();

			builder.Property(c => c.ProductId)
				.HasMaxLength(20);

			builder.Property(oi => oi.Quantity)
				.IsRequired();

			builder.Property(oi => oi.UnitPrice)
				.HasPrecision(18, 2)
				.IsRequired();
		}

		#endregion Orders

		#region Catalog

		public void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
		{
			builder.Property(ci => ci.Name)
				 .HasMaxLength(150)
				 .IsRequired();

			builder.Property(ci => ci.Price)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(ci => ci.Brand)
				.HasMaxLength(150)
				.IsRequired();

			builder.HasOne(ci => ci.Image)
                .WithOne()
                .HasForeignKey<CatalogItem>(ci => ci.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Discount)
                .WithOne()
                .HasForeignKey<CatalogItem>(d => d.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(ci => ci.Quantity)
                .IsRequired();
		}

		#endregion Catalog

		#region Media

		public void ConfigureImage(EntityTypeBuilder<Image> builder)
		{
			builder.Property(i => i.ContentType)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(i => i.BinaryFile)
				.HasColumnType("image")
				.IsRequired();
		}

		#endregion Media

		#region Discount

		public static void ConfigureDiscount(EntityTypeBuilder<Discount> builder)
		{
			builder.Property(d => d.ExpireDateInUtc)
				.HasColumnType("datetime2")
				.IsRequired();

			builder.Property(d => d.NewValue)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(d => d.OldValue)
				.HasPrecision(18, 2)
				.IsRequired();

			builder.Property(d => d.StartDateInUtc)
				.HasColumnType("datetime2")
				.IsRequired();

            //builder.HasOne(s => s.CatalogItem)
            //    .WithOne(d => d.Discount)
            //    .HasForeignKey<CatalogItem>(d => d.DiscountId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion

        #region Exchange Rate

        public static void ConfigureExchangeRate(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Source)
                .IsRequired();

            builder.Property(e => e.Quote)
                .IsRequired();

            builder.Property(e => e.Rate)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.LastUpdateInUtc)
                .HasColumnType("datetime2")
                .IsRequired();
        }

        #endregion Exchange Rate
    }
}
