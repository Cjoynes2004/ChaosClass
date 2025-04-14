using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalkboard : MonoBehaviour
{
    [SerializeField] private Texture2D chalkTexture; // Chalkboard texture
    Renderer boardRenderer;
    private Color chalkColor = Color.white; // Chalk color
    public ScoreManager scoreManager;

    private void Start()
    {
        boardRenderer = GetComponent<Renderer>();

        if (boardRenderer.material.mainTexture == null)
        {
            Debug.LogWarning("No main texture found on Chalkboard material. Creating a new writable texture.");

            Vector3 boardSize = boardRenderer.bounds.size; // World space size
            int pixelsPerUnit = 200; // Adjust based on how sharp you want it

            int texWidth = Mathf.RoundToInt(boardSize.x * pixelsPerUnit);
            int texHeight = Mathf.RoundToInt(boardSize.y * pixelsPerUnit);

            chalkTexture = new Texture2D(texWidth, texHeight, TextureFormat.RGBA32, false);
            chalkTexture.wrapMode = TextureWrapMode.Clamp;
            chalkTexture.filterMode = FilterMode.Point;

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
        int x = Mathf.RoundToInt(textureCoord.x * chalkTexture.width);
        int y = Mathf.RoundToInt(textureCoord.y * chalkTexture.height);

        int px = Mathf.Clamp(x, 0, chalkTexture.width - 1);
        int py = Mathf.Clamp(y, 0, chalkTexture.height - 1);

        chalkTexture.SetPixel(px, py, chalkColor);
        chalkTexture.Apply();
        scoreManager.IncreaseScore(1);

    }
}
