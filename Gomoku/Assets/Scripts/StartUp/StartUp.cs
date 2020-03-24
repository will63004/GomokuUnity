using GameCore.Game;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private Gomoku gomoku = new Gomoku(50);

    void Start()
    {
        Debug.Log(gomoku.Size);
    }
}
