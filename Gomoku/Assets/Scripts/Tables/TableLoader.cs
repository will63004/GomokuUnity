using GameCore.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Table
{
    public class TableLoader : ITableLoader
    {
        private Dictionary<Type, ITable> tables = new Dictionary<Type, ITable>();

        public async Task LoadAllTableAsync()
        {
            await Task.WhenAll(LoadTableAsync<IUIPath>("Assets/ScriptableObjects/UIPath.asset"));
        }

        private async Task LoadTableAsync<T>(string path) where T : class, ITable
        {
            var so = await Addressables.LoadAssetAsync<ScriptableObject>(path).Task;
            tables.Add(typeof(T), so as T);
        }

        public T GetTable<T>() where T : class, ITable
        {
            if (tables.TryGetValue(typeof(T), out ITable table))
                return table as T;

            throw new Exception($"No have table {typeof(T).Name}");
        }

        public Task<T> GetTableAsync<T>() where T : class, ITable
        {
            throw new System.NotImplementedException();
        }


    }
}