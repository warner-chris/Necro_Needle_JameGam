using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public static class Debug
{
    public static void Log(string message)
    {
        UnityEngine.Debug.Log("[DEBUG] " + message);
    }
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class CustomEditorWindow : EditorWindow
{
    private bool isChecked;

    [MenuItem("Window/Custom Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomEditorWindow>("Custom Editor Window");
    }

    private void OnGUI()
    {
        GUILayout.Label("Custom Editor Window", EditorStyles.boldLabel);

        // Display a toggle button to set the checked state
        isChecked = EditorGUILayout.Toggle("Is Checked", isChecked);

        // When the toggle button is clicked, perform an action
        if (GUILayout.Button("Apply"))
        {
            // Your custom logic here to perform actions based on the checked state
            Debug.Log("Checked state: " + isChecked);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
