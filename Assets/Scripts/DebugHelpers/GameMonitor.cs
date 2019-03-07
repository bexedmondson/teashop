using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GameMonitor
{
#if UNITY_EDITOR

	public static DayState mostRecentDayState;

	public static CurrentCustomer customerHolder;

	[UnityEditor.Callbacks.DidReloadScripts]
	private static void OnScriptsReloaded()
	{
		//grab all day state objects so this can start listening to them all
		DayState[] dayStates = (DayState[])Resources.FindObjectsOfTypeAll(typeof(DayState));
		Debug.Log("[GameMonitor] Found " + dayStates.Length + " DayState objects.");
	}
    
	public static void OnDayStateChanged(DayState dayState)
	{
		mostRecentDayState = dayState;
		EditorWindow.GetWindow(typeof(GameMonitorWindow)).Repaint();
	}

	public static void OnDayStateFlagUpdated()
	{
		EditorWindow.GetWindow(typeof(GameMonitorWindow)).Repaint();
	}

	public static void OnCustomerChanged(CurrentCustomer currentCustomer)
	{
		customerHolder = currentCustomer;
		EditorWindow.GetWindow(typeof(GameMonitorWindow)).Repaint();
	}

#endif
}
