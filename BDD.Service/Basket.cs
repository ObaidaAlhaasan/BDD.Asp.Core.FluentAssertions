namespace BDD.Service;

public class Basket
{
    public User User { get; set; }
    public List<Product> Products { get; private set; } = new();

    public Basket(User user)
    {
        User = user;
    }
}