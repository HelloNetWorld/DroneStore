using System;
using DroneStore.Core.Entities.Catalog;

namespace DroneStore.Web.Extensions
{
    public static class CatalogItemExtensions
    {
        public static bool IsNew(this CatalogItem source) =>
            (DateTime.UtcNow - source.CreatedinUtc) < TimeSpan.FromDays(14);
    }
}
