using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public void drawNewRay(LineRenderer lineRenderer, GameObject previousMirror, RaycastHit oldHit){
        int oldPositionCount = lineRenderer.positionCount;
        Vector3 reflectionDirection = Vector3.Reflect(oldHit.normal, transform.up);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, reflectionDirection, out hit)){
            lineRenderer.positionCount = oldPositionCount + 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
            if(hit.collider.gameObject == previousMirror){
                return;
            }
            if (hit.collider.CompareTag("Mirror")){
                hit.collider.GetComponent<Mirror>().drawNewRay(lineRenderer, gameObject, hit);
            }
            else if (hit.collider.CompareTag("MirrorTarget")){
                hit.collider.GetComponent<MirrorTarget>().FinishPuzzle();
            }
        }
        else{
            lineRenderer.positionCount = oldPositionCount + 1;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position + reflectionDirection * 2);
        }
    }   
}
