namespace BDD.Service;

public class PricingService : IPricingService
{
    public decimal GetBasketTotalAmt(Basket basket, decimal discount)
    {
        if (!basket.Products.Any())
            return 0;

        var basketVal = basket.Products.Sum(x => x.Price);

        if (basket.User.IsLoggedIn)
            return basketVal - (basketVal * discount);

        return basketVal;
    }
}