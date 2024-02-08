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
                
            }
            // anim.SetBool("button", false);
    }

    private void OnCollisionEnter(Collision collision){
        collision.gameObject.transform.parent.GetComponentInChildren<Rigidbody>().useGravity = true;
        // GetComponent<Rigidbody>().useGravity = true;
    }
}
