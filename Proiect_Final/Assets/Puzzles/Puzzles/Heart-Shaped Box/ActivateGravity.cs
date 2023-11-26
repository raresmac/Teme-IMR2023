using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(1)) {
                GetComponent<Rigidbody>().useGravity = true;
            }
            // anim.SetBool("button", false);
    }
}
