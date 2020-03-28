using GameCore.DI;
using GameView.UI;
using UnityEngine;

public class UIManagerCreator : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        TempDI.UIManager = new UIManager();
    }
}
