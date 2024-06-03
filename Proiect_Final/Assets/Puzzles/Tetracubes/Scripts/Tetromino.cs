using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public TetrominoCube[] tetrominoCubes;
    public bool isPlaced = false;

    public void FreeCells(TetroGrid tetroGrid){
        foreach(TetrominoCube tetrominoCube in tetrominoCubes){
            tetrominoCube.setPlacedFalse();
        }
        isPlaced = false;
    }
}
