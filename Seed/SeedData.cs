using JoiDelivery.Models;

namespace JoiDelivery.Seed;

public static class SeedData
{
    private static readonly Random random = new Random();

    public static Dictionary<string, Cart> CartForUsers { get; } = new()
    {
        { "user101", CreateCartForUser("user101", "John", "Doe", "cart101") },
        { "user102", CreateCartForUser("user102", "Rachel", "Zane", "cart102") }
    };

    public static GroceryStore Store101 { get { return CreateStore("Fresh Picks", "store101"); } }
    public static GroceryStore Store102 { get { return CreateStore("Natural Choice", "store102"); } }
    public static User User101 { get; } = CreateUser("user101", "John", "Doe");
    public static User User102 { get; } = CreateUser("user102", "Joe", "Dan");
    public static List<GroceryProduct> GroceryProducts { get; } =
    [
        CreateGroceryProduct("Wheat Bread", "product101", Store101),
        CreateGroceryProduct("Spinach", "product102", Store101),
        CreateGroceryProduct("Crackers", "product103", Store101)
    ];

    public static List<User> Users { get; } = [User101];

    private static Cart CreateCartForUser(String userId, String firstName, String lastName, string cartId)
    {
        return new Cart
        {
            Id = cartId,
            Outlet = Store101,
            User = CreateUser(userId, firstName, lastName),
        };
    }

    private static GroceryStore CreateStore(string outletName, string storeId)
    {
        return new GroceryStore
        {
            Name = outletName,
            Id = storeId
        };
    }

    private static User CreateUser(string userId, string firstName, string lastName)
    {
        return new User
        {
            Id = userId,
            FirstName = firstName,
            LastName = lastName,
            Email = $"{firstName}.{lastName}@gmail.com",
            PhoneNumber = GetRandomNumber(100000000, 900000000).ToString()
        };
    }

    private static int GetRandomNumber(int min, int max)
    {
        return random.Next(min, max);
    }

    private static GroceryProduct CreateGroceryProduct(string productName, string productId, GroceryStore store)
    {
        return new GroceryProduct
        {
            Name = productName,
            Id = productId,
            MaxRecommendedPrice = 10.5f,
            Weight = 500.00f,
            Store = store,
            Threshold = 10,
            AvailableStock = 30
        };
    }
}