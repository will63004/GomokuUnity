using UnityEngine;

namespace GameView.UI.Plugin
{
    public class UnitBase : MonoBehaviour
    {
        public int Index { get; set; }

        public virtual void Clear()
        {
            Index = -1;
        }
    } 
}