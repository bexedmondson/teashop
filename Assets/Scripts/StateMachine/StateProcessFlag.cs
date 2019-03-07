using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flag/State Process Flag")]
public class StateProcessFlag : ScriptableObject 
{
	public enum ProgressState
	{
		InProgress,
        Finished
	}
    
    [System.NonSerialized]
	private ProgressState progressState;


	//TODO: rework this whole class using nested classes and this https://stackoverflow.com/questions/2816961/how-to-get-access-to-private-members-of-nested-class/2817005#2817005
	//so that only states can set these to in progress, and remove SetInProgress below   
	/*[CreateAssetMenu(menuName = "Flag/TestClass")]
	private class TestClass : ScriptableObject
	{
		public int testInt;
	}*/

	public void SetInProgress()
	{
		progressState = ProgressState.InProgress;
		GameMonitor.OnDayStateChanged(null);
	}

	public void SetFinished()
	{
		progressState = ProgressState.Finished;
		GameMonitor.OnDayStateFlagUpdated();
	}

	public ProgressState State { get { return progressState; } }
}
