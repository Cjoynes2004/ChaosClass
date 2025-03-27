using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalkboard : MonoBehaviour
{
    [SerializeField] private Texture2D chalkTexture; // Chalkboard texture
    Renderer boardRenderer;
    private Color chalkColor = Color.white; // Chalk color

    private void Start()
    {
        boardRenderer = GetComponent<Renderer>();

        if (boardRenderer.material.mainTexture == null)
        {
            Debug.LogWarning("No main texture found on Chalkboard material. Creating a new writable texture.");

            // Create a new blank texture (white background)
            chalkTexture = new Texture2D(512, 512); // You can adjust the resolution
            Color fillColor = Color.white;
            Color[] pixels = new Color[chalkTexture.width * chalkTexture.height];

            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = fillColor;
            }

            chalkTexture.SetPixels(pixels);
            chalkTexture.Apply();

            // Assign the newly created texture to the material
            boardRenderer.material.mainTexture = chalkTexture;
        }
        else
        {
            // If a texture exists, create a writable copy
            Texture2D sourceTexture = (Texture2D)boardRenderer.material.mainTexture;

            // Create a new blank writable texture
            chalkTexture = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.RGBA32, false);

            // Blit (copy) the source texture to the new writable texture
            RenderTexture rt = new RenderTexture(sourceTexture.width, sourceTexture.height, 0);
            Graphics.Blit(sourceTexture, rt);
            RenderTexture.active = rt;
            chalkTexture.ReadPixels(new Rect(0, 0, sourceTexture.width, sourceTexture.height), 0, 0);
            chalkTexture.Apply();
            RenderTexture.active = null;
            rt.Release();

            // Assign the new texture
            boardRenderer.material.mainTexture = chalkTexture;
        }
    }

    public void Draw(Vector2 textureCoord)
    {
        int x = Mathf.RoundToInt(textureCoord.x * (chalkTexture.width - 1));
        int y = Mathf.RoundToInt(textureCoord.y * (chalkTexture.height - 1));

        Debug.Log($"Drawing at UV: {textureCoord}, Pixel: ({x}, {y})");

        int brushSize = 3; // Adjust for thicker chalk strokes
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                int px = Mathf.Clamp(x + i, 0, chalkTexture.width - 1);
                int py = Mathf.Clamp(y + j, 0, chalkTexture.height - 1);
                chalkTexture.SetPixel(px, py, chalkColor);
            }
        }

        chalkTexture.Apply(); // Apply changes to update the texture
    }
}
