using System.Collections.Generic;
using UnityEngine;
using UnityExtension;

namespace GameView.UI.Plugin
{
    public class UnitGroup<T> : MonoBehaviour
    where T : UnitBase
    {
        [SerializeField]
        private Transform m_unitsRoot;
        [SerializeField]
        private T m_baseUnit;
        protected List<T> m_units = new List<T>();
        public int ShowCount { get; private set; }

        private void Awake()
        {
            m_baseUnit.gameObject.SetActiveAfterCheck(false);
            m_baseUnit.gameObject.SetActiveAfterCheck(false);
        }

        private void CreateCount(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                T unit = Instantiate(m_baseUnit, m_unitsRoot);
                m_units.Add(unit);

                UnitCreated(unit);
            }
        }

        protected virtual void UnitCreated(T unit)
        {

        }

        public void SetShowCount(int count)
        {
            ShowCount = count;

            int unitCount = m_units.Count;
            if (count > unitCount)
                CreateCount(count - unitCount);

            for (int i = 0; i < m_units.Count; ++i)
            {
                UnitBase unit = m_units[i];
                if (i < count)
                {
                    unit.Index = i;
                    unit.gameObject.SetActiveAfterCheck(true);
                }
                else
                {
                    unit.Clear();
                    unit.gameObject.SetActiveAfterCheck(false);
                }
            }
        }
    } 
}