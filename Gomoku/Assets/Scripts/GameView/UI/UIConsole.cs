using UnityEngine;

public class UIConsole : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public void InsertUI(Transform ui)
    {
        ui.SetParent(canvas.transform, false);
    }
}
