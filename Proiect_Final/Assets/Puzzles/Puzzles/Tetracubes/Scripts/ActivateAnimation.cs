using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0)) {
                setParam();
            }
            // anim.SetBool("button", false);
    }

    void setParam(){
        anim.SetBool("button", true);
    }
}
