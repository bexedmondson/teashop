using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : GameEvent 
{
	[SerializeField]
	private List<BoolVariableVerifier> stateAvailabilityFlags = new List<BoolVariableVerifier> { };

	[SerializeField]
	private List<StateProcessFlag> waitForProcessFlags = new List<StateProcessFlag> { };

	[SerializeField]
	private List<State> nextStates = new List<State> { };
    
	public bool CanBeActivated()
	{
		//if any flag is still unavailable, return false
		for (int i = stateAvailabilityFlags.Count - 1; i >= 0; i--)
        {
			if (!stateAvailabilityFlags[i].Verify())
                return false;
        }

		return true;
	}
    
	public void Activate()
	{      
        if (StateProcessFlagObserver.instance == null)
        {
            Debug.Log("No StateProcessFlagObserver currently running.");
            return;
        }

		Raise();

		if (waitForProcessFlags.Count > 0)
			StateProcessFlagObserver.instance.ListenFor(Transition, waitForProcessFlags);
		else
			Transition();
	}

	public void Transition()
	{   
		for (int i = 0; i < nextStates.Count; i++)
		{
			if (nextStates[i].CanBeActivated())
			{
				nextStates[i].Activate();
				return;
			}
		}
	}
}
