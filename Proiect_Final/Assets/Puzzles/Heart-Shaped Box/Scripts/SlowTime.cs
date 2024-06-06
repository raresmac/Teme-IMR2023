using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SlowTime : MonoBehaviour
{
    private Rigidbody rb;
    
    public float minTimeScale = 0.1f;
    public float maxTimeScale = 1.0f;
    public float movementThreshold = 0.1f;

    void Start(){
        rb = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<Rigidbody>();
    }

    void Update(){
        // Debug.Log("Total movement: " + rb.velocity.magnitude);

        // Calculate new time scale based on movement
        float newTimeScale = Mathf.Lerp(minTimeScale, maxTimeScale, rb.velocity.magnitude);
        Time.timeScale = Mathf.Clamp(newTimeScale, minTimeScale, maxTimeScale);
    }
}
