using UnityEditor;
using UnityEngine;

/// <summary>
/// 프로젝트 전체의 Standard 셰이더 머티리얼을 URP/Lit으로 변환하는 유틸리티
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

        EditorUtility.DisplayDialog("변환 완료", $"{convertedCount}개의 머티리얼을 URP로 변환했습니다.", "확인");
    }
}
