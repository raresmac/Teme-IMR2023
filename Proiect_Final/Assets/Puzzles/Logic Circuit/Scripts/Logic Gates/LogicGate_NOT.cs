using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate_NOT : LogicGate
{
    void Start(){
        output = true;
        GetComponent<MeshRenderer>().material = onMaterial;
    }

    public override void Compute(GameObject changedObject){
        output = state1;
        state1 = !state1;
        ChangeMaterial();
        ComputeLogicGates();
    }
}
