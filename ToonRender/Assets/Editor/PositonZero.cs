using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PositonZero : EditorWindow
{
    public GameObject SelectObject;
    public Vector3 CPosition;
    public bool Together;

    [MenuItem("Window/Position Zero")]
    static void Openwindow()
    {
        PositonZero window = (PositonZero)GetWindow(typeof(PositonZero));
        window.minSize = new Vector2(300, 120);
        window.maxSize = new Vector2(300, 120);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Position : ");

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Object Space Zero", GUILayout.Height(50)))
        {
            MakeOZero();
        }

        if(GUILayout.Button("World Space Zero", GUILayout.Height(50)))
        {
            MakeWZero();
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.LabelField("");

        Together = EditorGUILayout.ToggleLeft(" :  moving with children", Together);
    }

    private void MakeOZero()
    {
        SelectObject = Selection.activeGameObject;
        
        if(SelectObject == null)
        {
            Debug.LogError("No object is selected.");
        }

        if(Together)
        {
            if (SelectObject.transform.parent == null)
            {
                SelectObject.transform.position = Vector3.zero;
            }
            else if (SelectObject.transform.parent != null && SelectObject.transform.childCount != 0)
            {
                SelectObject.transform.position = SelectObject.transform.parent.position;
            }
            else
            {
                SelectObject.transform.position = SelectObject.transform.parent.position;
            }
        }
        else
        {
            if (SelectObject.transform.parent == null)
            {
                if (SelectObject.transform.childCount == 0)
                {
                    SelectObject.transform.position = Vector3.zero;
                }
                else
                {
                    CPosition = SelectObject.transform.GetChild(0).gameObject.transform.position;
                    SelectObject.transform.position = Vector3.zero;
                    SelectObject.transform.GetChild(0).gameObject.transform.position = CPosition;
                }
            }
            else if (SelectObject.transform.parent != null && SelectObject.transform.childCount != 0)
            {
                CPosition = SelectObject.transform.GetChild(0).gameObject.transform.position;
                SelectObject.transform.position = SelectObject.transform.parent.position;
                SelectObject.transform.GetChild(0).gameObject.transform.position = CPosition;
            }
            else
            {
                SelectObject.transform.position = SelectObject.transform.parent.position;
            }
        }
    }

    private void MakeWZero()
    {
        SelectObject = Selection.activeGameObject;

        if (SelectObject == null)
        {
            Debug.LogError("No object is selected.");
        }

        if(Together)
        {
            if (SelectObject.transform.parent == null)
            {
                SelectObject.transform.position = Vector3.zero;
            }
            else if (SelectObject.transform.parent != null && SelectObject.transform.childCount != 0)
            {
                SelectObject.transform.position = Vector3.zero;
            }
            else
            {
                SelectObject.transform.position = Vector3.zero;
            }
        }
        else
        {
            if (SelectObject.transform.parent == null)
            {
                if(SelectObject.transform.childCount == 0)
                {
                    SelectObject.transform.position = Vector3.zero;
                }
                else
                {
                    CPosition = SelectObject.transform.GetChild(0).gameObject.transform.position;
                    SelectObject.transform.position = Vector3.zero;
                    SelectObject.transform.GetChild(0).gameObject.transform.position = CPosition;
                }
            }
            else if (SelectObject.transform.parent != null && SelectObject.transform.childCount != 0)
            {
                CPosition = SelectObject.transform.GetChild(0).gameObject.transform.position;
                SelectObject.transform.position = Vector3.zero;
                SelectObject.transform.GetChild(0).gameObject.transform.position = CPosition;
            }
            else
            {
                SelectObject.transform.position = Vector3.zero;
            }
        }
    }
}
