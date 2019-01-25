﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(GameEventListener))]
public class IngredientHolder : MonoBehaviour, IPointerClickHandler
{   
	private IngredientData ingredientData;

    [SerializeField] private IngredientEditableList currentIngredientList;

	[SerializeField] private int index;

	[SerializeField] private SpriteRenderer ingredientSpriteRenderer;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
		if (ingredientData != null)
		{
			currentIngredientList.DeselectIngredient(ingredientData, index);
		}
    }

	public void RefreshIngredientData()
	{
		ingredientData = currentIngredientList.GetIngredientAtIndex(index);
		ingredientSpriteRenderer.sprite = (ingredientData != null) ? ingredientData.itemSprite : null;
	}
}