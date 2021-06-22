using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OptimizatorBox : MonoBehaviour
{
    public List<Light> ShowLights = new List<Light>();
    public List<Renderer> ShowRenderer = new List<Renderer>();

    public bool PlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInside = true;
            OptimizatorController.Instance.Redraw();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInside = false;
            OptimizatorController.Instance.Redraw();
        }
    }

    public void AddSelectedRenderer(GameObject[] renderergameobject)
    {
        foreach (var selecteon in renderergameobject)
        {
            if (selecteon.TryGetComponent(out Renderer render))
            {
                if (ShowRenderer.Contains(render) == false)
                {
                    ShowRenderer.Add(render);
                }
            }
        }
    }

    public void AddSelectedLights(GameObject[] lightgameobject)
    {
        foreach (var selecteon in lightgameobject)
        {
            if (selecteon.TryGetComponent(out Light light))
            {
                if (ShowLights.Contains(light) == false)
                {
                    ShowLights.Add(light);
                }
            }
        }
    }

    [ContextMenu("Draw Lines")]
    public void DrawLines()
    {
        Color color = new Color(1.0f, 0, 0);
        foreach(var light in ShowLights)
        {
            Debug.DrawLine(transform.position, light.transform.position, color, 10f);
        }
        
    }
}
