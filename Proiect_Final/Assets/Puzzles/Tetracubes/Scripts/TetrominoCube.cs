using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TetrominoCube : MonoBehaviour
{
    public CubeCell cubeCell = null;
    public bool isPlaced = false;

    public void setPlacedTrue(CubeCell cubeCell){
        isPlaced = true;
        cubeCell.SetOcuppiedTrue(this);
        this.cubeCell = cubeCell;
    }

    public void setPlacedFalse(){
        isPlaced = false;
        cubeCell.SetOcuppiedFalse();
        this.cubeCell = null;
    }
}
