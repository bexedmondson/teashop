using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Ingredients/Ingredient")]
public class Ingredient : ScriptableObject 
{
	public string itemName;

    public Sprite itemSprite;

	public Sprite mixSprite;

	public List<StatData> statData;

	public int GetStat(StatData.StatType stat)
    {
        return statData.FirstOrDefault(data => data.statType == stat).statValue;
    }
}
