using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGravity : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision){
        if(this.transform.parent.tag != "Finish" && collision.gameObject.tag == "GameController"){
            this.GetComponent<Rigidbody>().useGravity = true;
            // foreach(Transform child in transform.parent.transform){
                // if(child.name == "Heart") continue;
                // child.GetComponent<Rigidbody>().useGravity = true;
            // }
            this.transform.parent.tag = "Finish";
            Debug.Log("Activated gravity!");
        }
        else if(collision.gameObject.tag == "GameController" && Time.timeScale > 0.3f){
            SceneManager.LoadScene(sceneName:"Heart-Shaped Box");
        }
    }
}
