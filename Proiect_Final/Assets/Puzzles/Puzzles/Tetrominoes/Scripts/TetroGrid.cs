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
    private CubeCell[][][] gridCubes;
    public float[,] boundaries = new float[3,2];

    void Start()
    {
        // Initialize the grid matrix
        gridCubes = new CubeCell[gridSizeX][][];
        for (int x = 0; x < gridSizeX; x++)
        {
            gridCubes[x] = new CubeCell[gridSizeY][];

            for (int y = 0; y < gridSizeY; y++)
            {
                gridCubes[x][y] = new CubeCell[gridSizeZ];
                for (int z = 0; z < gridSizeZ; z++){
                    gridCubes[x][y][z] = new CubeCell();
                }
            }
        }

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
                    // Create a new cube in the cell
                    createCube(x, y, z);

                    // Debug.Log("Drawn cube at: " + gridCubes[x][y][z]);
                }
            }
        }

        // Set the boundaries of the grid
        boundaries[0, 0] = gridCubes[0][0][0].boundaries[0, 0];
        boundaries[0, 1] = gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[0, 1];
        // Debug.Log("Boundaries x: " + gridCubes[0][0][0].boundaries[0, 0] + " " + gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[0, 1]);

        boundaries[1, 0] = gridCubes[0][0][0].boundaries[1, 0];
        boundaries[1, 1] = gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[1, 1];
        // Debug.Log("Boundaries y: " + gridCubes[0][0][0].boundaries[1, 0] + " " + gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[1, 1]);

        boundaries[2, 0] = gridCubes[0][0][0].boundaries[2, 0];
        boundaries[2, 1] = gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[0, 1];
        // Debug.Log("Boundaries z: " + gridCubes[0][0][0].boundaries[2, 0] + " " + gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[2, 1]);
    }

    void createCube(int x, int y, int z){
        // Instantiate the cube
        gridCubes[x][y][z].cubeCell = Instantiate(instantiated, this.transform.localPosition, Quaternion.Euler(0, 0, 0), this.transform);

        // Set the position and scale of the cube
        gridCubes[x][y][z].cubeCell.transform.localPosition = new Vector3(x * cellSize, y * cellSize, z * cellSize);
        gridCubes[x][y][z].cubeCell.transform.localScale = new Vector3(cellSize, cellSize, cellSize);

        // Set the boundaries of the cube
        gridCubes[x][y][z].boundaries[0, 0] = gridCubes[x][y][z].cubeCell.transform.position.x - cellSize / 10;
        gridCubes[x][y][z].boundaries[0, 1] = gridCubes[x][y][z].cubeCell.transform.position.x + cellSize / 10;
        gridCubes[x][y][z].boundaries[1, 0] = gridCubes[x][y][z].cubeCell.transform.position.y - cellSize / 10;
        gridCubes[x][y][z].boundaries[1, 1] = gridCubes[x][y][z].cubeCell.transform.position.y + cellSize / 10;
        gridCubes[x][y][z].boundaries[2, 0] = gridCubes[x][y][z].cubeCell.transform.position.z - cellSize / 10;
        gridCubes[x][y][z].boundaries[2, 1] = gridCubes[x][y][z].cubeCell.transform.position.z + cellSize / 10;
    }

    public CubeCell getGridCube(int x, int y, int z){
        if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY || z < 0 || z >= gridSizeZ){
            return null;
        }
        return gridCubes[x][y][z];
    }

    public bool isInsideGrid(Vector3 position){
        return position.x >= boundaries[0, 0] && position.x <= boundaries[0, 1] &&
               position.y >= boundaries[1, 0] && position.y <= boundaries[1, 1] &&
               position.z >= boundaries[2, 0] && position.z <= boundaries[2, 1];
    }

    public bool isCellFree(int x, int y, int z){
        return gridCubes[x][y][z].isOccupied;
    }
}

public class CubeCell
{
    public GameObject cubeCell;
    public bool isOccupied = false;
    public float[,] boundaries = new float[3,2];

    void Start()
    {
        // Initialize the boundaries matrix
    }
}
