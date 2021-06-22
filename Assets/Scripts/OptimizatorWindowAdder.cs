using UnityEngine;
using UnityEditor;

public class OptimizatorWindowAdder : EditorWindow
{
    public Object CurentOptimizatorBox;
    public Object CurentLightSwitcher;


    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Optimizator Window Adder")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        OptimizatorWindowAdder window = (OptimizatorWindowAdder)EditorWindow.GetWindow(typeof(OptimizatorWindowAdder));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Optimizator Box Settings", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        CurentOptimizatorBox = EditorGUILayout.ObjectField(CurentOptimizatorBox, typeof(OptimizatorBox), true);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add this Renderer"))
        {
            OptimizatorBox optimizatorbox = CurentOptimizatorBox as OptimizatorBox;
            if (CurentOptimizatorBox != null)
            {
                optimizatorbox.AddSelectedRenderer(Selection.gameObjects);
            }
        }

        if (GUILayout.Button("Add this Light"))
        {
            OptimizatorBox optimizatorbox = CurentOptimizatorBox as OptimizatorBox;
            if (CurentOptimizatorBox != null)
            {
                optimizatorbox.AddSelectedLights(Selection.gameObjects);
            }
        }

        GUILayout.Label("Light Switcher Settings", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        CurentLightSwitcher = EditorGUILayout.ObjectField(CurentLightSwitcher, typeof(LightSwitcher), true);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add this Renderer to LightSwitcher"))
        {
            LightSwitcher lightswitcher = CurentLightSwitcher as LightSwitcher;

            if (lightswitcher != null)
            {
                lightswitcher.AddSelectedRenderer(Selection.gameObjects);
            }
        }

        if (GUILayout.Button("Add this Light to LightSwitcher"))
        {
            LightSwitcher lightswitcher = CurentLightSwitcher as LightSwitcher;

            if (lightswitcher != null)
            {
                lightswitcher.AddSelectedLights(Selection.gameObjects);
            }
        }

    }
}