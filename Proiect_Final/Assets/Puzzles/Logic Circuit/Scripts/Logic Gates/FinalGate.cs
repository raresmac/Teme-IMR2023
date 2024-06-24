using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGate : LogicGate
{
    public FinishLevel finishLevel;
    public override void Compute(GameObject changedObject){
        if(changedObject == input1){
            state1 = GetState(input1);
        }
        else{
            state2 = GetState(input2);
        }
        if((state1 && state2) != output){
            output = state1 && state2;
            ChangeMaterial();
            finishLevel.ShowWinMenu();
        }
    }
}