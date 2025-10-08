using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models;

public class Factory : GameObject, IResourceConsumer, IResourceProvider
{
    private Resource _resource;
    
    public bool IsEmpty => _resource == null;
    
    public bool TryTake(Resource resource)
    {
        if (IsEmpty == false)
        {
            return false;
        }

        _resource = resource;
        return true;
    }

    public bool TryProvide(out Resource resource)
    {
        resource = null;
            
        if (_resource == null)
        {
            return false;
        }
            
        resource = _resource;
        _resource = null;
        return true;
    }
    
    public override void TakeAction()
    {
        new Resource();
    }
}