using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBox : MonoBehaviour
{
    GameObject levelControl;
    Vector3 initialPosition;

    void Start(){
        levelControl = GameObject.FindGameObjectWithTag(Tags.LevelControl);
        initialPosition = transform.position;
    }

    void Update(){
        if(Vector3.Distance(transform.position, initialPosition) > 1.5f){
            Time.timeScale = 1;
            levelControl.GetComponent<FinishLevel>().ShowWinMenu();
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Finish")){
            Time.timeScale = 1;
            levelControl.GetComponent<FinishLevel>().ShowWinMenu();
        }
    }
}
