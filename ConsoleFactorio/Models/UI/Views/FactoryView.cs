using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class FactoryView : IMappable
{
    private Factory _factory;
    private Direction _direction;
    
    public FactoryView(Factory factory, Direction direction)
    {
        _factory = factory;
        _direction = direction;
    }

    public void TakeAction()
    {
        _factory.TakeAction();
    }

    public char GetSymbol()
    {
        return '#';
    }
}