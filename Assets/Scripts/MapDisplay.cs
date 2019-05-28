using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer theRenderer;

    public void DrawNoiseMap(float[,] noiseMap)
    {
        //get width and height of the noise map
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        //create a new texture of size width and height
        Texture2D newTexture = new Texture2D(width, height);

        //create an array of color to set texture all at once for better performance
        Color[] colors = new Color[width * height];

        //loop through the whole noise map
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //convert two dimension position index to one dimension position index
                //set the color at this position with the noise map value
                colors[(y * width) + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        //apply all the colors at once
        newTexture.SetPixels(colors);

        //apply the changes to the texture
        newTexture.Apply();

        //set this new texture as our new texture
        theRenderer.sharedMaterial.mainTexture = newTexture;

        //resize the map to our new width and height
        theRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
