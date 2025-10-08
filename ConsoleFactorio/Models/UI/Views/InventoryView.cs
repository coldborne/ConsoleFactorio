using System.Text.Json;

namespace ConsoleFactorio.Models;

public class InventoryView
{
    private Inventory _inventory;
    
    public InventoryView(Inventory inventory)
    {
        _inventory = inventory;
    }
    
    public string GetItems()
    {
        IEnumerable<GameObject> items = _inventory.GetItems();
        
        string json = File.ReadAllText(Constants.InventoryItemIconsPath);
        Dictionary<string, string> itemIcons = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

        string inventoryText = "[";
        List<char> itemTexts = new List<char>();
        
        char itemSymbol;

        foreach (GameObject item in items)
        {
            string itemType = item.GetType().Name;
            itemSymbol = Char.Parse(itemIcons[itemType]);
            itemTexts.Add(itemSymbol);
        }

        inventoryText += string.Join(',',itemTexts);
        inventoryText += "]";
        
        return inventoryText;
    }
}