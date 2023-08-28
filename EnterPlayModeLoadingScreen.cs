using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class EnterPlayModeLoadingScreen
{
    private static readonly string loadingScenePath = "Assets/Scenes/LoadingScene.unity";
    
    private static readonly SceneAsset loadingScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(loadingScenePath);
    
    static EnterPlayModeLoadingScreen()
	{
		UnityToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        EditorSceneManager.playModeStartScene = null;
	}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			if(GUILayout.Button(new GUIContent("L", "Start from LoadingScreen"), ToolbarStyles.commandButtonStyle))
			{
                EditorSceneManager.playModeStartScene = loadingScene;
				EditorApplication.EnterPlaymode();
			}
		}
}

static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}
