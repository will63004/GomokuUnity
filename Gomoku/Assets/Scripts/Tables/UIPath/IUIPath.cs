using GameCore.Table;
using System;
using System.Collections.Generic;

namespace Table
{
    public interface IUIPath : ITable
    {
        string GetPath<T>() where T : class;
    }
}
