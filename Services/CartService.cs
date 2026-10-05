using JoiDelivery.Dtos;
using JoiDelivery.Models;
using JoiDelivery.Seed;

namespace JoiDelivery.Services;

public class CartService(ProductService productService, UserService userService) : ICartService
{
    private readonly Dictionary<string, Cart> _userCarts = SeedData.CartForUsers;

    public CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest)
    {
        var user = userService.FetchUserById(addProductRequest.UserId);

        if (user == null)
        {
            throw new ArgumentException($"User with ID {addProductRequest.UserId} not found.");
        }

        var cart = FetchCartForUser(user);

        if (cart == null)
        {
            throw new ArgumentException($"Cart for user with ID {addProductRequest.UserId} not found.");
        }

        var product = productService.GetProduct(addProductRequest.ProductId, addProductRequest.OutletId);

        if (product == null)
        {
            throw new ArgumentException($"Product with ID {addProductRequest.ProductId} not found in outlet {addProductRequest.OutletId}.");
        }

        cart.Products ??= [];

        cart.Products.Add(product);

        return new CartProductInfo(cart, product, product.SellingPrice);
    }

    public Cart? GetCartForUser(string userId) =>
        _userCarts.GetValueOrDefault(userId);

    private Cart? FetchCartForUser(User user) =>
        _userCarts.GetValueOrDefault(user.Id);
}