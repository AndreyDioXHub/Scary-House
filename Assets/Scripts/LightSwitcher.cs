using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> _switcherRenderer = new List<Renderer>();
    [SerializeField]
    private List<GameObject> _switcherLights = new List<GameObject>();
    [SerializeField]
    private Material _LightOn;
    [SerializeField]
    private Material _LightOff;
    
    [SerializeField]
    private bool _lightEnebled = false;

    private void Start()
    {
        SwitchLight();
    }

    public void SwitchLight()
    {
        if(_lightEnebled == true)
        {
            _lightEnebled = false;
            foreach (var renderer in _switcherRenderer)
            {
                renderer.material = _LightOff;
            }
            
            foreach(var light in _switcherLights)
            {
                light.SetActive(false);
            }
        }
        else
        {
            _lightEnebled = true;

            foreach (var renderer in _switcherRenderer)
            {
                renderer.material = _LightOn;
            }

            foreach (var light in _switcherLights)
            {
                light.SetActive(true);
            }
        }
    }

    public void AddSelectedRenderer(GameObject[] renderergameobject)
    {
        foreach (var renderergo in renderergameobject)
        {
            if (renderergo.TryGetComponent(out Renderer renderer))
            {
                if (_switcherRenderer.Contains(renderer) == false)
                {
                    _switcherRenderer.Add(renderer);
                }
            }
        }
    }

    public void AddSelectedLights(GameObject[] lightgameobject)
    {
        foreach (var selecteon in lightgameobject)
        {
            if (_switcherLights.Contains(selecteon) == false)
            {
                _switcherLights.Add(selecteon);
            }
        }
    }
}
