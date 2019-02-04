using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerMB : MonoBehaviour
{
	//TODO make this reorderable
	public List<EventResponsePair> eventResponsePairs;

    private void OnEnable()
    {
        foreach (EventResponsePair pair in eventResponsePairs)
            pair.gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        foreach (EventResponsePair pair in eventResponsePairs)
            pair.gameEvent.UnregisterListener(this);
    }

	public void OnEventRaised(GameEvent gameEvent)
    {
        foreach (EventResponsePair pair in eventResponsePairs)
        {
            if (pair.gameEvent == gameEvent)
                pair.response.Invoke();
        }
    }
}
