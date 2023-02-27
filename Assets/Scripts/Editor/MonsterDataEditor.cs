using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if ((target as MonsterData).appeareance != null)
        {
            EditorGUILayout.LabelField(new GUIContent((target as MonsterData).appeareance.texture), GUILayout.Width(200),  GUILayout.Height(300));
        }
    }
}
