using UnityEngine;

public class LightsAndMirrors : MonoBehaviour
{
    // Reference to the Line Renderer component
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.005f; // Set the width of the Line Renderer
        lineRenderer.positionCount = 2; // Set the number of positions of the Line Renderer
        lineRenderer.SetPosition(0, transform.position); // Set the start position of the Line Renderer
        lineRenderer.SetPosition(1, transform.position + transform.forward * 2); // Set the start position of the Line Renderer
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = 2; // Set the number of positions of the Line Renderer
        lineRenderer.SetPosition(0, transform.position); // Set the start position of the Line Renderer
        lineRenderer.SetPosition(1, transform.position + transform.forward * 2); // Set the start position of the Line Renderer
        // Cast a ray from the light source
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)){
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Mirror")){
                hit.collider.GetComponent<Mirror>().drawNewRay(lineRenderer, gameObject, hit);
            }
        }
        else{
            Debug.Log("No hit");
            lineRenderer.positionCount = 2; // Set the number of positions of the Line Renderer
            lineRenderer.SetPosition(1, transform.position + transform.forward * 2); // Set the start position of the Line Renderer
        }
    }
}
