using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SettingsChange : MonoBehaviour
{
    public ScriptableRendererFeature r;
    public UniversalRendererData fwr;
    // Start is called before the first frame update
    void Start()
    {

        fwr.rendererFeatures[2] = r;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
