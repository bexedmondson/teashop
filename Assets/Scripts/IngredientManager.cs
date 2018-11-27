using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour 
{
	private const int k_maxCurrentIngredients = 4;

	public List<IngredientData> ingredientMasterList;
 
	[HideInInspector]
	public List<IngredientData> currentIngredients = new List<IngredientData> {};

	public void SelectIngredient(IngredientData selectedIngredient)
	{
		if (currentIngredients.Count < k_maxCurrentIngredients)
		{
			currentIngredients.Add(selectedIngredient);
			Game.instance.OnSelectedIngredientsUpdate();
		}
		else
		{
			Debug.LogWarning("Trying to select too many ingredients!");
		}
	}

	public void DeselectIngredient(IngredientData deselectedIngredient)
	{
		currentIngredients.Remove(deselectedIngredient);
		Game.instance.OnSelectedIngredientsUpdate();
	}

	public List<IngredientData> SelectedIngredients { get { return currentIngredients; } }
}
