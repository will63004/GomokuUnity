using UnityEngine;

namespace UnityExtension
{
    public static class UnityExtension
    {
        public static void SetActiveAfterCheck(this GameObject target, bool isActive)
        {
            if (target == null)
            {
                Debug.LogError("Trying to Access a Null object");
                return;
            }

            if (target.activeSelf == isActive)
                return;

            target.SetActive(isActive);
        }
    }
}


