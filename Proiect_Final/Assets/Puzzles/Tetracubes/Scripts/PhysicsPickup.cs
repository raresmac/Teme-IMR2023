using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(CurrentObject){
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask)){
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    void FixedUpdate(){
        if(CurrentObject){
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
