﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "TeaShop/Ingredient")]
public class Ingredient : ScriptableObject 
{
	public string itemName;

	public List<StatData> statData;

	public int GetStat(StatData.StatType stat)
    {
        return statData.FirstOrDefault(data => data.statType == stat).statValue;
    }

	public bool IsValid() //TODO: move this to be an editor check instead
    {
		return !string.IsNullOrEmpty(itemName);
    }
}
