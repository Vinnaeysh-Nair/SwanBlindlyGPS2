using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    //intisialing Volume profiles
    public Volume volume;
    public static VolumeProfile[] profiles;
    public static int ID = 0;

    // Getting individual Post FX values 
    Vignette vignette;

    Bloom bloom;
    ChromaticAberration chrome;


    void Start()
    {
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out chrome);
    }

    void FixedUpdate()
    {
        if(volume.profile != profiles[ID])
        {
            volume.profile = profiles[ID];
            volume.profile.TryGet<Bloom>(out bloom);
            volume.profile.TryGet<Vignette>(out vignette);
            volume.profile.TryGet<ChromaticAberration>(out chrome);
        }

        if (ID == 1 && vignette != null)
        {
            vignette.color.value = Color.red;
            vignette.intensity.value  = 1 - (HealthController.currentPlayerHealth/ HealthController.maxPlayerHealth);
        }


        bloom.intensity.value = Mathf.PingPong(Time.time * 2, 5);
        vignette.intensity.value = Mathf.PingPong(Time.time * 2, 0.7f);
        chrome.intensity.value = Mathf.PingPong(Time.time * 2, 1);
    }
}
