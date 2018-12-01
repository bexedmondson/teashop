using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour 
{
	public const int k_maxCurrentIngredients = 4;
    
	public List<IngredientData> ingredientMasterList;

	//[HideInInspector]
	public IngredientData[] currentIngredients;

	private void Awake()
	{
		currentIngredients = new IngredientData[k_maxCurrentIngredients] { null, null, null, null };
	}

	public void SelectIngredient(IngredientData selectedIngredient)
	{
		for (int i = 0; i < currentIngredients.Length; i++)
		{
			if (currentIngredients[i] == null)
			{
				currentIngredients[i] = selectedIngredient;
				Game.instance.OnSelectedIngredientsUpdate();
				return;
			}
		}

		Debug.LogWarning("Trying to select too many ingredients!");
	}

	public void DeselectIngredient(IngredientData deselectedIngredient, int index)
	{
		if (currentIngredients[index] != deselectedIngredient)
		{
			Debug.LogError("something has gone terribly wrong");
			return;
		}

		currentIngredients[index] = null;
		Game.instance.OnSelectedIngredientsUpdate();
	}

	public void ClearIngredients()
	{
		for (int i = 0; i < k_maxCurrentIngredients; i++)
		{
			currentIngredients[i] = null;
		}
        Game.instance.OnSelectedIngredientsUpdate();
	}

	public IngredientData[] SelectedIngredients { get { return currentIngredients; } }

	public int NumberOfSelectedIngredients
	{
		get
		{
			int num = 0;
			for (int i = 0; i < currentIngredients.Length; i++)
			{
				if (currentIngredients[i] != null)
					num++;
			}
			return num;
		}
	}
}
