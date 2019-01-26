using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class IngredientPile : MonoBehaviour, IPointerClickHandler
{   
	[SerializeField] private Ingredient ingredientData;

	[SerializeField] private IngredientEditableList currentIngredientList;

	[SerializeField] private SpriteRenderer ingredientSpriteRenderer;

	void Awake()
	{
		ingredientSpriteRenderer.sprite = ingredientData.itemSprite;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		currentIngredientList.SelectIngredient(ingredientData);
	}
}
