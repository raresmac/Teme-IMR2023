using UnityEngine;

public class TetroGrid : MonoBehaviour
{
    // Size of the grid (number of cells)
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public int gridSizeZ = 3;
    public GameObject instantiated;

    // Size of each grid cell
    public float cellSize = 0.5f;
    private GameObject[][][] gridCubes;

    void Start()
    {
        // Initialize the grid matrix
        gridCubes = new GameObject[gridSizeX][][];
        for (int x = 0; x < gridSizeX; x++)
        {
            gridCubes[x] = new GameObject[gridSizeY][];

            for (int y = 0; y < gridSizeY; y++)
            {
                gridCubes[x][y] = new GameObject[gridSizeZ];
            }
        }

        // Create the grid
        CreateGrid();
    }

    void CreateGrid()
    {
        // Loop through each cell in the grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++){
                    // Draw a semi-transparent cube at the original position
                    gridCubes[x][y][z] = Instantiate(instantiated, this.transform.localPosition, Quaternion.Euler(0, 0, 0), this.transform);

                    // Calculate the position of the cell
                    Vector3 newPos = new Vector3(x * cellSize, y * cellSize, z * cellSize);

                    // Store the position in the gridCells matrix
                    gridCubes[x][y][z].transform.localPosition = newPos;

                    // Set the position and scale of the cube
                    gridCubes[x][y][z].transform.localScale = new Vector3(cellSize, cellSize, cellSize);
                    // Debug.Log("Drawn cube at: " + gridCells[x][y][z]);
                }
            }
        }
    }

    public GameObject getGridCube(int x, int y, int z){
        if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY || z < 0 || z >= gridSizeZ){
            return null;
        }
        return gridCubes[x][y][z];
    }
}
