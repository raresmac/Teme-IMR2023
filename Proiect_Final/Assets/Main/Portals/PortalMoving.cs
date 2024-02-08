using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalMoving : MonoBehaviour
{
    private GameObject[] portals;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            portals = new GameObject[3];
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
            Material material = this.GetComponent<Renderer>().material;
            Debug.Log(material.name);
            int obs_index;
            for(obs_index = 0; obs_index < nr_max; obs_index++){
                Debug.Log(portals[obs_index].GetComponent<Renderer>().material);
                Debug.Log(this.GetComponent<Renderer>().material);
                if(portals[obs_index].GetComponent<Renderer>().material == material) break;
            }
            Debug.Log(obs_index);
            int i = 0;
            for(; i < nr_max; i++){
                if(i == obs_index) continue;
                if(portals[i] == null) continue;
                Debug.Log("lane " + i);
                Debug.Log(portals[i].GetComponent<Renderer>().material);
                Debug.Log(material);
                if(portals[i].GetComponent<Renderer>().material != material){
                    Debug.Log("found");
                    Transform parent1 = collision.gameObject.transform.parent;
                    Transform parent2 = parent1.gameObject.transform.parent;
                    Debug.Log(parent2.position);
                    parent2.position = portals[i].transform.position + new Vector3(0, 0, 1f);
                    collision.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                }
            }

            if(i == nr_max){
                Debug.Log("No portal found! You are dead!");                
            }
        }
    }
}
