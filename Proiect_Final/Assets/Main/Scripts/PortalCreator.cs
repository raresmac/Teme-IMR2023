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
    void Start(){
        thinCubeClone = null;
    }

    private void OnCollisionEnter(Collision collision){
        if(ray.CompareTag(collision.gameObject.tag)){
            Debug.Log("Ray hits the obstacle!");
            thinCubeClone = Instantiate(thinCube, transform.position + new Vector3(0f, 0f, -0.51f), transform.rotation);
            thinCubeClone.transform.parent = transform;
            thinCubeClone.GetComponent<Renderer>().material = portalMat;
        }
        if(collision.gameObject.CompareTag(Tags.RayLeft) || collision.gameObject.CompareTag(Tags.RayRight)){
            Destroy(collision.gameObject);
        }
        else if(thinCubeClone == null && collision.gameObject.CompareTag(Tags.Player)){
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
}
