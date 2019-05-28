using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        //if the Inspector is forced to draw again due to variable update
        if (DrawDefaultInspector())
        {
            //check if auto update is on
            if (mapGen.autoUpdate == true)
            {
                //generate map
                mapGen.GenerateMap();
            }
        }

        //if generate map button is clicked
        if (GUILayout.Button("Generate Map"))
        {
            //generate map
            mapGen.GenerateMap();
        }
    }
}
