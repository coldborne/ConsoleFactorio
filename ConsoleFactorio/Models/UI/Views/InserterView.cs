using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class InserterView : IMappable
{
    private Inserter _inserter;
    private Direction _direction;
    
    public InserterView(Inserter inserter, Direction direction)
    {
        _inserter = inserter;
        _direction = direction;
    }

    public void TakeAction()
    {
        _inserter.TakeAction();
    }

    public char GetSymbol()
    {
        char symbol = '\0';

        switch (_direction)
        {
            case Direction.East:
                symbol = '>';
                break;
            
            case Direction.West:
                symbol = '<';
                break;
            
            case Direction.North:
                symbol = 'ʌ';
                break;
            
            case Direction.South:
                symbol = 'v';
                break;
        }
        
        return symbol;
    }
}