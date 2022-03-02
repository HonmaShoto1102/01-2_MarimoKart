using UnityEditor;
using UnityEngine;

public class ExampleEditorScript : MonoBehaviour
{
    [MenuItem("CreateExamples/3DTexture")]
    static void CreateTexture3D()
    {
        // テクスチャを設定
        int size = 32;
        TextureFormat format = TextureFormat.RGBA32;
        TextureWrapMode wrapMode = TextureWrapMode.Clamp;

        // テクスチャを作成して設定を適用 
        Texture3D texture = new Texture3D(size, size, size, format, false);
        texture.wrapMode = wrapMode;

        // 3D 配列を作成し、カラーデータを保存
        Color[] colors = new Color[size * size * size];

        // 配列に入力。テクスチャの x, y, z 値が赤、青、緑にマッピングされます。 
        float inverseResolution = 1.0f / (size - 1.0f);
        for (int z = 0; z < size; z++)
        {
            int zOffset = z * size * size;
            for (int y = 0; y < size; y++)
            {
                int yOffset = y * size;
                for (int x = 0; x < size; x++)
                {
                    colors[x + yOffset + zOffset] = new Color(x * inverseResolution,
                        y * inverseResolution, z * inverseResolution, 1.0f);
                }
            }
        }

        // テクスチャにカラー値をコピー
        texture.SetPixels(colors);

        // Apply the changes to the texture and upload the updated texture to the GPU
        texture.Apply();

        // テクスチャを Unity プロジェクトに保存
        AssetDatabase.CreateAsset(texture, "Assets/Example3DTexture.asset");
    }
}