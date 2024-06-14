using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int lane;
    public int correctLane;
    public GameObject XRRig;
    public Material portal = null;
    public Generator generator;
    public Wall[] checkWalls;

    void Start(){
        generator = GameObject.FindGameObjectWithTag(Tags.LevelControl).GetComponent<Generator>();
        XRRig = GameObject.FindGameObjectWithTag(Tags.GameController);
    }

    private void OnCollisionEnter(Collision collision){
        if(!LevelControl.debugDeath && collision.gameObject.CompareTag(Tags.Player) && portal == null){
            gameObject.GetComponent<FinishLevel>().ShowLossMenu();
        }
        else if(portal != null && collision.gameObject.CompareTag(Tags.Player)){
            foreach(Wall wall in checkWalls){
                if(wall.portal != null && wall.portal != portal){
                    if(wall.lane == correctLane){
                        XRRig.transform.position = wall.transform.position + new Vector3(0, 0, 2f);
                        XRRig.transform.GetChild(0).GetChild(1).localPosition = new Vector3(0, 0.025f, 0);
                        XRRig.transform.GetChild(0).GetChild(2).localPosition = new Vector3(0, 0.025f, 0);
                        foreach(GameObject portal in GameObject.FindGameObjectsWithTag("Portal")){
                            Destroy(portal);
                        }
                        return;
                    }
                }
            }
            gameObject.GetComponent<FinishLevel>().ShowLossMenu();
        }
    }
}
