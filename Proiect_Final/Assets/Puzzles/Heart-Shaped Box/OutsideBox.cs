using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Finish")){
            Debug.Log("Heart is outside box!");
            SceneManager.LoadScene(0);
        }
    }
}
