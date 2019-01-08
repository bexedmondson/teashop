﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IPointerClickHandler, IDragHandler
{
	[SerializeField]
	private Rigidbody2D[] mixRigidbodies;

	[SerializeField]
	private SpriteRenderer[] mixSprites;

	private const float k_forceMultiplier = 0.01f;
	private const float k_teaSpinAmountTarget = 10000f;

	private float teaSpinAmountTotal = 0f;

	public void OnDrag(PointerEventData eventData)
	{
		foreach (Rigidbody2D mixRigidbody in mixRigidbodies)
			mixRigidbody.AddForceAtPosition(eventData.delta * Time.deltaTime * k_forceMultiplier, eventData.position, ForceMode2D.Force);
        
		teaSpinAmountTotal += eventData.delta.magnitude;

		if (teaSpinAmountTotal > k_teaSpinAmountTarget)
		{
			TeaMixed();

			UIManager.instance.OnTeaMixed();
		}
	}

	public void OnPointerClick(PointerEventData pointerEventData)
    {      
		if (Game.instance.IngredientManager.NumberOfSelectedIngredients >= 1)
		{
			foreach (Rigidbody2D mixRigidbody in mixRigidbodies)
				mixRigidbody.gameObject.SetActive(true);

			IngredientData[] currentIngredients = Game.instance.IngredientManager.currentIngredients;

			for (int i = 0; i < currentIngredients.Length; i++)
			{
				if (currentIngredients[i] != null)
				{
					mixSprites[i].gameObject.SetActive(true);
					mixSprites[i].sprite = currentIngredients[i].mixSprite;
				}
				else
				{
					mixSprites[i].gameObject.SetActive(false);
				}
			}
        }

        Game.instance.ClearIngredients();
		Game.instance.IngredientManager.ClearIngredients();
    }

	private void TeaMixed()
	{
		teaSpinAmountTotal = 0f;
        
		foreach (Rigidbody2D mixRigidbody in mixRigidbodies)
            mixRigidbody.gameObject.SetActive(false);
	}
}
