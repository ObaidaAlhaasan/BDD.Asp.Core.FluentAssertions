namespace BDD.Service;

public class User
{
    public string Name { get; set; }

    public bool IsLoggedIn { get; private set; }
    public Basket Basket { get; private set; }

    public User(string name)
    {
        Name = name;
        Basket = new Basket(this);
    }

    public void SetBasket(Basket basket)
    {
        Basket = basket;
    }

    public void SetIsLoggedIn(bool isLoggedIn)
    {
        IsLoggedIn = isLoggedIn;
    }
}