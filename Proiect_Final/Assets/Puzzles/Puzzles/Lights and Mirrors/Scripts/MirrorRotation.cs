using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MirrorRotation : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 1.0f;

    // Reference to the XR Grab Interactable component
    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the XR Grab Interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the rotation event
        grabInteractable.onSelectEnter.AddListener(OnGrab);
    }

    // Called when the object is grabbed
    private void OnGrab(XRBaseInteractor interactor)
    {
        // Subscribe to the rotation input event
        interactor.onSelectUpdate.AddListener(OnRotate);
    }

    // Called when rotation input is detected
    private void OnRotate(XRBaseInteractor interactor)
    {
        // Get input from Oculus controllers
        float rotationInput = interactor.GetControllerAngularVelocity().x;

        // Calculate rotation angle based on input
        float rotationAngle = rotationInput * rotationSpeed * Time.deltaTime;

        // Rotate the mirror around the X-axis
        transform.Rotate(Vector3.right, rotationAngle);
    }
}
