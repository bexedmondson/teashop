using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateProcessFlagObserver : MonoBehaviour
{
    //i hate everything about this class

	//has to be a bloody singleton because you can't get Update() in anything but a monobehaviour
	public static StateProcessFlagObserver instance = null;

	private void Awake()
	{
		if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}


	private Dictionary<Action, List<StateProcessFlag>> observers = new Dictionary<Action, List<StateProcessFlag>> { };

	public void ListenFor(Action OnAllFlagsFinishedAction, List<StateProcessFlag> stateFlags)
	{
		observers.Add(OnAllFlagsFinishedAction, stateFlags);
	}

	private void Update()
	{
		List<Action> toBeRemoved = new List<Action> { };

		foreach (KeyValuePair<Action, List<StateProcessFlag>> observer in observers)
		{
			bool shouldInvokeAction = true;

			//if any flag is still in progress, don't do anything
			for (int i = observer.Value.Count - 1; i >= 0; i--)
			{            
				if (observer.Value[i].progressState == StateProcessFlag.ProgressState.InProgress)
					shouldInvokeAction = false;            
			}

			if (shouldInvokeAction == false)
                break;

			//only call finished action when all the other things are done
			observer.Key();
			toBeRemoved.Add(observer.Key);
		}

		foreach(Action key in toBeRemoved)
    		observers.Remove(key);
	}
}
