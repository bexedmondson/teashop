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

		//DAY STATE

		if (GameMonitor.mostRecentDayState != null)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Day State: ", EditorStyles.boldLabel);
			GUILayout.Label(GameMonitor.mostRecentDayState.name, GUILayout.ExpandWidth(true));
			GUILayout.EndHorizontal();

			foreach (StateProcessFlag flag in GameMonitor.mostRecentDayState.waitForProcessFlags)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(flag.name, GUILayout.Width(200f));
				GUILayout.Label(flag.State.ToString(), GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal();
			}
		}
		else
		{
			GUILayout.BeginHorizontal();
            GUILayout.Label("Day State: ", EditorStyles.boldLabel);
            GUILayout.Label("Play to get most recent state");
            GUILayout.EndHorizontal();
		}

		GUILayout.Space(30f);

		//CUSTOMER

		if (GameMonitor.customerHolder != null && GameMonitor.customerHolder.customer != null)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Customer: ", EditorStyles.boldLabel);
			GUILayout.Label(GameMonitor.customerHolder.customer.name, GUILayout.ExpandWidth(true));
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.BeginHorizontal();
            GUILayout.Label("Customer: ", EditorStyles.boldLabel);
            GUILayout.Label("Play to get most recent customer");
            GUILayout.EndHorizontal();
		}

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
