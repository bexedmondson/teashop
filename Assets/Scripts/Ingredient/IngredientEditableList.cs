using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredients/IngredientEditableList")]
public class IngredientEditableList : ScriptableObject
{
	private List<IngredientData> ingredients = new List<IngredientData> { null, null, null, null };

	[SerializeField] private GameEvent selectedIngredientsChangedEvent;

	public List<IngredientData> GetIngredients()
	{
		return ingredients;
	}

	public IngredientData GetIngredientAtIndex(int index)
	{
		return ingredients[index];
	}

	public void SelectIngredient(IngredientData ingredient)
	{
		for(int i = 0; i < ingredients.Count; i++)
        {
			if (ingredients[i] == null)
            {
				ingredients[i] = ingredient;

                selectedIngredientsChangedEvent.Raise();

                return;
            }
        }

        Debug.LogWarning("Trying to select too many ingredients!");
	}

	public void DeselectIngredient(IngredientData deselectedIngredient, int index)
	{
		if (ingredients[index] != deselectedIngredient)
        {
            Debug.LogError("something has gone terribly wrong");
            return;
        }

        ingredients[index] = null;

		selectedIngredientsChangedEvent.Raise();
	}

	public void Clear()
	{
		for (int i = 0; i < ingredients.Count; i++)
		{
			ingredients[i] = null;
		}

		selectedIngredientsChangedEvent.Raise();
	}

    public int NumberOfIngredients
	{
		get
		{
			return ingredients.Count(x => x != null);
		}
	}
}
