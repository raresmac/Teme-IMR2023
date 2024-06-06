using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tube selectedTube;
    public Tube[] tubes;

    public void CheckFinished(){
        int unfinished = 0;
        foreach (Tube tube in tubes){
            if (tube.liquidLayers.Count != tube.maxCapacity){
                unfinished++;
            }
            else{
                foreach (LiquidLayer layer in tube.liquidLayers){
                    if (layer.liquidColor != tube.liquidLayers[0].liquidColor){
                        unfinished++;
                        break;
                    }
                }
            }
        }

        if (unfinished <= 1){
            Debug.Log("Finished");
            GetComponent<FinishLevel>().ShowWinMenu();
        }
    }
}
