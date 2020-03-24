using GameCore.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    private Gomoku gomoku = new Gomoku(50);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gomoku.Size);
    }
}
