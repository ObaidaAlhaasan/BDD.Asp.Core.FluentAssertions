using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDD.Service;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDD.Tests.Behaviour.Steps;

[Binding]
public sealed class LoggedInDiscount
{
    private User User { get; set; }

    private decimal Discount { get; set; } = 0.05m;

    private IPricingService _pricingService = new PricingService();

    [Given(@"a user named (.*) that is not logged in")]
    public void GivenAUserNamedJakThatIsNotLoggedIn(string username)
    {
        User = new User(username);
        User.SetIsLoggedIn(false);
    }

    [Given(@"an empty basket")]
    public void GivenAnEmptyBasket()
    {
        User.SetBasket(new Basket(User));
    }

    [When(@"(.*) added a (.*) to the basket costs (.*)\$")]
    public void WhenUserAddedItemToTheBasketCosts(string userName, string itemName, decimal price)
    {
        User.Basket.Products.Add(new Product {Name = itemName, Price = price});
    }

    [Then(@"the basket value is (.*)\$")]
    public void ThenTheBasketValueIs(int expected)
    {
        _pricingService.GetBasketTotalAmt(User.Basket, Discount).Should().Be(expected);
    }

    [Given(@"a user named (.*) that is logged in")]
    public void GivenAUserNamedMarieThatIsLoggedIn(string username)
    {
        User = new User(username);
        User.SetIsLoggedIn(true);
    }
}