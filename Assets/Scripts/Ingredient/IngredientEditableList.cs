using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredients/IngredientEditableList")]
public class IngredientEditableList : ScriptableObject
{
	private List<Ingredient> ingredients = new List<Ingredient> { null, null, null, null };

	[SerializeField] private GameEvent selectedIngredientsChangedEvent;

	public List<Ingredient> GetIngredients()
	{
		return ingredients;
	}

	public Ingredient GetIngredientAtIndex(int index)
	{
		return ingredients[index];
	}

	public void SelectIngredient(Ingredient ingredient)
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

	public void DeselectIngredient(Ingredient deselectedIngredient, int index)
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
