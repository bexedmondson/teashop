using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour 
{
	private const int k_maxCurrentIngredients = 4;

	public List<IngredientData> ingredientMasterList;

	private List<IngredientData> currentIngredients = new List<IngredientData> {};

	public void SelectIngredient(IngredientData selectedIngredient)
	{
		if (currentIngredients.Count < k_maxCurrentIngredients)
			currentIngredients.Add(selectedIngredient);
		else
			Debug.LogWarning("Trying to select too many ingredients!");
	}

	public void DeselectIngredient(IngredientData deselectedIngredient)
	{
		currentIngredients.Remove(deselectedIngredient);
	}

	public List<IngredientData> SelectedIngredients { get { return currentIngredients; } }
}
