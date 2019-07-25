using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(AISight))]
public class AISightEditor : Editor
{
    void OnSceneGUI()
    {
        AISight fow = (AISight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.radius);
        Vector3 viewAngleA = fow.DirfromAngle(-fow.angle / 2, false);
        Vector3 viewAngleB = fow.DirfromAngle(fow.angle / 2, false);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.angle);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.angle);
        Handles.color = Color.red;
        foreach (Transform visibleobjects in fow.visibleObjects)
        {
            Handles.DrawLine(fow.transform.position, visibleobjects.position);
        }

    }
}
