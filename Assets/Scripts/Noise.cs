using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    /*
     *      Width:          map's width
     *      Height:         map's height
     *      Scale:          it is used to divide against the sampling position since perlin noise value is the same at every interger interval.
     *      Octaves:        number of noise map that is stacked on top of each other.
     *      Persistance:    controls the amplitude of the octave. diminishing in effect for each subsequent octaves. range from zero to one.
     *      Lacunarity:     controls the frequency of the octave. increasing in effect for each subsequent octaves.
     */

    public static float[,] GenerateNoise(int width, int height, float scale, int octaves, float persistance, float lacunarity)
    {
        //create a new 2 dimensional float array of size with and height, this represents the noise map
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
                //at the start amplitude and frequency are initialize to the power of one because any power of one is one.
                float amplitude = 1.0f;
                float frequency = 1.0f;
                float combinedHeightValue = 0.0f;

                //loop through all the octaves
                for (int i = 0; i < octaves; i++)
                {
                    //Sampling point is divided by scale because at every interger interval the generated perlin value is the same
                    //frequency affect how spread out each sampling points are.
                    float samplingPointX = x / (scale * frequency);
                    float samplingPointY = y / (scale * frequency);

                    //calculate the perlin noise value for current sampling point
                    float perlinValue = Mathf.PerlinNoise(samplingPointX, samplingPointY);

                    //amplitude affects the height of each perlin value.
                    //perlin value for each octaves are combined together
                    combinedHeightValue += perlinValue * amplitude;

                    //amplitude and frequency are increasing in power per octaves.
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                //apply calculated perlin noise value to noise map
                generatedNoiseMap[x, y] = combinedHeightValue;
            }
        }

        return generatedNoiseMap;
    }
}
