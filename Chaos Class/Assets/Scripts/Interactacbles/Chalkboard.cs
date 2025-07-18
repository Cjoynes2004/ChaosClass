using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalkboard : MonoBehaviour
{
    [SerializeField] private Texture2D chalkTexture; // Chalkboard texture
    Renderer boardRenderer;
    private Color chalkColor = Color.black; // Chalk color
    public ScoreManager scoreManager;
    public StressMeter stressMeter;
    public SFXManager sound;
    private int brushRadius = 3;
    private float chalkSoundCooldown = 0.2f;
    private float lastChalkSoundTime = 0f;

    private void Start()
    {
        boardRenderer = GetComponent<Renderer>();

        if (boardRenderer.material.mainTexture == null)
        {
            Debug.LogWarning("No main texture found on Chalkboard material. Creating a new writable texture.");

            chalkTexture = new Texture2D(512, 512, TextureFormat.RGBA32, false);
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

        for (int i = -brushRadius; i <= brushRadius; i++)
        {
            for (int j = -brushRadius; j <= brushRadius; j++)
            {
                // Use a circle check to make the brush circular
                if (i * i + j * j <= brushRadius * brushRadius)
                {
                    int px = Mathf.Clamp(x + i, 0, chalkTexture.width - 1);
                    int py = Mathf.Clamp(y + j, 0, chalkTexture.height - 1);
                    chalkTexture.SetPixel(px, py, chalkColor);
                }
            }
        }

        chalkTexture.Apply();
        scoreManager.IncreaseScore(1);
        if (stressMeter.LevelofStress < stressMeter.MaxAmountofStress)
        {
            stressMeter.DecreaseStress((float)0.03 * Time.deltaTime);

        }
        if (Time.time - lastChalkSoundTime >= chalkSoundCooldown)
        {
            sound.PlayChalkDraw();
            lastChalkSoundTime = Time.time;  // Update the last sound play time
        }
    }
}
