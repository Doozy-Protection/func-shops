using func_shops.Models;

namespace func_shops.Services;

public interface IShopService
{
    Task UpsertShopAsync(Shop shop);
}