using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public GameObject startSection;
    public Transform level;
    public GameObject[] obstacles = new GameObject[2];
    public GameObject[] mirrors = new GameObject[2];
    private const float nextDistance = 33.3f;
    private readonly float[] obst_x_coord = {-6.739522f, 0.14f, 7.01951f}; 
    bool creatingSection = false;
    int secNum = 1;
    public int lane = 1;

    // Update is called once per frame
    void Update(){
        if(creatingSection == false && secNum < LevelControl.maxSections){
            creatingSection = true;
            StartCoroutine(GenerateSection(secNum++));
        }
        else if(secNum == LevelControl.maxSections){
            SceneManager.LoadScene(++LevelControl.currentLevel);
        }
    }

    IEnumerator GenerateSection(int number){
        float delay = LevelControl.generateMultiplier / LevelControl.speed;
        
        // Generating the empty section
        GameObject clone = Instantiate(startSection, new Vector3(0, -3.34f + number / 10000f, number * nextDistance), Quaternion.Euler(new Vector3(0, -180, 0)));
        clone.transform.SetParent(level);
        Destroy(clone, 5 * delay + 1);

        // Randomizing the obstacles
        int color_lane = Random.Range(0, 2);
        GameObject tempObject = Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[lane], -0.4f, 9.26f + number * nextDistance), Quaternion.identity);
        Wall[] walls = new Wall[3];
        int i_wall = 0;
        tempObject.transform.SetParent(clone.transform);
        walls[i_wall++] = tempObject.GetComponent<Wall>();
        tempObject.GetComponent<Wall>().lane = lane;
        Destroy(tempObject, 5 * delay + 1);
        color_lane = color_lane * (-1) + 1;

        for(int i_lane = 0; i_lane < 3; i_lane++){
            if(i_lane != lane){
                tempObject = Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[i_lane], -0.4f, 9.26f + number * nextDistance), Quaternion.identity);
                tempObject.transform.SetParent(clone.transform);
                tempObject.GetComponent<Wall>().lane = i_lane;
                walls[i_wall++] = tempObject.GetComponent<Wall>();
                Destroy(tempObject, 5 * delay + 1);
            }
        }

        // Randomizing the mirrors
        int color_mirror = Random.Range(0, 2);
        tempObject = Instantiate(mirrors[color_mirror], new Vector3(-8.223f, -1.5f, 21.406f + number * nextDistance), Quaternion.Euler(new Vector3(15, 171.166f, -2.278f)));
        tempObject.transform.SetParent(clone.transform);
        Destroy(tempObject, 5 * delay + 1);
        if(color_mirror == color_lane){
            if(lane == 0){
                lane = 1;
            }
            else{
                lane = 0;
            }
        }

        color_mirror = color_mirror * (-1) + 1;
        tempObject = Instantiate(mirrors[color_mirror], new Vector3(0.02f, -1.5f, 21.96f + number * nextDistance), Quaternion.Euler(new Vector3(15, -179.129f, 0.225f)));
        tempObject.transform.SetParent(clone.transform);
        Destroy(tempObject, 5 * delay + 1);

        // Updating lane
        if(color_mirror == color_lane){
            if(lane == 2){
                lane = 1;
            }
            else{
                lane = 2;
            }
        }
        for(int i = 0; i < 3; i++){
            walls[i].correctLane = lane;
            walls[i].checkWalls = new Wall[3];
            walls[i].checkWalls[0] = walls[0];
            walls[i].checkWalls[1] = walls[1];
            walls[i].checkWalls[2] = walls[2];
        }

        yield return new WaitForSeconds(delay);
        creatingSection = false;
    }
}
