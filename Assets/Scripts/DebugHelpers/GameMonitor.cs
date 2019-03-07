using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GameMonitor
{
#if UNITY_EDITOR

	public static string mostRecentDayStateName;

	[UnityEditor.Callbacks.DidReloadScripts]
	private static void OnScriptsReloaded()
	{
		//grab all day state objects so this can start listening to them all
		DayState[] dayStates = (DayState[])Resources.FindObjectsOfTypeAll(typeof(DayState));
		Debug.Log("[GameMonitor] Found " + dayStates.Length + " DayState objects.");
	}
    
	public static void OnDayStateChanged(DayState dayState)
	{
		mostRecentDayStateName = dayState.name;
		EditorWindow.GetWindow(typeof(GameMonitorWindow)).Repaint();
	}

#endif
}
