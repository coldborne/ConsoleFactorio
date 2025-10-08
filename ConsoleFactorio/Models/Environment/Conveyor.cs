using System.Numerics;
using ConsoleFactorio.Interfaces;

namespace ConsoleFactorio.Models
{
    public class Conveyor : GameObject, IResourceProvider, IResourceConsumer
    {
        private Conveyor? _to;

        private Resource _resource;
        
        public bool IsEmpty => _resource == null;

        public bool TryPush()
        {
            if (_resource == null)
            {
                return false;
            }

            if (_to == null)
            {
                return false;
            }

            bool canProvide = _to.TryTake(_resource);

            if (canProvide == false)
            {
                return false;
            }
            
            _resource = null;
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

        public bool TryTake(Resource resource)
        {
            if (_resource != null)
            {
                return false;
            }

            _resource = resource;
            return true;
        }

        public override void TakeAction()
        {
            TryPush();
        }
    }
}