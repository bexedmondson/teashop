using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class IngredientHolder : MonoBehaviour, IPointerClickHandler
{   
    private IngredientData ingredientData;

	[HideInInspector]
	public SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
	}

	public void OnIngredientSelected(IngredientData ingredient)
	{
		spriteRenderer.sprite = ingredient.itemSprite;
		ingredientData = ingredient;
	}

    public void OnPointerClick(PointerEventData pointerEventData)
    {
		if (ingredientData != null)
		{
			//TODO: decouple this with events
			Game.instance.IngredientManager.DeselectIngredient(ingredientData);

			ingredientData = null;
			spriteRenderer.sprite = null;
		}
    }
}
