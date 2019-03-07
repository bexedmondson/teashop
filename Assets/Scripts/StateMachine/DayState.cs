using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Day State")]
public class DayState : State 
{
	public override void Activate()
	{
		base.Activate();      

#if UNITY_EDITOR
        GameMonitor.OnDayStateChanged(this);
#endif
	}
}
