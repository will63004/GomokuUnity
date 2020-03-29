using GameCore.DI;
using UnityEngine;
using UnityEngine.UI;
using GameCore.UI;

public class UIStartUp : MonoBehaviour, IUIStartUp
{
    [SerializeField]
    private Button login;

    private void Awake()
    {
        login.onClick.AddListener(async delegate
        {
            await TempDI.GameFSM.ChangeFSMAsync(GameCore.GameFSM.eGameFSM.PairRoom);
        });
    }
}
