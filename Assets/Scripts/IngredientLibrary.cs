using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientLibrary : MonoBehaviour {

	public List<IngredientData> ingredients;

	public bool IsValid() //TODO: move this to be an editor check instead
    {
		if (ingredients.Count == 0)
            return false;

		foreach (IngredientData i in ingredients)
        {
			if (!i.IsValid())
				return false;

        }

        return true;
    }
}
