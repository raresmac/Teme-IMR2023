using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FirePortal : MonoBehaviour
{
    public GameObject portalRay;
    public Transform spawnPoint;
    private ActionBasedController handController;

    void Start(){
        handController = GetComponent<ActionBasedController>();
        handController.activateAction.action.performed += FirePortalRay;
    }

    private void FirePortalRay(InputAction.CallbackContext context){
        float fireSpeed = 30 * LevelControl.speed;
        GameObject newRay = Instantiate(portalRay, spawnPoint.position, spawnPoint.rotation);
        newRay.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fireSpeed);
        Destroy(newRay, 3);
    }
}
