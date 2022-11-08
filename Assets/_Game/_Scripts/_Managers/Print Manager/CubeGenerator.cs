using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    private Sprite image;
    private float size;

    private void OnEnable()
    {
        LevelManager.OnNormalLevelGenerated += PrintCubesFromImage;
    }
    private void OnDisable()
    {
        LevelManager.OnNormalLevelGenerated -= PrintCubesFromImage;
    }
    public void PrintCubesFromImage(LevelInfo info)
    {
        image = info.levelImage;
        size = info.cubeSize;
        ObjectPooler.ResetQueue();
        Printer.Print(image, size);
    }
}
