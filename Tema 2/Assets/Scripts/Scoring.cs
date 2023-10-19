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


    void OnTriggerEnter()
    {
        if(collider.isTrigger){
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
        Debug.Log("Object was thrown");
        sound = GameObject.FindWithTag("MonkeySound").GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Hoops").transform;
        positionAtThrow = GameObject.FindWithTag("Basketball").transform;

        distance = Vector3.Distance(target.position, positionAtThrow.position);
    }

    void Update()
    {
        
    }
}
