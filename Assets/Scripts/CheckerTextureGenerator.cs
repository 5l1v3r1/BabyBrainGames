using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CheckerTextureGenerator : MonoBehaviour
{
    public int _checkerSize = 16;
    public Color _color1 = Color.white;
    public Color _color2 = Color.black;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateCheckerTexture();
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
        renderer.material.mainTexture.filterMode = FilterMode.Point;
    }

    // Update is called once per frame
    Texture2D GenerateCheckerTexture()
    {
        int textureSize = _checkerSize * 10;
        Texture2D texture = new Texture2D(textureSize*2, textureSize);

        Debug.Log($"Width: {texture.width}");
        Debug.Log($"Height: {texture.height}");

        for (int y = 0 ; y < texture.height; y++ )
        {
            for (int x =  0 ; x < texture.width; x++)
            {
                Color c = (x / _checkerSize) % 2 == 0 ?
                          ((y / _checkerSize) % 2 == 0 ? _color1 : _color2) :
                          ((y / _checkerSize) % 2 == 0  ? _color2 : _color1);
                Debug.Log($"color is: {c}");
                texture.SetPixel(x, y, c);
            }
        }

        texture.Apply();
        return texture;
    }
}
