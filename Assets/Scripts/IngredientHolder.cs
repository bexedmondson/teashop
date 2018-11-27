using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class IngredientHolder : MonoBehaviour 
{
	[HideInInspector]
	public SpriteRenderer spriteRenderer;

	/*public void OnPointerClick(PointerEventData pointerEventData)
    {
        //TODO: decouple this with events
        Game.instance.IngredientManager.SelectIngredient(ingredientData);
    }*/

	private void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
}
