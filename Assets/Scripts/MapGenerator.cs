﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //width and height of the map
    public int width;
    public int height;

    //Perlin noise value at each interger interval for sampling point is the same
    //so the sampling point is divide by scale to get a non-interger value
    public float scale;

    public int octaves;
    public float persistance;
    public float lacunarity;

    public bool autoUpdate;

    private MapDisplay theMapDisplay;

    public void GenerateMap()
    {
        //generate noise map using perlin noise
        float[,] generatedNoiseMap = Noise.GenerateNoise(width, height, scale, octaves, persistance, lacunarity);

        //display the map
        theMapDisplay = GetComponent<MapDisplay>();
        theMapDisplay.DrawNoiseMap(generatedNoiseMap);
    }
}
