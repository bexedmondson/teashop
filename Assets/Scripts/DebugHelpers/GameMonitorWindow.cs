using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class GameMonitorWindow : EditorWindow
{
	[MenuItem("Window/Teashop Monitor")]
	public static void ShowWindow()
    {
		EditorWindow.GetWindow(typeof(GameMonitorWindow));
    }

	private void OnGUI()
	{
		GUILayout.Label(Application.isPlaying ? "CURRENT VALUES" : "MOST RECENT VALUES", EditorStyles.largeLabel);

		GUILayout.BeginHorizontal();
		GUILayout.Label("Day State: ", EditorStyles.boldLabel);
		GUILayout.Label(GameMonitor.mostRecentDayStateName);
		GUILayout.EndHorizontal();

		if (Application.isPlaying)
    		EditorUtility.SetDirty(this);
	}

	private void Awake()
	{
		EditorApplication.playModeStateChanged += LogPlayModeState;
	}

    private void LogPlayModeState(PlayModeStateChange state)
    {
		OnGUI();
    }
}
