using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBox : MonoBehaviour
{
    GameObject levelControl;

    private void Start(){
        levelControl = GameObject.FindGameObjectWithTag(Tags.LevelControl);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Finish")){
            levelControl.GetComponent<FinishLevel>().ShowWinMenu();
        }
    }
}
