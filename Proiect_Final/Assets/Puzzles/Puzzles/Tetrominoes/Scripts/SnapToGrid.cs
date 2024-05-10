using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToGrid : MonoBehaviour
{
    // Reference to the Grid component
    public TetroGrid tetroGrid;
    private Tetromino tetromino;

    // Maximum distance to snap to the grid
    public float maxSnapDistance = 0.5f;

    // Reference to the XR Grab Interactable component
    private XRGrabInteractable grabInteractable;

    void Start(){
        // Get the XR Grab Interactable component attached to the object
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Get the Tetromino component attached to the object
        tetromino = GetComponent<Tetromino>();

        // Subscribe to the XR Interaction Manager's events
        if (grabInteractable != null){
            grabInteractable.selectEntered.AddListener(OnSelectEntered);
            grabInteractable.selectExited.AddListener(OnSelectExited);
        }

        // If the Grid component is not assigned, try to find it in the scene
        if (tetroGrid == null){
            tetroGrid = FindObjectOfType<TetroGrid>();

            // If Grid component is not found, log a warning
            if (tetroGrid == null){
                Debug.LogError("Grid component not found. Make sure to assign it in the inspector or add it to the scene.");
            }
        }
    }
    
    void Update(){
        // Check if the right mouse button is pressed
        // if (Input.GetMouseButtonDown(1)){
        //     Snap();
        // }
    }

    void OnSelectEntered(SelectEnterEventArgs args){
        // Free the grid cells occupied by the object before moving it if it was placed
        if (tetromino.isPlaced){
            tetromino.FreeCells(tetroGrid);
        }
    }

    void OnSelectExited(SelectExitEventArgs args){
        // Snap the object to the grid after releasing it
        Snap();
    }

    void Snap(){
        CubeCell foundCubeCell = tetroGrid.getCellCoords(transform.position);
        if (foundCubeCell == null || foundCubeCell.isOccupied){
            return;
        }

        Vector3 minPosition = foundCubeCell.cubeCell.transform.position;
        float minDistance = Vector3.Distance(transform.position, minPosition);

        if (minDistance <= maxSnapDistance && TestAllChildren()){
            Debug.Log("Snap to grid");
            ChangePosRos(minPosition);
        }
    }

    void ChangePosRos(Vector3 minPosition){
        transform.position = minPosition;
        float newRotationX = Mathf.Round(transform.rotation.eulerAngles.x / 90) * 90;
        float newRotationY = Mathf.Round(transform.rotation.eulerAngles.y / 90) * 90;
        float newRotationZ = Mathf.Round(transform.rotation.eulerAngles.z / 90) * 90;
        transform.rotation = Quaternion.Euler(newRotationX, newRotationY, newRotationZ);

        // If all the children are inside the grid and the cells are free, occupy them
        TetrominoCube[] blocks =  tetromino.tetrominoCubes;
        foreach(TetrominoCube block in blocks){
            CubeCell foundCubeCell = tetroGrid.getCellCoords(block.transform.position);
            Vector3 coords = foundCubeCell.cubeCell.transform.position;
            block.setPlacedTrue(foundCubeCell);
        }

        tetromino.isPlaced = true;
    }

    bool TestAllChildren(){
        TetrominoCube[] blocks =  tetromino.tetrominoCubes;
        
        // Check if all the children are inside the grid and the cells are free
        foreach(TetrominoCube block in blocks){
            // Debug.Log(block.position);
            CubeCell foundCubeCell = tetroGrid.getCellCoords(block.transform.position);
            if (foundCubeCell == null){
                block.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                return false;
            }
            Vector3 coords = foundCubeCell.cubeCell.transform.position;
            if (coords == new Vector3(-1, -1, -1) || foundCubeCell.isOccupied){
                block.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                return false;
            }
        }
        return true;
    }
}
