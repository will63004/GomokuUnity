using GameCore.DI;
using GameCore.Game;
using GameCore.GameFSM;
using GameView.Scene;
using UnityEngine;


public class StartUp : MonoBehaviour
{
    private Gomoku gomoku = new Gomoku(50);

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(gomoku.Size);
        gomoku.NextTurn(new Coordinate(0, 0));
    }
}
