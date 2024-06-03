using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public GameObject startSection;
    public GameObject[] obstacles = new GameObject[2];
    public GameObject[] mirrors = new GameObject[2];
    private GameObject[] gen_obstacles = new GameObject[3];
    const float nextDistance = 33.3f;
    readonly float[] obst_x_coord = {-6.739522f, 0.14f, 7.01951f}; 
    bool creatingSection = false;
    int secNum = 1;
    int lane = 1;
    public float speed = 1; 

    public GameObject[] GetObstacles(){
        Debug.Log(gen_obstacles);
        return gen_obstacles;
    }

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false){
            creatingSection = true;
            StartCoroutine(GenerateSection(3, secNum));
            secNum++;
        }
        if(secNum > speed * 5){
            // if(speed >= 1){
                SceneManager.LoadScene(sceneName:"Scenes/Heart-Shaped Box");
            // }
        }
    }

    IEnumerator GenerateSection(float delay, int number){
        // Generating the empty section
        var clone = Instantiate(startSection, new Vector3(0, -3.34f + (float) number / 10000f, number * nextDistance), Quaternion.Euler(new Vector3(0, -180, 0)));
        Destroy(clone, 6 * delay + 1);

        // Randomizing the obstacles
        int color_lane = UnityEngine.Random.Range(0, 2);
        gen_obstacles[lane] = Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[lane], -0.4f, 9.26f + number * nextDistance), Quaternion.identity);
        Destroy(gen_obstacles[lane], 6 * delay + 1);
        color_lane = color_lane * (-1) + 1;

        for(int i_lane = 0; i_lane < 3; i_lane++){
            if(i_lane != lane){
                gen_obstacles[i_lane] = Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[i_lane], -0.4f, 9.26f + number * nextDistance), Quaternion.identity);
                Destroy(gen_obstacles[i_lane], 6 * delay + 1);
            }
        }

        // Randomizing the mirrors
        GameObject[] gen_mirrors = new GameObject[2]; 
        int color_mirror = UnityEngine.Random.Range(0, 2);
        gen_mirrors[0] = Instantiate(mirrors[color_mirror], new Vector3(-8.223f, -1.5f, 21.406f + number * nextDistance), Quaternion.Euler(new Vector3(15, 171.166f, -2.278f)));
        gen_mirrors[0].transform.localScale = new Vector3(1, 0.88f, 1);
        Destroy(gen_mirrors[0], 6 * delay + 1);
        if(color_mirror == color_lane){
            if(lane == 0){
                lane = 1;
            }
            else{
                lane = 0;
            }
        }

        color_mirror = color_mirror * (-1) + 1;
        gen_mirrors[1] = Instantiate(mirrors[color_mirror], new Vector3(0.02f, -1.5f, 21.96f + number * nextDistance), Quaternion.Euler(new Vector3(15, -179.129f, 0.225f)));
        gen_mirrors[1].transform.localScale = new Vector3(1, 0.88f, 1);
        Destroy(gen_mirrors[1], 6 * delay + 1);

        // Updating lane
        if(color_mirror == color_lane){
            if(lane == 2){
                lane = 1;
            }
            else{
                lane = 2;
            }
        }

        yield return new WaitForSeconds(delay);
        creatingSection = false;
    }
}
