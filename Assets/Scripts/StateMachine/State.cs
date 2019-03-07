using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : GameEvent 
{
	[SerializeField]
	private List<BoolVariableVerifier> stateAvailabilityFlags = new List<BoolVariableVerifier> { };

	[SerializeField]
	public List<StateProcessFlag> waitForProcessFlags = new List<StateProcessFlag> { }; //TODO how to make this private while debug stuff can access it?

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
    
	public virtual void Activate()
	{
#if UNITY_EDITOR
		Debug.Log("[State] " + this.name);
#endif
        
		if (StateProcessFlagObserver.instance == null)
        {
            Debug.LogError("No StateProcessFlagObserver currently running.");
            return;
        }

		foreach (StateProcessFlag flag in waitForProcessFlags)
			flag.SetInProgress();

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
			if (nextStates[i] == null)
			{
				Debug.LogWarning("Empty next state object found! Check state scriptable objects.");
			}
			else if (nextStates[i].CanBeActivated())
			{
				nextStates[i].Activate();
				return;
			}
		}
	}
}
