using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lightbulb : MonoBehaviour
{
    public bool output;
    public Material onMaterial, offMaterial;
    private XRSimpleInteractable simpleInteractable;
    public LogicGate[] logicGates;

    void Start(){
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);

        output = false;
        GetComponent<MeshRenderer>().material = offMaterial;
    }

    void Update(){
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1)){
            ChangeState();
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args){
        ChangeState();
    }

    private void ChangeState(){
        output = !output;
        if (output)
            GetComponent<MeshRenderer>().material = onMaterial;
        else
            GetComponent<MeshRenderer>().material = offMaterial;
        ComputeLogicGates();
    }

    private void ComputeLogicGates(){
        for (int i = 0; i < logicGates.Length; i++){
            if (logicGates[i] != null){
                logicGates[i].Compute(gameObject);
            }
        }
    }
}
