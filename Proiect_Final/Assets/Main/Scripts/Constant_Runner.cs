using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_Runner : MonoBehaviour
{
    // Update is called once per frame
    void Update(){
        transform.Translate(LevelControl.speed * Time.deltaTime * Vector3.forward, Space.World);
    }
}
