using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate : MonoBehaviour
{
    public GameObject input1, input2;
    public bool state1 = false, state2 = false;
    public Material onMaterial, offMaterial;
    public bool output;
    public LogicGate[] logicGates;

    void Start(){
        output = false;
        GetComponent<MeshRenderer>().material = offMaterial;
    }

    protected bool GetState(GameObject input){
        if (input == null)
            return false;
        if(input.GetComponent<LogicGate>() != null)
            return input.GetComponent<LogicGate>().output;
        return input.GetComponent<Lightbulb>().output;
    }

    public virtual void Compute(GameObject changedObject){ }

    protected void ChangeMaterial(){
        if (output)
            GetComponent<MeshRenderer>().material = GetComponent<LogicGate>().onMaterial;
        else
            GetComponent<MeshRenderer>().material = GetComponent<LogicGate>().offMaterial;
    }

    protected void ComputeLogicGates(){
        for (int i = 0; i < logicGates.Length; i++){
            if (logicGates[i] != null){
                logicGates[i].Compute(gameObject);
            }
        }
    }
}
