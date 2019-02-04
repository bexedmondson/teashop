using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManagerInitialiser : MonoBehaviour 
{
	[SerializeField]
	private DayManager dayManager;

	void Start () 
	{
		dayManager.Init();
	}
}
