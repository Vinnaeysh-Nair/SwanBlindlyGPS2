using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public Volume volume;
    public VolumeProfile[] profile;
    public static int ID = 0;


    Vignette vignette;
    Bloom bloom;
    ChromaticAberration chrome;

    // Start is called before the first frame update
    void Start()
    {

        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out chrome);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        bloom.intensity.value = Mathf.PingPong(Time.time * 2, 5);
        vignette.intensity.value = Mathf.PingPong(Time.time * 2, 0.7f);
        chrome.intensity.value = Mathf.PingPong(Time.time * 2, 1);
    }
}
