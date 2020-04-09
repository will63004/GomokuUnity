using GameCore.DI;
using GameCore.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIStartUp : MonoBehaviour, IUIStartUp
{
    [SerializeField]
    private Button login;

    private void Awake()
    {
        login.onClick.AddListener(async delegate
        {
            await TempDI.GameFSM.ChangeFSMAsync(GameCore.GameFSM.eGameFSM.Login);
        });
    }
}
