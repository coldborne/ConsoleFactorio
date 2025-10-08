using System.Numerics;
using ConsoleFactorio.Interfaces;
using ConsoleFactorio.Models.Creators;

namespace ConsoleFactorio.Models;

public class Game
{
    private Map _map;

    private Spawner _spawner;
    private Creator _creator;

    private InputReader _inputReader;

    private Player _player;
    private InventoryView _inventoryView;

    private bool _isRunning;

    public Game(Map map, Player player)
    {
        _map = map;

        _player = player;
        _inventoryView = new InventoryView(_player.GetInventory());

        _spawner = new Spawner(_map);
        _creator = new ConveyorCreator();

        _inputReader = new InputReader();

        _isRunning = true;

        Console.CursorVisible = false;
    }

    public void Start()
    {
        Direction direction = Direction.East;

        while (_isRunning)
        {
            ConsoleKeyInfo? consoleKeyInfo = null;

            if (Console.KeyAvailable)
            {
                consoleKeyInfo = _inputReader.Read();
            }

            if (consoleKeyInfo.HasValue && consoleKeyInfo.Value.Key == ConsoleKey.R)
            {
                direction = (Direction)((int)(direction + 1) % Enum.GetValues(typeof(Direction)).Length);
            }

            if (consoleKeyInfo.HasValue && consoleKeyInfo.Value.Key == ConsoleKey.B)
            {
                Vector2 gameObjectCoordinate = GetCoordinates();
                Spawn(direction, (int)gameObjectCoordinate.X, (int)gameObjectCoordinate.Y);
            }

            int itemPosition = 1;

            if (consoleKeyInfo.HasValue && consoleKeyInfo.Value.Key == ConsoleKey.C)
            {
                itemPosition = GetItemPosition();
                GameObject gameObject = GetItem(itemPosition);
                ChangeCreator(gameObject);
            }

            Update();
            Draw(itemPosition);
        }
    }

    private void ChangeCreator(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    private GameObject GetItem(int itemPosition)
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        IMappable[,] objects = _map.Get();

        foreach (IMappable gameObject in objects)
        {
            gameObject?.TakeAction();
        }
    }

    private void Draw(int itemPosition)
    {
        Console.SetCursorPosition(0, 0);
        DrawMap();
        DrawInventory(itemPosition);
    }

    private void DrawMap()
    {
        char[,] objectViewes = _map.ParseToChars();

        for (int i = 0; i < objectViewes.GetLength(0); i++)
        {
            for (int j = 0; j < objectViewes.GetLength(1); j++)
            {
                Console.Write(objectViewes[i, j]);
            }

            Console.WriteLine();
        }
    }

    private void DrawInventory(int itemPosition)
    {
        (int xCursorPosition, int yCursorPosition) = Console.GetCursorPosition();

        int topShift = 5;

        int yInventoryPosition = yCursorPosition + topShift;

        Console.SetCursorPosition(0, yInventoryPosition);

        string itemsText = _inventoryView.GetItems();
        Console.WriteLine(itemsText);
    }

    private void Spawn(Direction direction, int x, int y)
    {
        IMappable gameObject = _creator.Create(direction);
        _spawner.Spawn(gameObject, x, y);
    }

    private Vector2 GetCoordinates()
    {
        (int xCursorPosition, int yCursorPosition) = Console.GetCursorPosition();

        int topShift = 3;

        int yCoordinateRequestPosition = yCursorPosition + topShift;

        Console.SetCursorPosition(0, yCoordinateRequestPosition);

        Console.Write("Введите координаты по x и y через пробел: ");
        string input = Console.ReadLine();
        string[] data = input.Split();

        int xIndex = 0;
        int yIndex = 1;

        int xCoordinate = Convert.ToInt32(data[xIndex]);
        int yCoordinate = Convert.ToInt32(data[yIndex]);

        return new Vector2(xCoordinate, yCoordinate);
    }

    private int GetItemPosition()
    {
        (int xCursorPosition, int yCursorPosition) = Console.GetCursorPosition();

        int topShift = 3;

        int yCoordinateRequestPosition = yCursorPosition + topShift;

        Console.SetCursorPosition(0, yCoordinateRequestPosition);

        Console.Write("Введите позицию предмета для выбора: ");
        string itemPositionText = Console.ReadLine();

        return Convert.ToInt32(itemPositionText);
    }
}