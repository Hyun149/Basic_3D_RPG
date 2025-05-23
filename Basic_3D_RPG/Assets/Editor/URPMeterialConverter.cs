using UnityEditor;
using UnityEngine;

/// <summary>
/// ������Ʈ ��ü�� Standard ���̴� ��Ƽ������ URP/Lit���� ��ȯ�ϴ� ��ƿ��Ƽ
/// </summary>
public class URPMaterialConverter
{
    [MenuItem("Tools/URP/Upgrade All Standard Materials to URP Lit")]
    private static void UpgradeMaterialsToURP()
    {
        string[] materialGuids = AssetDatabase.FindAssets("t:Material");

        int convertedCount = 0;
        foreach (string guid in materialGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat.shader.name == "Standard")
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                Debug.Log($"Converted: {path}");
                convertedCount++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("��ȯ �Ϸ�", $"{convertedCount}���� ��Ƽ������ URP�� ��ȯ�߽��ϴ�.", "Ȯ��");
    }
}
