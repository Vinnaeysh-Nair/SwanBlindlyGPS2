using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlowingEffect : MonoBehaviour
{
    public Volume volume;

    Bloom bloom;
    
    void Start()
    {
        volume.profile.TryGet<Bloom>(out bloom);
    }

    void FixedUpdate()
    {
        bloom.intensity.value = Mathf.PingPong(Time.time * 1, 0.5f);
    }
}
