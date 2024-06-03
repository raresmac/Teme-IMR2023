using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tube : MonoBehaviour
{
    public int maxCapacity = 4;
    public List<LiquidLayer> liquidLayers = new();
    public GameManager gameManager;
    private readonly float minRotation = 105f / 180f;
    private readonly float[] yCoords = { -0.7f, -0.24f, 0.22f, 0.68f }; 
    private XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;

    void Start(){
        // Get reference to the XR Grab Interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the selection events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        // Save the initial position of the tube
        initialPosition = transform.position;
    }

    void Update(){
        // Check for minRotation degrees rotation
        if(gameManager.selectedTube == this)
            if(Mathf.Abs(transform.localRotation.z) > minRotation || Mathf.Abs(transform.localRotation.x) > minRotation){
                if(PourInto())
                    gameManager.CheckFinished();
            }
            else{
                Debug.Log("Rotation: " + transform.localRotation.z + " " + transform.localRotation.x);
            }
    }

    private void OnGrab(SelectEnterEventArgs args){
        SelectTube();
    }

    private void OnRelease(SelectExitEventArgs args){
        DeselectTube();
    }

    private void SelectTube(){
        if (liquidLayers.Count > 0){
            gameManager.selectedTube = this;
        }
    }

    private void DeselectTube(){
        gameManager.selectedTube = null;
        transform.SetPositionAndRotation(initialPosition, Quaternion.identity);
    }

    private bool PourInto(){
        Tube tube = FindTube();
        if(tube == null || !CanPourTo(tube))
            return false;

        LiquidLayer topLayer = liquidLayers[^1];
        tube.AddLiquidLayer(topLayer);
        liquidLayers.Remove(topLayer);
        return true;
    }

    private Tube FindTube(){
        // Get the tube directly under the current tube from the top point
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
            return hit.collider.GetComponent<Tube>();
        return null;
    }

    public bool CanPourTo(Tube tube){
        if (tube.liquidLayers.Count == maxCapacity || liquidLayers.Count == 0)
            return false;

        if (tube.liquidLayers.Count == 0)
            return true;

        return liquidLayers[^1].liquidColor == tube.liquidLayers[^1].liquidColor;
    }

    public void AddLiquidLayer(LiquidLayer liquidLayer){
        liquidLayers.Add(liquidLayer);
        liquidLayer.transform.parent = transform;
        liquidLayer.transform.SetLocalPositionAndRotation(new Vector3(0, yCoords[liquidLayers.Count - 1], 0), Quaternion.identity);
    }
}
