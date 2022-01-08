namespace BDD.Service;

public interface IPricingService
{
    decimal GetBasketTotalAmt(Basket basket, decimal discount);
}