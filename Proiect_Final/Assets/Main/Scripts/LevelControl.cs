using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public static LevelControl instance;
    public int currentLevel = 0;
    public float speed = 1.0f;
    public float nextDistance = 33.3f;

    private void Awake(){
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
