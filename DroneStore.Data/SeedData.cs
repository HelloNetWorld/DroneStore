using System;
using System.Collections.Generic;
using System.Linq;
using DroneStore.Core.Entities.Catalog;
using DroneStore.Core.Entities.Discounts;
using DroneStore.Core.Entities.Media;

namespace DroneStore.Data
{
    public static class SeedData
	{
		public static void Seed(StoreDbContext storeDbContext)
		{
			if (!storeDbContext.Images.Any())
			{
				storeDbContext.AddRange(GetImages());
				storeDbContext.SaveChanges();
			}

			if (!storeDbContext.Discounts.Any())
			{
				storeDbContext.AddRange(GetDiscounts());
				storeDbContext.SaveChanges();
			}

			if (!storeDbContext.CatalogItems.Any())
			{
				storeDbContext.AddRange(GetCatalogItems());
				storeDbContext.SaveChanges();
			}
		}

		private static IEnumerable<CatalogItem> GetCatalogItems()
		{
			return new CatalogItem[]
			{
				new CatalogItem()
				{
					ImageId = 1,
					Name = "Quadcopter DJI Mavic Air",
					Price = 850m,
					Brand = "DJI",
					CreatedinUtc = new DateTime(2013, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 1,
                    Quantity = 3
				},

				new CatalogItem()
				{
					ImageId = 2,
					Name = "Quadcopter MJX Bugs 8",
					Price = 89m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2014, 1, 2, 12, 32, 56, DateTimeKind.Utc),
					DiscountId = null,
                    Quantity = 1
				},

				new CatalogItem()
				{
					ImageId = 3,
					Name = "Quadcopter Ryze Tech Tello",
					Price = 130m,
					Brand = "Ryze Tech",
					CreatedinUtc = new DateTime(2015, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 2,
                    Quantity = 7
				},

				new CatalogItem()
				{
					ImageId = 4,
					Name = "Xiaomi Mi Drone 4К",
					Price = 610m,
					Brand = "Xiaomi",
					CreatedinUtc = new DateTime(2016, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null,
                    Quantity = 0
				},

				new CatalogItem()
				{
					ImageId = 5,
					Name = "Xiaomi MiTu Minidrone 720P",
					Price = 93m,
					Brand = "Xiaomi",
					CreatedinUtc = new DateTime(2017, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 4,
                    Quantity = 2
				},

				new CatalogItem()
				{
					ImageId = 6,
					Name = "MJX Bugs 3",
					Price = 81m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2018, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null,
                    Quantity = 2
				},

				new CatalogItem()
				{
					ImageId = 7,
					Name = "MJX X600",
					Price = 40m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2017, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null,
                    Quantity = 6
				},

				new CatalogItem()
				{
					ImageId = 8,
					Name = "MJX Bugs 2 SE",
					Price = 205m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2016, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 3,
                    Quantity = 11
				},

				new CatalogItem()
				{
					ImageId = 9,
					Name = "DJI Mavic 2 Pro",
					Price = 1587m,
					Brand = "DJI",
					CreatedinUtc = new DateTime(2015, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null,
                    Quantity = 16
				}
			};
		}

		private static IEnumerable<Image> GetImages()
		{
			return new Image[]
			{
				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._1,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._2,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._3,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._4,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._5,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._6,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._7,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._8,
					 ContentType = "image/jpeg"
				},

				new Image()
				{
					 BinaryFile = global::DroneStore.Data.Properties.Resources._9,
					 ContentType = "image/jpeg"
				}
			};
		}

		private static IEnumerable<Discount> GetDiscounts()
		{
			return new Discount[]
			{
				new Discount()
				{
					  OldValue = 1150m,
					  NewValue = 750m,
					  StartDateInUtc = DateTime.UtcNow,
					  ExpireDateInUtc = DateTime.UtcNow + TimeSpan.FromDays(7)
				},
				new Discount()
				{
					  OldValue = 160m,
					  NewValue = 125m,
					  StartDateInUtc = DateTime.UtcNow,
					  ExpireDateInUtc = DateTime.UtcNow + TimeSpan.FromDays(15)
				},
				new Discount()
				{
					  OldValue = 205m,
					  NewValue = 185m,
					  StartDateInUtc = DateTime.UtcNow,
					  ExpireDateInUtc = DateTime.UtcNow + TimeSpan.FromDays(3)
				},
                new Discount()
                {
                      OldValue = 93m,
                      NewValue = 86m,
                      StartDateInUtc = DateTime.UtcNow,
                      ExpireDateInUtc = DateTime.UtcNow + TimeSpan.FromMinutes(5)
                }
            };
		}
	}
}
