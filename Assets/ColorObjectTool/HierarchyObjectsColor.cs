
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HierarchyColorTool
{
    private static Dictionary<int, Color> coloredObjects =
        new Dictionary<int, Color>();

    const int _Ordernumber = 14;

    static HierarchyColorTool()
    {
        EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchy;
    }

    private static void DrawHierarchy(int instanceID, Rect selectionRect)
    {
        if (!coloredObjects.TryGetValue(instanceID, out Color color))
            return;

        EditorGUI.DrawRect(selectionRect, color);
    }

    private static void SetColor(Color color)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            coloredObjects[obj.GetInstanceID()] = color;
        }

        
        EditorApplication.RepaintHierarchyWindow();
        EditorPrefs.SetString("HierarchyColorTool", JsonUtility.ToJson(new ColorData(coloredObjects)));
    }

    [MenuItem("GameObject/Give color/Set Red", false, _Ordernumber)]
    private static void SetRed()
    {
        SetColor(new Color(1f, 0f, 0f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Blue", false, _Ordernumber + 1)]
    private static void SetBlue()
    {
        SetColor(new Color(0f, 0f, 1f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Green", false, _Ordernumber + 2)]
    private static void SetGreen()
    {
        SetColor(new Color(0f, 1f, 0f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Yellow", false, _Ordernumber + 3)]
    private static void SetYellow()
    {
        SetColor(new Color(1f, 1f, 0f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Orange", false, _Ordernumber + 4)]
    private static void SetOrange()
    {
        SetColor(new Color(1f, 0.5f, 0f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Purple", false, _Ordernumber + 5)]
    private static void SetPurple()
    {
        SetColor(new Color(0.5f, 0f, 1f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Cyan", false, _Ordernumber + 6)]
    private static void SetCyan()
    {
        SetColor(new Color(0f, 1f, 1f, 0.3f));
    }

    [MenuItem("GameObject/Give color/Set Pink", false, _Ordernumber + 7)]
    private static void SetPink()
    {
        SetColor(new Color(1f, 0f, 0.7f, 0.3f));
    }
}
