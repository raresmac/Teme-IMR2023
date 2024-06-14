using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallRestart : MonoBehaviour
{
    public Generator generator;
    public Wall wall;

    void Start(){
        generator = GameObject.FindGameObjectWithTag(Tags.LevelControl).GetComponent<Generator>();
        wall = transform.parent.gameObject.GetComponent<Wall>();
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
