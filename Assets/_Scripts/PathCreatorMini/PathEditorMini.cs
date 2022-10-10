﻿#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PathCreatorMini), true)]
[InitializeOnLoad]
public class PathEditorMini : Editor
{
    public PathCreatorMini pathTarget
    {
        get
        {
            return (PathCreatorMini)target;
        }
    }

    protected virtual void OnSceneGUI()
    {
        Handles.color = Color.green;
        PathCreatorMini t = (target as PathCreatorMini);

        if (t.originalTransformPositionStatus == false)
        {
            return;
        }

        for (int i = 0; i < t.List_Points.Count; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 oldPoint = t.originalTransformPosition + t.List_Points[i];
            GUIStyle style = new GUIStyle();

            style.normal.textColor = Color.yellow;
            Handles.Label(t.originalTransformPosition + t.List_Points[i] + (Vector3.down * 0.4f) + (Vector3.right * 0.4f), "" + i, style);

            Vector3 newPoint = Handles.FreeMoveHandle(oldPoint, Quaternion.identity, .5f, new Vector3(.25f, .25f, .25f), Handles.CircleHandleCap);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                t.List_Points[i] = newPoint - t.originalTransformPosition;
            }
        }
    }
}

#endif