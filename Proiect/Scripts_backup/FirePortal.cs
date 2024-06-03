using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePortal : MonoBehaviour
{
    public GameObject portalRay;
    public Transform spawnPoint;
    public float fireSpeed = 100;
    private bool lastState = false;
    [SerializeField] private InputActionProperty triggerAction;

    // Start is called before the first frame update
    void Start(){
        var newRay = (GameObject) Instantiate(portalRay, spawnPoint.position, spawnPoint.rotation);
        newRay.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fireSpeed);
        Destroy(newRay, 5); 
    }

    // Update is called once per frame
    void Update(){
        float triggerValue = triggerAction.action.ReadValue<float>();
        bool triggerBool = false;
        if(triggerValue > 0){
            triggerBool = true;
        }
        if(triggerBool && !lastState){
            lastState = true;
            FirePortalRay();
        }
        else if(!triggerBool){
            lastState = false;
        }
    }    

    public void FirePortalRay(){
        if(portalRay){
            var newRay = (GameObject) Instantiate(portalRay, spawnPoint.position, spawnPoint.rotation);
            newRay.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fireSpeed);
            Destroy(newRay, 3);
        }
    }
}
