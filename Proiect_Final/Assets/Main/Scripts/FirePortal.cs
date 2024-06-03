using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePortal : MonoBehaviour
{
    private LevelControl levelControl;
    public GameObject portalRay;
    public Transform spawnPoint;
    public float fireSpeed;
    private ActionBasedController handController;

    void Start(){
        levelControl = LevelControl.instance;
        handController = GetComponent<ActionBasedController>();
        handController.activateAction.action.performed += FirePortalRay;
    }

    private void FirePortalRay(InputAction.CallbackContext context){
        GameObject newRay = Instantiate(portalRay, spawnPoint.position, spawnPoint.rotation);
        newRay.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fireSpeed);
        Destroy(newRay, 3);
    }
}
