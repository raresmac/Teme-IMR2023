using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Runtime.InteropServices;

public class Gradient_Increaser : MonoBehaviour
{
    private float original_time;
    public PostProcessVolume volume;
    UnityEngine.Rendering.PostProcessing.FloatParameter sat;
    private ColorAdjustments b;
    // Start is called before the first frame update
    void Start()
    {
        original_time = Time.time;
        sat = volume.profile.GetSetting<ColorGrading>().saturation;
    }

    // Update is called once per frame
    void Update()
    {
        var new_time = Time.time;
        sat.Interp(sat, -100 + (new_time - original_time) * 1.1f, 0.01f);
        Debug.Log(sat.value);
    }
}
