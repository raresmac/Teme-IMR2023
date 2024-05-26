using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public int maxCapacity = 4;
    public List<LiquidLayer> liquidLayers = new List<LiquidLayer>();
    public GameManager gameManager;
    public int tubeIndex;
    private float[] yCoords = { -0.7f, -0.24f, 0.22f, 0.68f }; 

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(tubeIndex))
        {
            if(gameManager.selectedTube == null)
                SelectTube();
            else if(gameManager.selectedTube == this)
                gameManager.selectedTube = null;
            else
                PourInto();
        }
    }

    public void SelectTube(){
        // Select this tube
        if (liquidLayers.Count > 0){
            gameManager.selectedTube = this;
            Debug.Log("Selected tube: " + tubeIndex);
        }
    }

    public void PourInto(){
        if (!CanPourFrom(gameManager.selectedTube))
            return;

        LiquidLayer topLayer = gameManager.selectedTube.liquidLayers[gameManager.selectedTube.liquidLayers.Count - 1];
        AddLiquidLayer(topLayer);
        gameManager.selectedTube.liquidLayers.RemoveAt(gameManager.selectedTube.liquidLayers.Count - 1);
    }

    public bool CanPourFrom(Tube selectedTube)
    {
        if (liquidLayers.Count == maxCapacity)
            return false;

        if (liquidLayers.Count == 0)
            return true;

        return selectedTube.liquidLayers[selectedTube.liquidLayers.Count - 1].liquidColor == liquidLayers[liquidLayers.Count - 1].liquidColor;
    }

    public void AddLiquidLayer(LiquidLayer liquidLayer){
        liquidLayers.Add(liquidLayer);
        liquidLayer.transform.parent = transform;
        liquidLayer.transform.localPosition = new Vector3(0, yCoords[liquidLayers.Count - 1], 0);
    }
}
