using UnityEditor;
using UnityEngine;
     
public class GuidWindow : EditorWindow
{
    string guid = "";
    string path = "";
    [MenuItem("APIExamples/GUIDToAssetPath")]
    static void CreateWindow()
    {
        GuidWindow window = (GuidWindow)EditorWindow.GetWindowWithRect(typeof(GuidWindow), new Rect(0, 0, 400, 120));
        window.minSize = new Vector2(1000, 1000);

    }
     
    void OnGUI()
    {
        GUILayout.Label("Enter guid");
        guid = GUILayout.TextField(guid);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Get Asset Path",GUILayout.Width(120)))
            path = GetAssetPath(guid);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Abort", GUILayout.Width(120)))
            Close();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Label(path);
    }
    static string GetAssetPath(string guid)
    {
        string p = AssetDatabase.GUIDToAssetPath(guid);
        Debug.Log(p);
        if (p.Length == 0) p = "not found";
        return p;
    }
}