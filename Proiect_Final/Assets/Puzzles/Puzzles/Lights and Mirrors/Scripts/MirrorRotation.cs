using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MirrorRotation : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 1.0f;

    // Reference to the XR Grab Interactable component
    private XRSimpleInteractable simpleInteractable;

    // Current place of the controller
    private Vector3 currentPlace;

    // Start is called before the first frame update
    void Start()
    {
        currentPlace = Vector3.zero;

        // Get reference to the XR Grab Interactable component
        simpleInteractable = GetComponent<XRSimpleInteractable>();

        // Subscribe to the selection events
        simpleInteractable.selectEntered.AddListener(OnGrab);
        simpleInteractable.selectExited.AddListener(OnRelease);
    }

    // Called when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        currentPlace = simpleInteractable.transform.position;
    }

    // Called when the object is released
    private void OnRelease(SelectExitEventArgs args)
    {
        currentPlace = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlace != Vector3.zero)
        {
            float distance = Vector3.Distance(currentPlace, simpleInteractable.transform.position);
            transform.rotation = Quaternion.Euler(distance * rotationSpeed, 0, 0);
        }
    }
}
