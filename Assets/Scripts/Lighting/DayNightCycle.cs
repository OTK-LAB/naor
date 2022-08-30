using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{

    private Camera cam;
    public float cycleTime;
    private Color dayColor;
    public Color dayTint;
    public Color nightTint;
    public Light2D globalLight;
    public SpriteRenderer stars;
    public VolumeProfile volume;

    public Light2D[] lights;

    void Start()
    {
        cam = GetComponent<Camera>();
        dayColor = cam.backgroundColor;
        if (volume.TryGet<Bloom>(out Bloom bloom))
        {
            bloom.tint.value = dayTint;
        }
    }

    void Update()
    {
        cam.backgroundColor = Color.Lerp(dayColor, Color.black, Mathf.PingPong(Time.time/cycleTime, 1));
        globalLight.intensity = Mathf.Lerp(0.9f, 0.6f, Mathf.PingPong(Time.time / cycleTime, 1));
        stars.color = new Color(stars.color.r, stars.color.g, stars.color.b, Mathf.Lerp(0f, 1f, Mathf.PingPong(Time.time / cycleTime, 1)));
            
        if(volume.TryGet<Bloom>(out Bloom bloom))
        {
            bloom.tint.value = Color.Lerp(dayTint, nightTint, Mathf.PingPong(Time.time / cycleTime, 1));
        }

        foreach (var light in lights)
            light.intensity = Mathf.Lerp(0.15f, 0f, Mathf.PingPong(Time.time / cycleTime, 1));
    }
}