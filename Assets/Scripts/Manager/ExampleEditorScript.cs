using UnityEditor;
using UnityEngine;

public class ExampleEditorScript : MonoBehaviour
{
    [MenuItem("CreateExamples/3DTexture")]
    static void CreateTexture3D()
    {
        // �e�N�X�`����ݒ�
        int size = 32;
        TextureFormat format = TextureFormat.RGBA32;
        TextureWrapMode wrapMode = TextureWrapMode.Clamp;

        // �e�N�X�`�����쐬���Đݒ��K�p 
        Texture3D texture = new Texture3D(size, size, size, format, false);
        texture.wrapMode = wrapMode;

        // 3D �z����쐬���A�J���[�f�[�^��ۑ�
        Color[] colors = new Color[size * size * size];

        // �z��ɓ��́B�e�N�X�`���� x, y, z �l���ԁA�A�΂Ƀ}�b�s���O����܂��B 
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

        // �e�N�X�`���ɃJ���[�l���R�s�[
        texture.SetPixels(colors);

        // Apply the changes to the texture and upload the updated texture to the GPU
        texture.Apply();

        // �e�N�X�`���� Unity �v���W�F�N�g�ɕۑ�
        AssetDatabase.CreateAsset(texture, "Assets/Example3DTexture.asset");
    }
}