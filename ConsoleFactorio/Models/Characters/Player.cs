namespace ConsoleFactorio.Models;

public class Player
{
    private Inventory _inventory;

    public Player(Inventory inventory)
    {
        _inventory = inventory;
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }
}