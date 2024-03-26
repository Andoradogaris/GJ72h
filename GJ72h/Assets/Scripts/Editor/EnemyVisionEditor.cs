using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

[CustomEditor(typeof(Vision))]
public class EnemyVisionEditor : Editor
{
    static MethodInfo _clearConsoleMethod;
    static MethodInfo clearConsoleMethod {
        get {
            if (_clearConsoleMethod == null) {
                Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
                Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
                _clearConsoleMethod = logEntries.GetMethod ("Clear");
            }
            return _clearConsoleMethod;
        }
    }

    public static void ClearLogConsole() {
        clearConsoleMethod.Invoke (new object (), null);
    }
    
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Vision vision = (Vision)target;

        if (GUILayout.Button("Check if target is visible"))
        {
            ClearLogConsole();
            vision.TargetIsVisible();
        }
    }
}
