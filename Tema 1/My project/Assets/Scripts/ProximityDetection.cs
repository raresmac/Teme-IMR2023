using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Vuforia;

public class ProximityDetection : MonoBehaviour
{
    private float distanceAttack = 12.5f;
    private float distanceDead = 8f;
    private Animator myAnim;
    public Transform target;
    public AudioSource sound;
    public TextMeshPro myText;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        dead = false;
        myText.fontSize = 0;
        sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distanceDead)
        {
            if (transform.name == "DogPBR")
            {
                if (!dead)
                {
                    {
                        sound.Play(0);
                        myText.fontSize = 36;
                        dead = true;
                    }
                    myAnim.SetTrigger("DieTrigger");
                    myAnim.ResetTrigger("IdleTrigger");
                    myAnim.ResetTrigger("AttackTrigger");
                }
            }
            else
            {
                myAnim.SetTrigger("DizzyTrigger");
                myAnim.ResetTrigger("IdleTrigger");
                myAnim.ResetTrigger("AttackTrigger");
            }
        }
        else
        {
            myAnim.ResetTrigger("DieTrigger");
            myAnim.ResetTrigger("DizzyTrigger");
            myAnim.SetTrigger("IdleTrigger");

            if (Vector3.Distance(transform.position, target.position) < distanceAttack)
            {
                myAnim.ResetTrigger("IdleTrigger");
                myAnim.SetTrigger("AttackTrigger");
            }
            else
            {
                dead = false;
                myText.fontSize = 0;
                myAnim.ResetTrigger("AttackTrigger");
                myAnim.SetTrigger("IdleTrigger");
            }
        }
    }
}
