using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
	private readonly List<GameEventListenerMB> eventListenersMB = new List<GameEventListenerMB>();

	private readonly List<GameEventListenerSO> eventListenersSO = new List<GameEventListenerSO>();

    public void Raise()
    {
        for (int i = eventListenersMB.Count - 1; i >= 0; i--)
            eventListenersMB[i].OnEventRaised(this);
        
		for (int i = eventListenersSO.Count - 1; i >= 0; i--)
            eventListenersSO[i].OnEventRaised(this);
    }
    
    public void RegisterListener(GameEventListenerMB listener)
    {
        if (!eventListenersMB.Contains(listener))
            eventListenersMB.Add(listener);
    }

	public void RegisterListener(GameEventListenerSO listener)
    {
        if (!eventListenersSO.Contains(listener))
            eventListenersSO.Add(listener);
    }

    public void UnregisterListener(GameEventListenerMB listener)
    {
        if (eventListenersMB.Contains(listener))
            eventListenersMB.Remove(listener);
    }

	public void UnregisterListener(GameEventListenerSO listener)
    {
        if (eventListenersSO.Contains(listener))
			eventListenersSO.Remove(listener);
    }
}
