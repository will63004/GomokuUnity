using GameCore.DI;
using GameCore.Game;
using GameCore.GameFSM;
using GameView.Scene;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    [SerializeField]
    private Button login;

    // Start is called before the first frame update
    void Awake()
    {
        login.onClick.AddListener(delegate
        {
            TempDI.GameFSM.ChangeFSMAsync(eGameFSM.PairRoom);
        });
    }
}
