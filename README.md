# Welcome to JOI Delivery

## Incorrect setup of dependency injection. Violates SOLID principle.

Incorrect setup of dependency injection. 

Violates the Dependency Inversion Principle (DIP) by tightly coupling high-level modules to low-level modules. 

You should be using interfaces (abstractions) to decouple the components and improve maintainability.

Eg. create an interface for the `CartService` called `ICartService` and have the CartService class implement that interface.

```csharp
public interface ICartService
{
    CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest);
    Cart? GetCartForUser(string userId);
}
```

Wire up the dependency injection container to resolve ICartService to CartService.

```csharp
builder.Services.AddSingleton<ICartService, CartService>();
```

Then, inject the ICartService into the high-level modules instead of directly using the CartService. 

This way, you can easily swap out implementations without affecting the high-level modules.

```csharp
[ApiController]
[Route("[controller]")]
public class CartController(ICartService cartService) : ControllerBase
```