using DroneStore.Web.Models.ShoppingCart;

namespace DroneStore.Web.Services
{
    public interface IShoppingCartViewModelService
    {
        ShoppingCartViewModel Cart { get; }
        void AddToCard(int itemId, int quantity, string backUrl);
		void ChangeQuantity(int itemId, int quantity, string backUrl);
        void RemoveFromCard(int itemId, int quantity, string backUrl);
        void Clear();
    }
}
