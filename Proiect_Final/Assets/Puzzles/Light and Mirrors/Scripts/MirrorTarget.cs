using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTarget : MonoBehaviour
{
    private Material material;
    public FinishLevel finishLevel;

    void Start(){
        material = GetComponent<Renderer>().material;
    }
    
    public void FinishPuzzle(){
        material.color = Color.green;
        finishLevel.ShowWinMenu();
    }

    public void ResetPuzzle(){
        material.color = Color.white;
    }
}
