using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class Map
{
    private MapView _mapView;
    private IMappable[,] _objects;
    
    public Map(int width, int height)
    {
        _objects = new IMappable[height, width];
        _mapView =  new MapView();
    }

    public void Place(IMappable gameObject, int x, int y)
    {
        int yIndex = y - 1;
        int xIndex = x - 1;
        _objects[yIndex, xIndex] = gameObject;
    }

    public IMappable[,] Get()
    {
        return _objects;
    }
    
    public char[,] ParseToChars()
    {
        char[,] map = new char[_objects.GetLength(0), _objects.GetLength(1)];

        for (int i = 0; i < _objects.GetLength(0); i++)
        {
            for (int j = 0; j < _objects.GetLength(1); j++)
            {
                IMappable gameObject = _objects[i, j];

                if (gameObject != null)
                {
                    map[i, j] = _objects[i, j].GetSymbol();
                }
                else
                {
                    map[i, j] = ' ';
                }
            }
        }
        
        return map;
    }
}