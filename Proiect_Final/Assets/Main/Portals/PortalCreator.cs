using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCreator : MonoBehaviour
{
    public GameObject thinCube;
    public Material portalMat;
    private GameObject thinCubeClone;
    public GameObject ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == ray.gameObject.tag)
        {
            Debug.Log("Ray hits the obstacle!");
            thinCubeClone = (GameObject) Instantiate(thinCube, this.transform.position + new Vector3(0f, 0f, -0.51f), this.transform.rotation);
            thinCubeClone.transform.parent = this.transform;
            thinCubeClone.GetComponent<Renderer>().material = portalMat;
        }
        if(collision.gameObject.tag == "RayLeft" || collision.gameObject.tag == "RayRight"){
            Destroy(collision.gameObject);
        }
    }

    public GameObject getClone(){
        return thinCubeClone;
    }
}
