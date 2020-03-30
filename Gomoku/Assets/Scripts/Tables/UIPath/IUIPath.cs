using GameCore.Table;

namespace Table
{
    public interface IUIPath : ITable
    {
        string GetPath<T>() where T : class;
    }
}
