using System;
using System.Collections.Generic;
using System.Linq;
using Table;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/UIPath")]
    public class UIPath : ScriptableObject, IUIPath
    {
        [SerializeField]
        private List<UIPathData> list = new List<UIPathData>();

        public string GetPath<T>() where T : class
        {
            string name = typeof(T).Name;
            return list.Where(x => x.typeName == name).FirstOrDefault().path;
        }
    }

    [Serializable]
    public class UIPathData
    {
        public string typeName;
        public string path;
    }
}