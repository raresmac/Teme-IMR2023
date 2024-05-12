using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTarget : MonoBehaviour
{
    private Material material;
    private bool isPuzzleFinished = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    
    public void finishPuzzle(){
        material.color = Color.green;
        isPuzzleFinished = true;
    }

    public void resetPuzzle(){
        material.color = Color.white;
    }
}
