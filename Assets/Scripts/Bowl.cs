using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowl : MonoBehaviour, IPointerClickHandler, IDragHandler
{
	[SerializeField]
	private Rigidbody2D teaMix;

	private const float k_forceMultiplier = 0.01f;
	private const float k_teaSpinAmountTarget = 5000f;

	private float teaSpinAmountTotal = 0f;

	public void OnDrag(PointerEventData eventData)
	{
		teaMix.AddForceAtPosition(eventData.delta * Time.deltaTime * k_forceMultiplier, eventData.position, ForceMode2D.Force);
        
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
            teaMix.gameObject.SetActive(true);
        }

        Game.instance.ClearIngredients();
		Game.instance.IngredientManager.ClearIngredients();
    }

	private void TeaMixed()
	{
		teaSpinAmountTotal = 0f;
		
        teaMix.gameObject.SetActive(false);
	}
}
