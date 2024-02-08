using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public GameObject RightController;
    private Vector3 lastPos;
    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.2f;
        lastPos = RightController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1f / 15)
        {
            elapsed = 0f;
            Vector3 newPos = RightController.transform.position;
            float distance = Vector3.Distance(lastPos, newPos);
            Time.timeScale = Math.Min(1, 0.2f + distance / 2);
            // Debug.Log("Time is now " + Time.timeScale);
            lastPos = RightController.transform.position;
            // Debug.Log("LastPos is now " + lastPos);
        }
    }
}
