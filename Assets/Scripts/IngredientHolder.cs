using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class IngredientHolder : MonoBehaviour, IPointerClickHandler
{   
    private IngredientData ingredientData;

	[SerializeField]
	private int index;

	[SerializeField]
	private SpriteRenderer ingredientSpriteRenderer;

	public void OnIngredientSelected(IngredientData ingredient)
	{
		ingredientSpriteRenderer.sprite = ingredient.itemSprite;
		ingredientData = ingredient;
	}

    public void OnPointerClick(PointerEventData pointerEventData)
    {
		if (ingredientData != null)
		{
			//TODO: decouple this with events
			Game.instance.IngredientManager.DeselectIngredient(ingredientData, index);
			ClearIngredient();
		}
    }

	public void ClearIngredient()
	{
        ingredientData = null;
        ingredientSpriteRenderer.sprite = null;
	}
}
