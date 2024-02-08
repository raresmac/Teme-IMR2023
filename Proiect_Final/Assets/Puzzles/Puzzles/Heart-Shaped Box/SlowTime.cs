using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public GameObject RightController;
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.2f;
        lastPos = RightController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = RightController.transform.position;
        float distance = Vector3.Distance(lastPos, newPos);
        Time.timeScale = 0.2f + distance / 10;
        lastPos = RightController.transform.position;
    }
}
