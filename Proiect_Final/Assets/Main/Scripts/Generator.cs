using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject startSection;
    public GameObject[] obstacles = new GameObject[2];
    public GameObject[] mirrors = new GameObject[2];
    const float nextDistance = 33.3f;
    readonly float[] obst_x_coord = {-6.739522f, 0.1399937f, 7.01951f}; 
    bool creatingSection = false;
    int secNum = 1;
    int lane = 1;
    public float speed = 1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false){
            creatingSection = true;
            StartCoroutine(GenerateSection(1, secNum));
            secNum++;
        }
    }

    IEnumerator GenerateSection(int delay, int number)
    {
        // Generating the empty section
        var clone = (GameObject) Instantiate(startSection, new Vector3(0, (float) number / 10000f, number * nextDistance), Quaternion.Euler(new Vector3(0, -180, 0)));
        Destroy(clone, 3);

        // Randomizing the obstacles
        GameObject[] gen_obstacles = new GameObject[3]; 
        int color_lane = UnityEngine.Random.Range(0, 2);
        gen_obstacles[lane] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[lane], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
        Destroy(gen_obstacles[lane], 3);
        color_lane = color_lane * (-1) + 1;

        if(lane == 0){
            gen_obstacles[1] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[1], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[1], 3);
            gen_obstacles[2] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[2], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[2], 3);
        }
        else if(lane == 1){
            gen_obstacles[0] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[0], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[0], 3);
            gen_obstacles[2] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[2], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[2], 3);
        }
        else{
            gen_obstacles[0] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[0], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[0], 3);
            gen_obstacles[1] = (GameObject) Instantiate(obstacles[color_lane], new Vector3(obst_x_coord[1], 2.93f, 9.26f + number * nextDistance), Quaternion.identity);
            Destroy(gen_obstacles[1], 3);
        }

        // Randomizing the mirrors
        GameObject[] gen_mirrors = new GameObject[2]; 
        int color_mirror = UnityEngine.Random.Range(0, 2);
        gen_mirrors[0] = (GameObject) Instantiate(mirrors[color_mirror], new Vector3(-8.223f, 1.84f, 21.406f + number * nextDistance), Quaternion.Euler(new Vector3(15, 171.166f, -2.278f)));
        gen_mirrors[0].transform.localScale = new Vector3(1, 0.88f, 1);
        Destroy(gen_mirrors[0], 3);
        if(color_mirror == color_lane){
            if(lane == 0){
                lane = 1;
            }
            else{
                lane = 0;
            }
        }

        color_mirror = color_mirror * (-1) + 1;
        gen_mirrors[1] = (GameObject) Instantiate(mirrors[color_mirror], new Vector3(0.02f, 2.37f, 21.96f + number * nextDistance), Quaternion.Euler(new Vector3(15, -179.129f, 0.225f)));
        gen_mirrors[1].transform.localScale = new Vector3(1, 0.88f, 1);
        Destroy(gen_mirrors[1], 3);
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
