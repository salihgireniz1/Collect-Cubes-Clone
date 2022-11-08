using System.Collections.Generic;
using UnityEngine;

public static class Printer
{
    public static List<GameObject> ActiveObjects = new List<GameObject>();
    private static Texture2D texture2D;
    private static Color color;
    private static Vector3 cubePos;

    /// <summary>
    /// Print 3D cubes from image.
    /// </summary>
    /// <param name="image">Sprite object to be printed. 32x32 recommended for performance.</param>
    /// <param name="size">Local scale amount of each cube.</param>
    public static void Print(Sprite image, float size)
    {
        ActiveObjects = new List<GameObject>();
        texture2D = image.texture;
        for (int i = 0; i < texture2D.width; i++)
        {
            for (int j = 0; j < texture2D.height; j++)
            {
                // Set cube positions so center of mass of all cubes will be at the center of holder object.
                // Also scale them according to our desire.
                cubePos = new Vector3(i - (texture2D.width * 0.5f), 0.5f, j - (texture2D.height * 0.5f)) * size;
                color = texture2D.GetPixel(i, j);

                // If the pixel is transparent, do not print it.
                if (color.a == 0)
                {
                    continue;
                }

                GameObject newCube = ObjectPooler.SpawnFromQueue();
                newCube.transform.localPosition = cubePos;
                newCube.transform.localScale = Vector3.one * size;
                newCube.GetComponent<Renderer>().material.color = color;
                ActiveObjects.Add(newCube);
            }
        }
    }
}
