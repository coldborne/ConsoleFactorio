namespace ConsoleFactorio.Models;

public class Inventory
{
    private List<GameObject> _items;
    private int _maxCapacity;

    public Inventory()
    {
        _items = new List<GameObject>();
        _maxCapacity = 10;
    }

    public Inventory(IEnumerable<GameObject> objects)
    {
        _items = new List<GameObject>(objects);
        _maxCapacity = 10;
    }

    public GameObject Take(int index)
    {
        GameObject item = _items[index];
        _items.RemoveAt(index);
        return item;
    }

    public bool Put(GameObject item, int index)
    {
        if (_items.Count + 1 > _maxCapacity)
        {
            return false;
        }
        
        _items.Insert(index, item);
        return true;
    }
    
    public IEnumerable<GameObject> GetItems()
    {
        IEnumerable<GameObject> items = new List<GameObject>(_items);

        foreach (GameObject item in _items)
        {
            //
        }

        return items;
    }
}