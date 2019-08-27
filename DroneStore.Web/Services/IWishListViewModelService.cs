using DroneStore.Web.Models.WishList;

namespace DroneStore.Web.Services
{
	public interface IWishListViewModelService
	{
		WishListViewModel WishList { get; }
		void Add(int itemId);
		void Remove(int itemId);
	}
}
