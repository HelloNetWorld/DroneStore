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

			//if (!catalogDbContext.Batteries.Any())
			//{
			//    catalogDbContext.AddRange(GetBatteries());
			//    catalogDbContext.SaveChanges();
			//}

			//if (!catalogDbContext.Cameras.Any())
			//{
			//    catalogDbContext.AddRange(GetCameras());
			//    catalogDbContext.SaveChanges();
			//}

			//if (!catalogDbContext.Multicopters.Any())
			//{
			//    catalogDbContext.AddRange(GetMulticopters());
			//    catalogDbContext.SaveChanges();
			//}
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
					DiscountId = 1
				},

				new CatalogItem()
				{
					ImageId = 2,
					Name = "Quadcopter MJX Bugs 8",
					Price = 89m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2014, 1, 2, 12, 32, 56, DateTimeKind.Utc),
					DiscountId = null
				},

				new CatalogItem()
				{
					ImageId = 3,
					Name = "Quadcopter Ryze Tech Tello",
					Price = 130m,
					Brand = "Ryze Tech",
					CreatedinUtc = new DateTime(2015, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 2
				},

				new CatalogItem()
				{
					ImageId = 4,
					Name = "Xiaomi Mi Drone 4К",
					Price = 610m,
					Brand = "Xiaomi",
					CreatedinUtc = new DateTime(2016, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null
				},

				new CatalogItem()
				{
					ImageId = 5,
					Name = "Xiaomi MiTu Minidrone 720P",
					Price = 93m,
					Brand = "Xiaomi",
					CreatedinUtc = new DateTime(2017, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null
				},

				new CatalogItem()
				{
					ImageId = 6,
					Name = "MJX Bugs 3",
					Price = 81m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2018, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null
				},

				new CatalogItem()
				{
					ImageId = 7,
					Name = "MJX X600",
					Price = 40m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2017, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null
				},

				new CatalogItem()
				{
					ImageId = 8,
					Name = "MJX Bugs 2 SE",
					Price = 205m,
					Brand = "MJX",
					CreatedinUtc = new DateTime(2016, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = 3
				},

				new CatalogItem()
				{
					ImageId = 9,
					Name = "DJI Mavic 2 Pro",
					Price = 1587m,
					Brand = "DJI",
					CreatedinUtc = new DateTime(2015, 12, 23, 12, 34, 56, DateTimeKind.Utc),
					DiscountId = null
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
				}
			};
		}

		//private static IEnumerable<Multicopter> GetMulticopters()
		//{
		//    return new Multicopter[]
		//    {
		//        new Multicopter()
		//        {
		//            CameraId = 1,
		//            BatteryId = 1,
		//            Description = "Quadcopter DJI Mavic Air",
		//            FullDescription = "Quadcopter DJI Mavic Air",
		//            Dimensions = "168x184x64",
		//            Equipment = "propellers (8 pcs.), propeller protection, Li-Po battery," +
		//                        " charger, power cable, manual, case, stabilizer protection," +
		//                        " USB type-C cable, USB adapter," +
		//                        " connectors: Lightning, Micro USB, USB type-C, retainer cable (3 pcs.)," +
		//                        " spare sticks for the remote (2 pcs.)",
		//            FullWeight = 1500,
		//            MaxFlightDistance = 2000,
		//            MobileOSSupport = "Android, iOS",
		//            NumberOfMotors = 4,
		//            Price = 850m,
		//            Quantity = 3,
		//            Sensors = "magnetometer, accelerometer, ultrasonic sensor," +
		//                      " barometer, visual positioning sensor, infrared sensor, gyroscope",
		//            ShortDescription = "Quadcopter DJI Mavic Air",
		//            TypeOfFlightControl = "Wi-Fi, radio",
		//            Weight = 430,
		//            Brand = "DJI"
		//        },
		//        new Multicopter()
		//        {
		//            CameraId = 2,
		//            BatteryId = 2,
		//            Description = "Quadcopter MJX Bugs 8",
		//            FullDescription = "Quadcopter MJX Bugs 8",
		//            Dimensions = "330x330x88",
		//            Equipment = "2S LiPo 7.4V 1300mAh battery, charger, spare propellers (4 pcs.)," +
		//                        " propeller replacement tool, USB cable, screwdriver," +
		//                        " silicone propeller gaskets (4 pcs.)",
		//            FullWeight = 877,
		//            MaxFlightDistance = 300,
		//            MobileOSSupport = string.Empty,
		//            NumberOfMotors = 4,
		//            Price = 89m,
		//            Quantity = 35,
		//            Sensors = "gyroscope",
		//            ShortDescription = "Quadcopter MJX Bugs 8",
		//            TypeOfFlightControl = "Radio",
		//            Weight = 370,
		//            Brand = "MJX"
		//        },
		//        new Multicopter()
		//        { 
		//            CameraId = 3,
		//            BatteryId = 3,
		//            Description = "Quadcopter Ryze Tech Tello",
		//            FullDescription = "Quadcopter Ryze Tech Tello",
		//            Dimensions = "98x92.5x41",
		//            Equipment = "3.8V 1100mAh battery, spare propellers (two pairs)," +
		//                        " protection for propellers, tool for removing propellers",
		//            FullWeight = 510,
		//            MaxFlightDistance = 100,
		//            MobileOSSupport = "Android, iOS",
		//            NumberOfMotors = 4,
		//            Price = 130m,
		//            Quantity = 14,
		//            Sensors = "magnetometer, accelerometer, ultrasonic sensor," +
		//                      " barometer, visual positioning sensor, infrared sensor, gyroscope",
		//            ShortDescription = "Quadcopter Ryze Tech Tello",
		//            TypeOfFlightControl = "Wi-Fi, radio",
		//            Weight = 87,
		//            Brand = "Ryze Tech"
		//        }
		//    };
		//}

		//private static IEnumerable<Battery> GetBatteries()
		//{
		//    return new Battery[]
		//    {
		//        new Battery()
		//        {
		//            Capacity = 2375,
		//            Description = "built into the case",
		//            Voltage = 12.0
		//        },
		//        new Battery()
		//        {
		//            Capacity = 1300,
		//            Description = "batteries",
		//            Voltage = 7.4
		//        },
		//        new Battery()
		//        {
		//            Capacity = 1100,
		//            Voltage = 3.8
		//        }
		//    };
		//}

		//private static IEnumerable<Camera> GetCameras()
		//{
		//    return new Camera[]
		//    {
		//        new Camera()
		//        {
		//            Description = "built into the case",
		//            MegaPixels = 12.0,
		//            IsControllable = true
		//        },
		//        new Camera()
		//        {
		//            Description = "possible connection"
		//        },
		//        new Camera()
		//        {
		//            Description = "built into the case",
		//            MegaPixels = 5.0,
		//            IsControllable = false
		//        }
		//    };
		//}
	}
}
