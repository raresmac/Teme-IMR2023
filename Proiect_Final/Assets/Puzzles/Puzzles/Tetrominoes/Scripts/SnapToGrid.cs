using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToGrid : MonoBehaviour
{
    // Reference to the Grid component
    public TetroGrid tetroGrid;

    // Maximum distance to snap to the grid
    public float maxSnapDistance = 0.5f;
    public Vector3 snapOffset = Vector3.zero;

    // Tetromino-specific variables
    private int[] squares;

    // Reference to the XR Grab Interactable component
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Get the XR Grab Interactable component attached to the object
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the XR Interaction Manager's events
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnSelectExited);
        }

        // If the Grid component is not assigned, try to find it in the scene
        if (tetroGrid == null)
        {
            tetroGrid = FindObjectOfType<TetroGrid>();

            // If Grid component is not found, log a warning
            if (tetroGrid == null)
            {
                Debug.LogError("Grid component not found. Make sure to assign it in the inspector or add it to the scene.");
            }
        }

        squares = new int[3];
        if (this.name == "tetromino1" || this.name == "tetromino1 (1)"){
            squares[0] = 2;
            squares[1] = 1;
            squares[2] = 0;
        } else if (this.name == "tetromino2" || this.name == "tetromino2 (1)"){
            squares[0] = 3;
            squares[1] = 0;
            squares[2] = 0;
        } else if (this.name == "tetromino3" || this.name == "tetromino3 (1)"){
            squares[0] = 3;
            squares[1] = 1;
            squares[2] = 0;
        } else if (this.name == "tetromino4" || this.name == "tetromino4 (1)"){
            squares[0] = 3;
            squares[1] = -1;
            squares[2] = 0;
        } else if (this.name == "tetromino_chair1" || this.name == "tetromino_chair1 (1)"){
            squares[0] = 2;
            squares[1] = 1;
            squares[2] = 0;
        } else if (this.name == "tetromino_chair2" || this.name == "tetromino_chair2 (1)"){
            squares[0] = 1;
            squares[1] = 2;
            squares[2] = 0;
        }
        else{
            Debug.LogWarning("Tetromino not recognized");
        }
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        // Snap the object to the grid after releasing it
        Snap();
    }

    void Snap()
    {
        // Calculate the nearest grid cell position based on the cells from the TetroGrid component
        float minDistance = Mathf.Infinity;
        Vector3 minPosition = Vector3.zero;
        for(int i = 0; i < tetroGrid.gridSizeX; i++){
            for(int j = 0; j < tetroGrid.gridSizeY; j++){
                for(int k = 0; k < tetroGrid.gridSizeZ; k++){
                    if (tetroGrid.getGridCube(i + squares[0], j +squares[1], k + squares[2]) != null){
                        Vector3 cellPosition = tetroGrid.getGridCube(i, j, k).transform.position;
                        if(Vector3.Distance(transform.position + snapOffset, cellPosition) < minDistance){
                            minDistance = Vector3.Distance(transform.position + snapOffset, cellPosition);
                            minPosition = cellPosition;
                        }
                    }
                }
            }
        }

        if (minDistance <= maxSnapDistance)
        {
            transform.position = minPosition;
            float newRotationX = Mathf.Round(transform.rotation.eulerAngles.x / 90) * 90;
            float newRotationY = Mathf.Round(transform.rotation.eulerAngles.y / 90) * 90;
            float newRotationZ = Mathf.Round(transform.rotation.eulerAngles.z / 90) * 90;
            transform.rotation = Quaternion.Euler(newRotationX, newRotationY, newRotationZ);
        }
    }
}
