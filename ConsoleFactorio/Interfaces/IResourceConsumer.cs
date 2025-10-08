using ConsoleRimworld.Models;

namespace ConsoleRimworld.Interfaces
{
    public interface IResourceConsumer
    {
        bool Take(Resource resource);
    }
}