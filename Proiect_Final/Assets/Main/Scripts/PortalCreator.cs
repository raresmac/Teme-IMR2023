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
            gameObject.GetComponent<Wall>().portal = portalMat;
        }
        if(collision.gameObject.CompareTag(Tags.RayLeft) || collision.gameObject.CompareTag(Tags.RayRight)){
            Destroy(collision.gameObject);
        }
    }
}
