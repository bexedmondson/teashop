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
	public ProgressState progressState;
}
