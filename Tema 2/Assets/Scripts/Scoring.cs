using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scoring : MonoBehaviour
{
    // to be put in Basketball -> XR Grab Interactable -> OnSelectExited
    // and removed from Basketball
    public TextMeshPro score;
    public TextMeshPro lastShot;
    public TextMeshPro bestShot;
    private float maxDistance = 0;
    private int scoreNumber = 0;
    private AudioSource sound;
    private Transform target;
    private Transform positionAtThrow;
    new public Collider collider;
    private float distance;
    bool thrown = true;


    void OnTriggerEnter()
    {
        if(collider.isTrigger){
            thrown = false;
            sound.Play(0);  
            scoreNumber++;
            score.text = "SCORE: " + scoreNumber;
            lastShot.text = "Last shot: " + distance;
            if(distance > maxDistance){
                maxDistance = distance;
                bestShot.text = "Best shot: " + distance;
            }
        }
    }

    void Start()
    {
    
    }

    void Update()
    {
        positionAtThrow = GameObject.FindWithTag("Basketball").transform;
        if(Vector3.Distance(GameObject.FindWithTag("MainCamera").transform.position, positionAtThrow.position) > 5 && thrown){
            Debug.Log(thrown);
            thrown = false;
            sound = GameObject.FindWithTag("MonkeySound").GetComponent<AudioSource>();
            target = GameObject.FindWithTag("Hoops").transform;

            distance = Vector3.Distance(target.position, positionAtThrow.position);
        }
        else if(Vector3.Distance(GameObject.FindWithTag("MainCamera").transform.position, positionAtThrow.position) <= 5){
            thrown = true;
        }
    }
}
