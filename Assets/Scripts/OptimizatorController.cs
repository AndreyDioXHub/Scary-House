using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizatorController : MonoBehaviour
{
    
    public List<Light> Lights = new List<Light>();
    public List<Light> _currentLights = new List<Light>();
    public List<Renderer> Renderers = new List<Renderer>();
    public List<Renderer> _currentRenderers = new List<Renderer>();
    public List<OptimizatorBox> OptimizatorBoxes = new List<OptimizatorBox>();

    public static OptimizatorController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Redraw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Redraw()
    {
        _currentLights = new List<Light>();
        _currentRenderers = new List<Renderer>();

        foreach (var optbox in OptimizatorBoxes)
        {

            if (optbox.PlayerInside == true)
            {
                Debug.Log("Player Inside: " + optbox.name);
                foreach (var light in optbox.ShowLights)
                {
                    if (_currentLights.Contains(light) == false)
                    {
                        _currentLights.Add(light);
                    }
                } 

                foreach(var renderer in optbox.ShowRenderer)
                {
                    if (_currentRenderers.Contains(renderer) == false)
                    {
                        _currentRenderers.Add(renderer);
                    }
                }
            }
        }

        foreach(var light in Lights)
        {
            light.enabled = false;
        }

        foreach (var light in _currentLights)
        {
            light.enabled = true;
        }

        foreach (var renderer in Renderers)
        {
            renderer.enabled = false;
        }

        foreach (var renderer in _currentRenderers)
        {
            renderer.enabled = true;
        }
    }

    [ContextMenu("Collect OptimizatorBox")]
    public void CollectOptimizatorBox()
    {
        OptimizatorBoxes.Clear();
        OptimizatorBoxes = new List<OptimizatorBox>();

        var optboxes = FindObjectsOfType<OptimizatorBox>();
        Debug.Log(optboxes.Length);
        foreach (var box in optboxes)
        {
            OptimizatorBoxes.Add(box);
        }
    }

    [ContextMenu("Collect Lights")]
    public void CollectLights()
    {
        Lights.Clear();
        Lights = new List<Light>();

        var lights = FindObjectsOfType<Light>();
        Debug.Log(lights.Length);
        foreach(var light in lights)
        {
            Lights.Add(light);
        }
    }

    [ContextMenu("Collect Renderers")]
    public void CollectRenderers()
    {
        Renderers.Clear();
        Renderers = new List<Renderer>();

        var renderers = FindObjectsOfType<Renderer>();
        Debug.Log(renderers.Length);
        foreach (var renderer in renderers)
        {
            Renderers.Add(renderer);
        }
    }
}
