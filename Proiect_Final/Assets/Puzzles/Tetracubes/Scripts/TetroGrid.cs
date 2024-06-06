using UnityEngine;

public class TetroGrid : MonoBehaviour
{
    public FinishLevel finishLevel;
    // Size of the grid (number of cells)
    public int gridSizeX = 5;
    public int gridSizeY = 5;
    public int gridSizeZ = 3;
    public GameObject instantiated;
    public Material occupiedMaterial;
    public Material freeMaterial;


    // Size of each grid cell
    public float cellSize = 0.5f;
    private CubeCell[][][] gridCubes;
    public float[,] boundaries = new float[3,2];

    void Start(){
        // Initialize the grid matrix
        gridCubes = new CubeCell[gridSizeX][][];
        for (int x = 0; x < gridSizeX; x++){
            gridCubes[x] = new CubeCell[gridSizeY][];

            for (int y = 0; y < gridSizeY; y++){
                gridCubes[x][y] = new CubeCell[gridSizeZ];
                for (int z = 0; z < gridSizeZ; z++){
                    gridCubes[x][y][z] = new CubeCell();
                }
            }
        }

        CreateGrid();
    }

    void Update(){
        // Check if the puzzle is solved
        if(CheckSolution()){
            Debug.Log("Puzzle solved!");
            for (int x = 0; x < gridSizeX; x++){
                for (int y = 0; y < gridSizeY; y++){
                    for (int z = 0; z < gridSizeZ; z++){
                        gridCubes[x][y][z].occupier.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                }
            }
            finishLevel.ShowWinMenu();
        }
    }

    void CreateGrid(){
        // Loop through each cell in the grid
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++){
                    // Create a new cube in the cell
                    CreateCube(x, y, z);

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
        boundaries[2, 1] = gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[2, 1];
        // Debug.Log("Boundaries z: " + gridCubes[0][0][0].boundaries[2, 0] + " " + gridCubes[gridSizeX - 1][gridSizeY - 1][gridSizeZ - 1].boundaries[2, 1]);
    }

    void CreateCube(int x, int y, int z){
        // Instantiate the cube
        gridCubes[x][y][z].cubeCell = Instantiate(instantiated, transform.localPosition, Quaternion.Euler(0, 0, 0), transform);
        gridCubes[x][y][z].tetroGrid = this;
        gridCubes[x][y][z].x = x;
        gridCubes[x][y][z].y = y;
        gridCubes[x][y][z].z = z;

        // Set the position and scale of the cube
        gridCubes[x][y][z].cubeCell.transform.localPosition = new Vector3(x * cellSize, y * cellSize, z * cellSize);
        gridCubes[x][y][z].cubeCell.transform.localScale = new Vector3(cellSize, cellSize, cellSize);

        // Set the boundaries of the cube
        gridCubes[x][y][z].boundaries[0, 0] = gridCubes[x][y][z].cubeCell.transform.localPosition.x - cellSize / 2;
        gridCubes[x][y][z].boundaries[0, 1] = gridCubes[x][y][z].cubeCell.transform.localPosition.x + cellSize / 2;
        gridCubes[x][y][z].boundaries[1, 0] = gridCubes[x][y][z].cubeCell.transform.localPosition.y - cellSize / 2;
        gridCubes[x][y][z].boundaries[1, 1] = gridCubes[x][y][z].cubeCell.transform.localPosition.y + cellSize / 2;
        gridCubes[x][y][z].boundaries[2, 0] = gridCubes[x][y][z].cubeCell.transform.localPosition.z - cellSize / 2;
        gridCubes[x][y][z].boundaries[2, 1] = gridCubes[x][y][z].cubeCell.transform.localPosition.z + cellSize / 2;
        // Debug.Log("Boundaries for cube "+ x + y + z + ": " + gridCubes[x][y][z].boundaries[0, 0] + " " + gridCubes[x][y][z].boundaries[0, 1] + " " + gridCubes[x][y][z].boundaries[1, 0] + " " + gridCubes[x][y][z].boundaries[1, 1] + " " + gridCubes[x][y][z].boundaries[2, 0] + " " + gridCubes[x][y][z].boundaries[2, 1]);
    }

    public CubeCell GetGridCube(int x, int y, int z){
        if (x < 0 || x >= gridSizeX || y < 0 || y >= gridSizeY || z < 0 || z >= gridSizeZ){
            return null;
        }
        return gridCubes[x][y][z];
    }

    public bool IsInsideGrid(Vector3 position){
        return position.x >= boundaries[0, 0] && position.x <= boundaries[0, 1] &&
               position.y >= boundaries[1, 0] && position.y <= boundaries[1, 1] &&
               position.z >= boundaries[2, 0] && position.z <= boundaries[2, 1];
    }

    public bool IsCellOccupied(int x, int y, int z){
        if(GetGridCube(x, y, z) == null){
            return true;
        }
        return gridCubes[x][y][z].isOccupied;
    }

    public CubeCell getCellCoords(Vector3 position){
        position -= transform.position;
        if (!IsInsideGrid(position)){
            // Debug.Log("Position is not inside the grid");
            return null;
        }
        int cubeCellX = (int)Mathf.Round(position.x / cellSize);
        int cubeCellY = (int)Mathf.Round(position.y / cellSize);
        int cubeCellZ = (int)Mathf.Round(position.z / cellSize);
        return gridCubes[cubeCellX][cubeCellY][cubeCellZ];
    }

    bool CheckSolution(){
        // Check if the grid is full
        for (int x = 0; x < gridSizeX; x++){
            for (int y = 0; y < gridSizeY; y++){
                for (int z = 0; z < gridSizeZ; z++){
                    if (!gridCubes[x][y][z].isOccupied){
                        gridCubes[x][y][z].cubeCell.GetComponent<MeshRenderer>().material = freeMaterial;
                        return false;
                    }
                }
            }
        }

        // If the grid is full, the puzzle is solved
        for (int x = 0; x < gridSizeX; x++){
            for (int y = 0; y < gridSizeY; y++){
                for (int z = 0; z < gridSizeZ; z++){
                    gridCubes[x][y][z].occupier.gameObject.GetComponent<MeshRenderer>().material = occupiedMaterial;
                }
            }
        }
        return true;
    }
}

public class CubeCell
{
    public GameObject cubeCell;
    public TetroGrid tetroGrid;
    public bool isOccupied = false;
    public TetrominoCube occupier = null;
    public float[,] boundaries = new float[3,2];
    public int x, y, z;

    public void SetOcuppiedTrue(TetrominoCube occupier){
        isOccupied = true;
        this.occupier = occupier;
    }

    public void SetOcuppiedFalse(){
        isOccupied = false;
        occupier = null;
    }
}
