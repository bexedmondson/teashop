using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IngredientObject : MonoBehaviour
{   
	private IngredientData ingredientData;

	[SerializeField] private SpriteRenderer ingredientSpriteRenderer;

	public string IngredientName { get { return ingredientData.itemName; } }
    
	public Sprite IngredientSprite { get { return ingredientData.itemSprite; } }

    public int GetStat(StatData.StatType stat)
    {
        return ingredientData.statData.FirstOrDefault(statData => statData.statType == stat).statValue;
    }

	public void AssignDataToObject(IngredientData data)
    {
		ingredientData = data;
		ingredientSpriteRenderer.sprite = ingredientData.itemSprite;
    }
}
