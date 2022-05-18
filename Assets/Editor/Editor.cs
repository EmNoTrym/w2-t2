using UnityEngine;
using UnityEditor;

public class Editor : EditorWindow
{ 

    [MenuItem("Window/Change waypoint location")]
    public static void ShowWindow()
    {
        GetWindow<Editor>("Change waypoint location");
    }

    private void OnGUI()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            float x = obj.transform.position.x;
            float y = obj.transform.position.y;
            float z = obj.transform.position.z;
            GUILayout.Label(obj.name, EditorStyles.boldLabel);
            x = EditorGUILayout.FloatField("X", x);
            y = EditorGUILayout.FloatField("Y", y);
            z = EditorGUILayout.FloatField("Z", z);
            obj.transform.position = new Vector3(x, y, z);
        }
    }

}
