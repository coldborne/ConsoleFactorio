using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class Inserter : GameObject, IResourceConsumer
{
    private IResourceProvider? _from;
    private IResourceConsumer? _to;
    
    private Resource _resource;

    public bool IsEmpty => _resource == null;

    public void Connect(IResourceProvider from,IResourceConsumer to)
    {
        _from = from;
        _to = to;
    }
    
    public void Disconnect()
    {
        _from = null;
        _to = null;
    }
    
    public virtual bool TryTake(Resource resource)
    {
        if (IsEmpty == false)
        {
            return false;
        }

        _resource = resource;
        return true;
    }

    public bool TryCatch()
    {
        if (_from == null)
        {
            return false;
        }
        
        bool canCatch = _from.TryProvide(out Resource resource);

        if (canCatch == false)
        {
            return false;
        }
        
        _resource = resource;
        return true;
    }

    public bool TryGive()
    {
        if (IsEmpty)
        {
            return false;
        }

        if (_to == null)
        {
            return false;
        }

        bool canGive = _to.TryTake(_resource);

        if (canGive == false)
        {
            return false;
        }

        _resource = null;
        return true;
    }

    public char GetSymbol()
    {
        return '>';
    }

    public override void TakeAction()
    {
        if (_resource == null)
        {
            TryCatch();
        }
        else
        {
            TryGive();
        }
    }
}