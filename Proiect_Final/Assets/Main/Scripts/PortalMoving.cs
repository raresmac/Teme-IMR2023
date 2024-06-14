using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalMoving : MonoBehaviour
{
    private GameObject[] portals;
    private GameObject[] mirrors;
    public Material[] materials;
    public GameObject canvas;

    private void OnCollisionEnter(Collision collision)
    {
        return;
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            portals = new GameObject[3];
            mirrors = new GameObject[2];

            mirrors[0] = GameObject.FindGameObjectWithTag("MirrorBlue");
            mirrors[1] = GameObject.FindGameObjectWithTag("MirrorRed");

            int nr_max = 1;
            int nr_portals = GameObject.FindGameObjectsWithTag("Portal").Length;
            portals[0] = GameObject.FindGameObjectsWithTag("Portal")[nr_portals - 1];
            if(nr_portals > 1){
                portals[1] = GameObject.FindGameObjectsWithTag("Portal")[nr_portals - 2];
                if(portals[1].transform.position.z - portals[0].transform.position.z < -0.1f){
                    portals[1] = null;
                }
                nr_max = 2;
            }
            if(nr_portals > 2){
                portals[2] = GameObject.FindGameObjectsWithTag("Portal")[nr_portals - 3];
                if(portals[2].transform.position.z - portals[0].transform.position.z < -0.1f){
                    portals[2] = null;
                }
                nr_max = 3;
            }

            Debug.Log("Player hits portal!");
            Material material = GetComponent<Renderer>().material;
            // Debug.Log(material.name);
            int obs_index;
            for(obs_index = 0; obs_index < nr_max; obs_index++){
                // Debug.Log(portals[obs_index].GetComponent<Renderer>().material);
                // Debug.Log(this.GetComponent<Renderer>().material);
                if(portals[obs_index].GetComponent<Renderer>().material == material) break;
            }
            // Debug.Log(obs_index);

            // int correct_path = 0;
            // int order = 0;
            // Debug.Log(material.name);
            // if(material.name == "bluePortal (Instance)" || material.name == "bluePortal" || material.name == "bluePortal (Instance) (Instance)"){
            //     order = 1;
            // }
            // if(mirrors[order].transform.position.x + 8.223f < 0.1){
            //     if(obs_index == 0){
            //         correct_path = 1;
            //     }
            //     else{
            //         correct_path = 0;
            //     }
            // }
            // else{
            //     if(obs_index == 2){
            //         correct_path = 1;
            //     }
            //     else{
            //         correct_path = 2;
            //     }
            // }

            // Debug.Log(correct_path);
            int i = 0;
            for(; i < 3; i++){
                if(i == obs_index) continue;
                if(portals[i] == null) continue;
                Debug.Log("lane " + i);
                Debug.Log(portals[i].GetComponent<Renderer>().material);
                Debug.Log(material);
                if(portals[i].GetComponent<Renderer>().material != material){
                    // real_i = 1;
                    // if(portals[i].transform.position.x < -0.1f){
                    //     real_i = 0;
                    // }
                    // else if(portals[i].transform.position.x > 0.1f){
                    //     real_i = 2;
                    // }
                    // if(real_i == correct_path){
                        Debug.Log("found");
                        Transform parent1 = collision.gameObject.transform.parent;
                        Transform parent2 = parent1.gameObject.transform.parent;
                        Debug.Log(parent2.position);
                        parent2.position = portals[i].transform.position + new Vector3(0, 0, 2f);
                        collision.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                        foreach(GameObject portal in GameObject.FindGameObjectsWithTag("Portal")){
                            Destroy(portal);
                        }
                        break;
                    // }
                }
            }

            // if(i == 3){
            //     Debug.Log("No portal found! You are dead!");
            //     Time.timeScale = 0;
            //     Transform parent1 = collision.gameObject.transform.parent;
            //     Transform parent2 = parent1.gameObject.transform.parent;
            //     parent2.transform.position += new Vector3(0f, 0f, -2f);
            //     Instantiate(canvas, collision.gameObject.transform);
            //     canvas.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            //     canvas.transform.position = new Vector3(0f, 0f, 2f);
            //     canvas.SetActive(true);
            // }
        }
    }
}
