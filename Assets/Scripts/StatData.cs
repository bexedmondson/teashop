using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatData 
{
	public enum StatType
	{
		Stress,
        Insomnia,
        Inflammation
	}

	public StatType statType;
	public int statValue;
}
