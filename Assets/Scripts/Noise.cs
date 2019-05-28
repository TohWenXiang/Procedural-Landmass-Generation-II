using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int width, int height, float scale)
    {
        float[,] generatedNoiseMap = new float[width, height];

        //handle divide by zero error
        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        //loop through noise map
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Sampling point is divided by scale because at every interger interval the generated perlin value is the same
                float samplingPointX = x / scale;
                float samplingPointY = y / scale;

                //calculate the perlin noise value for current sampling point
                float perlinValue = Mathf.PerlinNoise(samplingPointX, samplingPointY);

                //apply calculated perlin noise value to noise map
                generatedNoiseMap[x, y] = perlinValue;
            }
        }

        return generatedNoiseMap;
    }
}
