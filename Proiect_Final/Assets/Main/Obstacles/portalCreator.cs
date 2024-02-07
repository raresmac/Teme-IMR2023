using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCreator : MonoBehaviour
{
    public GameObject thinCube;
    public Material portal;
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
        Debug.Log("Ray hits the obstacle!");
        if(ray.gameObject.tag == collision.gameObject.tag){
            var thinCubeClone = (GameObject) Instantiate(thinCube, this.transform.position + new Vector3(0f, 0f, -0.51f), this.transform.rotation);
            thinCubeClone.GetComponent<Renderer>().material = portal;
        }
    }
}
