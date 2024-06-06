using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGravity : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag(Tags.GameController)){
            GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("Activated gravity!");
        }
        if(collision.gameObject.CompareTag(Tags.GameController) && Time.timeScale > 0.2f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
