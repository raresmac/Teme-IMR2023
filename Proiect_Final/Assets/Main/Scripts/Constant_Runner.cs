using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_Runner : MonoBehaviour
{
    public Vector3 newTranslate;

    // Update is called once per frame
    void Update(){
        LevelControl.UpdateSpeed();
        newTranslate = LevelControl.speed * Time.deltaTime * Vector3.forward;
        transform.Translate(newTranslate, Space.World);
    }
}
