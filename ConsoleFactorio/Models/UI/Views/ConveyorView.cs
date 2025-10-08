using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class ConveyorView : IMappable
{
    private Conveyor _conveyor;
    private Direction _direction;

    public ConveyorView(Conveyor conveyor, Direction direction)
    {
        _conveyor = conveyor;
        _direction = direction;
    }

    public void TakeAction()
    {
        _conveyor.TakeAction();
    }

    public char GetSymbol()
    {
        char symbol = '\0';

        switch (_direction)
        {
            case Direction.East:
            case Direction.West:
                symbol = '=';
                break;
            
            case Direction.North:
            case Direction.South:
                symbol = '|';
                break;
        }
        
        return symbol;
    }
}