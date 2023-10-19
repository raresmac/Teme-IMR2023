using UnityEngine;
using Vuforia;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    // Update is called once per frame
    void Update()
    {
        if (object1 != null && object2 != null)
        {
            // Get the positions of the objects
            Vector3 position1 = object1.transform.position;
            Vector3 position2 = object2.transform.position;

            // Calculate the distance
            float distance = Vector3.Distance(position1, position2);

            Debug.Log("Distance between objects: " + distance + " meters");
        }
    }
}
