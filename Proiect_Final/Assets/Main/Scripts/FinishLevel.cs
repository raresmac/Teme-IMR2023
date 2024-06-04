using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class FinishLevel
{
    public static void Finish(){
        LevelControl.Initialize();
        SceneManager.LoadScene(0);
    }
}
