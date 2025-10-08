using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class Spawner
{
    private Map _map;

    public Spawner(Map map)
    {
        _map = map;
    }

    public void Spawn(IMappable gameObject, int x, int y)
    {
        _map.Place(gameObject, x, y);
    }
}