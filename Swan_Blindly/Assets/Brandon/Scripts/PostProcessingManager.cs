using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        Bloom bloom;

        if(volume.profile.TryGet<Bloom>(out bloom))
        {
            bloom.intensity.value = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
