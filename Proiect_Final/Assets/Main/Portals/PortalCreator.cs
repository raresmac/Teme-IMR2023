using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCreator : MonoBehaviour
{
    public GameObject thinCube;
    public GameObject canvas;
    public Material portalMat;
    private GameObject thinCubeClone;
    public GameObject ray;
    // Start is called before the first frame update
    void Start()
    {
        thinCubeClone = null;
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
        else if(thinCubeClone == null && collision.gameObject.tag == "Player"){
            Debug.Log("You hit a wall! You are dead!");
            Time.timeScale = 0;
            Transform parent1 = collision.gameObject.transform.parent;
            Transform parent2 = parent1.gameObject.transform.parent;
            parent2.transform.position += new Vector3(0f, 0f, -2f);
            Instantiate(canvas, collision.gameObject.transform);
            canvas.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            canvas.transform.position = new Vector3(0f, 0f, 2f);
            canvas.SetActive(true);
        }
    }

    public GameObject getClone(){
        return thinCubeClone;
    }
}
